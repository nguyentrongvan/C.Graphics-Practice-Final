using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;

namespace _1712159_1712202_1712209_1712318_Lab4
{
    public partial class Form1 : Form
    {
        int shshape = 1;
        Point pStart, pEnd;
        bool mouseDown, mouseUp, camera = false, coordinate = false, plane = false;
        float height;
        int key;
        float cx = 3.0f, cz = 7.0f;

        public Form1()
        {
            InitializeComponent();
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {

        }

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;

            float[] light_pos = { 1.0f, 0.0f, 0.0f, 0.0f };
            gl.ClearColor(0, 0, 0, 0);
            gl.ShadeModel(OpenGL.GL_SMOOTH);
            float shininess = 50.0f;

            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, shininess);
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_POSITION, light_pos);

            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
        }        

        private void openGLControl_Resized(object sender, EventArgs e)
        {
            
                OpenGL gl = openGLControl.OpenGL;

                //set ma tran viewport
                gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);

                //set ma tran phep chieu
                gl.MatrixMode(OpenGL.GL_PROJECTION);
                gl.Perspective(45, openGLControl.Width / openGLControl.Height, 1.0, 60.0);

                //set ma tran model view
                gl.MatrixMode(OpenGL.GL_MODELVIEW);
                gl.LookAt(2.0f, 5.0f, 6.0f, 0.0, 0.0f, 0.0, 0.0f, 1.0f, 0.0f);
        }

        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            
            if (coordinate==true)
            {
                drawCoor(gl);
            }
            if(plane==true)
            {
                drawPlane(gl,height);
            }
            // Draw a coloured cube
            switch (shshape)
            {
                case 1:
                    drawCube(gl, pStart, pEnd);
                    break;
                case 2:
                    drawPrismatic(gl, pStart, pEnd);
                    break;
                case 3:
                    drawPyramid(gl, pStart, pEnd);
                    break;
            }
        }

        //Function to draw shape
        private void drawCube(OpenGL gl, Point pStart, Point pEnd)
        {
            float a;
            a= (float) Math.Sqrt(Math.Pow(pEnd.X-pStart.X, 2) + Math.Pow(pEnd.Y - pStart.Y, 2));
            a = a / (float)Math.Sqrt(2);
            gl.Color(255.0, 255.0, 255.0);

            height = a/2;
            gl.Begin(OpenGL.GL_QUADS);

            //Bottom
            gl.Normal(0.0, -1.0, 0.0);
            gl.Vertex(a / 2, -a/2, a / 2);
            gl.Vertex(a / 2, -a/2, -a / 2);
            gl.Vertex(-a / 2, -a / 2, -a / 2);
            gl.Vertex(-a / 2, -a / 2, a / 2);

            //Top
            gl.Normal(0.0, 1.0, 0.0);
            gl.Vertex(a / 2, a / 2, a / 2);
            gl.Vertex(a / 2, a / 2, -a / 2);
            gl.Vertex(-a / 2, a / 2, -a / 2);
            gl.Vertex(-a / 2, a / 2, a / 2);

            //Front
            gl.Normal(0.0, 0.0, 1.0);
            gl.Vertex(a / 2, a / 2, a / 2);
            gl.Vertex(a / 2, -a / 2, a / 2);
            gl.Vertex(-a / 2, -a / 2, a / 2);
            gl.Vertex(-a / 2, a / 2, a / 2);

            //Back
            gl.Normal(0.0, 0.0, -1.0);
            gl.Vertex(a / 2, a / 2, -a / 2);
            gl.Vertex(a / 2, -a / 2, -a / 2);
            gl.Vertex(-a / 2, -a / 2, -a / 2);
            gl.Vertex(-a / 2, a / 2, -a / 2);

            //Left
            gl.Normal(-1.0, 0.0, 0.0);
            gl.Vertex(-a / 2, a / 2, -a / 2);
            gl.Vertex(-a / 2, -a / 2, -a / 2);
            gl.Vertex(-a / 2, -a / 2, a / 2);
            gl.Vertex(-a / 2, a / 2, a / 2);

            //Right
            gl.Normal(1.0, 0.0, 0.0);
            gl.Vertex(a / 2, a / 2, -a / 2);
            gl.Vertex(a / 2, -a / 2, -a / 2);
            gl.Vertex(a / 2, -a / 2, a / 2);
            gl.Vertex(a / 2, a / 2, a / 2);

            gl.End();
            gl.Flush();
        }

        private void drawPrismatic(OpenGL gl, Point pStart, Point pEnd)
        {
            float a, a1, a2, b;
            a= Math.Abs(pStart.X - pEnd.X);
            a1 = a * (float)Math.Sqrt(3) / 3.0f;
            a2 = a * (float)Math.Sqrt(3) / 6.0f;
            b = Math.Abs(pStart.Y - pEnd.Y);
            height = b / 2;

            gl.Color(255.0, 255.0, 255.0);

            gl.Begin(OpenGL.GL_TRIANGLES); //Bottom

            gl.Normal(0.0, -1.0, 0.0);
            gl.Vertex(0.0, -b / 2, a1);
            gl.Vertex(a / 2, -b / 2, -a2);
            gl.Vertex(-a / 2, -b / 2, -a2);

            //Top
            gl.Normal(0.0, 1.0, 0.0);
            gl.Vertex(0.0, b / 2, a1);
            gl.Vertex(a / 2, b / 2, -a2);
            gl.Vertex(-a / 2, b / 2, -a2);
            gl.End();

            gl.Begin(OpenGL.GL_QUADS);
            //Right
            gl.Normal(1.0, 0.0, 0.0);
            gl.Vertex(0.0, -b / 2, a1);
            gl.Vertex(a / 2, -b / 2, -a2);
            gl.Vertex(a / 2, b / 2, -a2);
            gl.Vertex(0.0, b / 2, a1);

            //Back
            gl.Normal(0.0, 0.0, -1.0);
            gl.Vertex(a / 2, -b / 2, -a2);
            gl.Vertex(-a / 2, -b / 2, -a2);
            gl.Vertex(-a / 2, b / 2, -a2);
            gl.Vertex(a / 2, b / 2, -a2);

            //Left
            gl.Normal(-1.0, 0.0, 0.0);
            gl.Vertex(0.0, -b / 2, a1);
            gl.Vertex(-a / 2, -b / 2, -a2);
            gl.Vertex(-a / 2, b / 2, -a2);
            gl.Vertex(0.0, b / 2, a1);
            
            gl.End();

            gl.Flush();
        }

        private void drawPyramid(OpenGL gl, Point pStart, Point pEnd)
        {
            float a, b;
            a = Math.Abs(pEnd.X - pStart.X) / 2;
            b = Math.Abs(pEnd.Y - pStart.Y) / 2;
            float R;
            R = ((3 * a * a + 4 * b * b) / 4) / (2 * b);
            height = R - b;

            gl.Color(255.0, 255.0, 255.0);

            gl.Begin(OpenGL.GL_QUADS); //Bottom
            gl.Normal(0.0, -1.0, 0.0);
            gl.Vertex(a / 2, R - b, a / 2);
            gl.Vertex(a / 2, R - b, -a / 2);
            gl.Vertex(-a / 2, R - b, -a / 2);
            gl.Vertex(-a / 2, R - b, a / 2);
            gl.End();

            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Normal(1.0, 0.0, 0.0);
            gl.Vertex(0.0, R, 0.0);
            gl.Vertex(a / 2, R - b, a / 2);
            gl.Vertex(a / 2, R - b, -a / 2);

            gl.Normal(0.0, 0.0, -1.0);
            gl.Vertex(0.0, R, 0.0);
            gl.Vertex(a / 2, R - b, -a / 2);
            gl.Vertex(-a / 2, R - b, -a / 2);

            gl.Normal(-1.0, 0.0, 0.0);
            gl.Vertex(0.0, R, 0.0);
            gl.Vertex(-a / 2, R - b, -a / 2);
            gl.Vertex(-a / 2, R - b, a / 2);

            gl.Normal(0.0, 0.0, 1.0);
            gl.Vertex(0.0, R, 0.0);
            gl.Vertex(-a / 2, R - b, a / 2);
            gl.Vertex(a / 2, R - b, a / 2);

            gl.End();
            gl.Flush();
        }

        private void drawCoor(OpenGL gl)
        {
            gl.LineWidth(3.0f);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Begin(OpenGL.GL_LINES);

            gl.Color(1.0f, 0.0, 0.0);
            gl.Vertex(100, 0.0, 0.0);
            gl.Vertex(-100, 0.0, 0.0);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0.0, 1.0, 0.0);
            gl.Vertex(0.0, -100.0, 0.0);
            gl.Vertex(0.0, 100.0, 0.0);
            gl.End();

            gl.Begin(OpenGL.GL_LINES);
            gl.Color(0.0, 0.0, 1.0);
            gl.Vertex(0.0, 0.0, -100.0);
            gl.Vertex(0.0, 0.0, 100.0);
            gl.End();

            gl.Flush();
            gl.Enable(OpenGL.GL_LIGHTING);
        }

        private void drawPlane(OpenGL gl, float h)
        {
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.LineWidth(0.01f);
            gl.Color(255.0, 255.0, 255.0);
            gl.Begin(OpenGL.GL_LINES);

            for (int i = 0; i < 1000; i++)
            {
                gl.Begin(OpenGL.GL_LINES);
                gl.Vertex(i+500, -h, 100);
                gl.Vertex(i+500, -h, -100);
                gl.End();

                gl.Begin(OpenGL.GL_LINES);
                gl.Vertex(i-500, -h, 100);
                gl.Vertex(i-500, -h, -100);
                gl.End();
            }
            gl.End();

            
            for (int i = 0; i < 1000; i++)
            {
                gl.Begin(OpenGL.GL_LINES);
                gl.Vertex(100, -h, i+500);
                gl.Vertex(-100, -h, i+500);
                gl.End();

                gl.Begin(OpenGL.GL_LINES);
                gl.Vertex(100, -h, i - 500);
                gl.Vertex(-100, -h, i - 500);
                gl.End();
            }
            
            gl.Flush();
            gl.Enable(OpenGL.GL_LIGHTING);

        }
        //Envet of key down
        private void openGLControl_KeyDown(object sender, KeyEventArgs e)
        {
            key = e.KeyValue;
        }

        //Event of button click
        private void bt_Cube_Click(object sender, EventArgs e)
        {
            shshape = 1;
        }

        private void bt_Prismatic_Click(object sender, EventArgs e)
        {
            shshape = 2;
        }

        private void bt_Pyramid_Click(object sender, EventArgs e)
        {
            shshape = 3;
        }

        private void bt_Camera_Click(object sender, EventArgs e)
        {
            camera = true;
        }

        private void openGLControl_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void openGLControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void bt_Plane_Click(object sender, EventArgs e)
        {
            if (plane == false)
            {
                plane = true;
            }
            else
                plane = false;
        }

        private void bt_Coordinates_Click(object sender, EventArgs e)
        {
            if (coordinate == false)
            {
                coordinate = true;
            }
            else
                coordinate = false;
        }


        //Envent of mouse 
        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            pStart = e.Location;
            pEnd = pStart;
            mouseDown = true;
            mouseUp = false;
        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseUp == false && mouseDown == true)
            {
                pEnd = e.Location;
            }
        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            pEnd = e.Location;
            mouseDown = false;
            mouseUp = true;
        }

        //---------------------------------------------------------------------------------------------------------
        public class CameraObjcet : Form1
        {
            float _left;
            float _right;

            public CameraObjcet()
            {
                _left = cx;
                _right = cz;
            }

            public CameraObjcet(float x, float z)
            {
                _left = x;
                _right = z;
            }

            public float getLeft()
            {
                return _left;
            }

            public float getRight()
            {
                return _right;
            }

            public void getLeft(float x)
            {
                _left = x;
            }

            public void getRight(float z)
            {
                _right = z;
            }

            public void KeyValue(int key)
            {
                switch(key)
                {
                    case (int)Keys.Left:
                        _left -= 0.5f;
                        break;
                    case (int)Keys.Right:
                        _left += 0.5f;
                        break;
                }
            }
        }
    }
}
