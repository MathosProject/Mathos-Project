using System;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace B_Geometry.New
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            var geometry = new GameWindow();

            geometry.Load += (sender, e) =>
            {
                // Initialize Things Here
                geometry.Title += "MathOS Geometry";
            };

            geometry.Resize += (sender, e) => GL.Viewport(0, 0, geometry.Width, geometry.Height);

            geometry.UpdateFrame += (sender, e) =>
            {
                // Update Things Here
            };

            geometry.RenderFrame += (sender, e) =>
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);

                // Render Things Here

                DrawTriangle();

                geometry.SwapBuffers();
            };

            geometry.Run(60.0);
        }

        private static void DrawTriangle()
        {
            GL.Begin(BeginMode.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-1.0f, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, -1.0f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();
        }
    }
}
