using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using B_Geometry.Util;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace B_Geometry
{
    public partial class Form1 : Form
    {
        public bool IsFirstRender = true;

        private static bool _mouseClicked;
        private static readonly int[] MousePos = new int[2];
        private static BCurve _sessionCurve = new BCurve();

        public static float Angle { get; set; }

        public Form1()
        {
            InitializeComponent();
            button1_Click(new object(), new EventArgs());

            glControl1.Load += glControl1_Load;

            //  Register resize:
            glControl1.Resize += glControl_Resize;
            
            //  Register mouse click:
            glControl1.MouseDown += glControl1_MouseDown;

            //  Register mouse move:
            glControl1.MouseMove += glControl1_MouseMove;

            //  Register mouse up:
            glControl1.MouseUp += glControl1_MouseUp;
        }

        void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseClicked = false;
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_mouseClicked)
                return;

            //  Get difference in positions:
            var diffX = e.X - MousePos[0];
            var diffY = e.Y - MousePos[1];

            var xAxis = new Vector3d(1.0, .0, .0);
            var yAxis = new Vector3d(.0, 1.0, .0);

            var angleX = diffX/5.0;
            var angleY = diffY/5.0;

            GL.Rotate(angleX, xAxis);
            GL.Rotate(-1.0*angleY, yAxis);

            //  Record new position:
            MousePos[0] = e.X;
            MousePos[1] = e.Y;
            
            Render();
        }

        void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //  Set mouse clicked to true and record position:
            _mouseClicked = true;
            MousePos[0] = e.X;
            MousePos[1] = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var knots = new List<double>
            {
                0.0,
                0.0,
                0.0,
                1.0,
                2.0,
                3.0,
                4.0,
                4.0,
                5.0,
                5.0,
                5.0
            };

            var controlPoints = new List<Vector>
            {
                new Vector(new[] {0.0, 0.0}),
                new Vector(new[] {1.0, 1.0}),
                new Vector(new[] {2.0, 0.0}),
                new Vector(new[] {3.0, -1.0}),
                new Vector(new[] {4.0, 0.0}),
                new Vector(new[] {5.0, 1.0}),
                new Vector(new[] {6.0, 0.0}),
                new Vector(new[] {7.0, -1.0})
            };

            var basis = new BasisFunction(knots);
            var curve = new BCurve(2, controlPoints, basis);

            _sessionCurve = curve;

            curve.Evaluate(2.5);

            // Testing gaussian elimination:
            var matrixElements = new List<List<double>>
            {
                new List<double>
                {
                    1,
                    -3,
                    1
                },

                new List<double>
                {
                    2,
                    -8,
                    8
                },

                new List<double>
                {
                    -6,
                    3,
                    -15
                }
            };

            var rhs = new Vector(new double[] { 4, -2, 9 });
            var matrix = new BGeomMatrix(matrixElements);

            double[] results = null;

            LinearAlgebra.GaussianElimination(matrix, rhs, ref results);

            // make straight line with points:
            var straightLine0 = new List<Vector>();

            for (var i = 0; i < 5; i++)
                straightLine0.Add(new Vector(new[] { i, i % 2.0 }));

            // Interpolate straight line
            var straightLine1 = new BCurve();
            
            GeomUtils.CentripetalMethod_createSplineByInterpolation(3, straightLine0.ToArray(), ref straightLine1);

            _sessionCurve = straightLine1;
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);

            // Ensure that the viewport and projection matrix are set correctly.
            glControl_Resize(glControl1, EventArgs.Empty);
        }

        public void glControl_Resize(object sender, EventArgs e)
        {
            glControl1.Size = Size;

            GL.Viewport(0, 0, Width, Height);

            var aspectRatio = Width / (float)Height;
            var perpective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspectRatio, 1, 64);
            
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perpective);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void Render()
        {
            if (IsFirstRender)
            {
                var lookat = Matrix4.LookAt(0, 5, 5, 0, 0, 0, 0, 1, 0);

                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadMatrix(ref lookat);
                GL.Translate(-2.0, -2.0, 0.0);
                
                IsFirstRender = false;
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            DrawCurve(0.001);
            DrawCube();
            
            glControl1.SwapBuffers();
        }


        private void DrawCurve(double resolution)
        {
            //var count = (int)(5.0 / resolution);
            var param = 0.0;

            GL.Begin(BeginMode.LineStrip);
            GL.Color3(Color.White);
            
            while ( param < 1.0 )
            {
                var temp = _sessionCurve.Evaluate(param);
            
                GL.Vertex3(temp.Elements);
                
                param += resolution;
            }

            GL.End();
        }

        private void DrawCube()
        {
            GL.Begin(BeginMode.Quads);

            GL.Color3(Color.Silver);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            GL.Color3(Color.Honeydew);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);

            GL.Color3(Color.Moccasin);

            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);

            GL.Color3(Color.IndianRed);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);

            GL.Color3(Color.PaleVioletRed);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);

            GL.Color3(Color.ForestGreen);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);

            GL.End();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            glControl_Resize(sender, e);
        }
    }
}
