using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace B_Geometry
{
    public partial class Form1 : Form
    {
        static float angle = 0.0f;
        static BCurve session_curve = new BCurve();
        static bool mouse_clicked = false;
        static int[] mouse_position = new int[2];
        public bool is_first_render = true;

        public Form1()
        {
            InitializeComponent();
            this.button1_Click(new object(), new EventArgs());

            this.glControl1.Load += glControl1_Load;

            //  Register resize:
            this.glControl1.Resize += this.glControl_Resize;
            
            //  Register mouse click:
            this.glControl1.MouseDown += glControl1_MouseDown;

            //  Register mouse move:
            this.glControl1.MouseMove += glControl1_MouseMove;

            //  Register mouse up:
            this.glControl1.MouseUp += glControl1_MouseUp;
        }

        void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_clicked = false;
        }

        void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_clicked)
            {
                //  Get difference in positions:
                int diff_x = e.X - mouse_position[0];
                int diff_y = e.Y - mouse_position[1];
                Vector3d x_axis = new Vector3d(1.0, .0, .0);
                Vector3d y_axis = new Vector3d(.0, 1.0, .0);
                double angleX = (double)diff_x / 5.0;
                double angleY = (double)diff_y / 5.0;
                GL.Rotate(angleX, x_axis);
                GL.Rotate(-1.0*angleY, y_axis);

                //  Record new position:
                mouse_position[0] = e.X;
                mouse_position[1] = e.Y;

                Render();
            }
        }

        void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //  Set mouse clicked to true and record position:
            mouse_clicked = true;
            mouse_position[0] = e.X;
            mouse_position[1] = e.Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> knots = new List<double>();
            knots.Add(0.0);
            knots.Add(0.0);
            knots.Add(0.0);
            knots.Add(1.0);
            knots.Add(2.0);
            knots.Add(3.0);
            knots.Add(4.0);
            knots.Add(4.0);
            knots.Add(5.0);
            knots.Add(5.0);
            knots.Add(5.0);

            BasisFunction basis = new BasisFunction(knots);

            List<Vector> control_points = new List<Vector>();

            control_points.Add(new Vector(new double[]{0.0, 0.0}));
            control_points.Add(new Vector(new double[]{1.0, 1.0}));
            control_points.Add(new Vector(new double[]{2.0, 0.0}));
            control_points.Add(new Vector(new double[]{3.0, -1.0}));
            control_points.Add(new Vector(new double[]{4.0, 0.0}));
            control_points.Add(new Vector(new double[]{5.0, 1.0}));
            control_points.Add(new Vector(new double[]{6.0, 0.0}));
            control_points.Add(new Vector(new double[]{7.0, -1.0}));



            BCurve curve = new BCurve(2, control_points, basis);

            session_curve = curve;

            Vector result = curve.Evaluate(2.5);

            /// Testing gaussian elimination:
            List<List<double>> matrix_elements = new List<List<double>>();

            matrix_elements.Add(new List<double>());
            matrix_elements[0].Add(1);
            matrix_elements[0].Add(-3);
            matrix_elements[0].Add(1);

            matrix_elements.Add(new List<double>());
            matrix_elements[1].Add(2);
            matrix_elements[1].Add(-8);
            matrix_elements[1].Add(8);

           

            matrix_elements.Add(new List<double>());
            matrix_elements[2].Add(-6);
            matrix_elements[2].Add(3);
            matrix_elements[2].Add(-15);

            Vector rhs = new Vector(new double[] { 4, -2, 9 });

            BGeomMatrix matrix = new BGeomMatrix(matrix_elements);

            double[] results = null;

            LinearAlgebra.GaussianElimination(matrix, rhs, ref results);

            /// make straight line with points:
            List<Vector> stragiht_line = new List<Vector>();
            for (int i = 0; i < 5; i++)
            {
                stragiht_line.Add(new Vector(new double[] { i, i%2.0 }));
            }

            /// Interpolate straight line
            BCurve straight_line = new BCurve();
            GeomUtils.CentripetalMethod_createSplineByInterpolation(3, stragiht_line.ToArray(), ref straight_line);
            session_curve = straight_line;
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
            this.glControl1.Size = this.Size;

            GL.Viewport(0, 0, this.Width, this.Height);

            float aspect_ratio = Width / (float)Height;
            Matrix4 perpective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perpective);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void Render()
        {
            if (is_first_render)
            {
                Matrix4 lookat = Matrix4.LookAt(0, 5, 5, 0, 0, 0, 0, 1, 0);

                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadMatrix(ref lookat);
                GL.Translate(-2.0, -2.0, 0.0);
                
                is_first_render = false;
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            DrawCurve(0.001);
            DrawCube();
            
            glControl1.SwapBuffers();
        }


        private void DrawCurve(double resolution)
        {
            int count = (int)(5.0 / resolution);
            double param = 0.0;

            GL.Begin(BeginMode.LineStrip);
            GL.Color3(Color.White);
            
            while ( param < 1.0 )
            {
                Vector temp = session_curve.Evaluate(param);
            
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

        /*private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            this.glControl_Resize(sender, e);
        }*/
    }
}
