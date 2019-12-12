using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpGL;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Lighting;
using SharpGL.SceneGraph;

namespace _1712159_1712202_1712209_1712318_Lab4
{
    public partial class Form1 : Form
    {
        int shshape = 1;
        Point pStart, pEnd;
        bool mouseDown, mouseUp, camera = false, coordinate = false, plane = false, text = false;
        float height;
        int key;
        char keyPress;
        float cx = 3.0f, cz = 7.0f;
        int checkStop = 1;

        public Form1()
        {
            InitializeComponent();

            createCombo();
        }

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.ClearColor(0, 0, 0, 0);
            //--------------------------------------------------------
            //CHIẾU SÁNG ĐỐI TƯỢNG
            //--------------------------------------------------------
            float[] light_pos = { 0.0f, 0.0f, 1.0f, 0.0f }; //Thiết lập hướng chiếu từ trước vào.
            float shininess = 50.0f; //Thiết lập độ phản xạ ánh sáng
            float[] specular = { 1.0f, 1.0f, 1.0f, 1.0f };

            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, specular);
            gl.Material(OpenGL.GL_FRONT, OpenGL.GL_SHININESS, shininess);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light_pos);

            //Bật các chế độ chiếu sáng
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            
            //------------------------------------------------------
            //THIẾT LẬP GÁN TEXTURE
            //-------------------------------------------------------
            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl1 = this.openGLControl.OpenGL;

            //Bật chế độ gán texture
            gl1.Enable(OpenGL.GL_TEXTURE_2D);
            //Tạo ánh sáng
            Light light = new Light()
            {
                On = true,
                Position = new Vertex(3, 10, 3),
                GLCode = OpenGL.GL_LIGHT0
            };
        }        

        private void openGLControl_Resized(object sender, EventArgs e)
        {     
            OpenGL gl = openGLControl.OpenGL;

            if (camera != true)
            {  //set ma tran viewport
                gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);

                //set ma tran phep chieu
                gl.MatrixMode(OpenGL.GL_PROJECTION);
                gl.Perspective(45, openGLControl.Width / openGLControl.Height, 1.0, 60.0);

                //set ma tran model view
                gl.MatrixMode(OpenGL.GL_MODELVIEW);
                gl.LookAt(cx, 5.0f, cz, 0.0, 0.0f, 0.0, 0.0f, 1.0f, 0.0f);
            }
        }

        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            //  Get the Opengl1 object, for quick access.
            SharpGL.OpenGL gl1 = this.openGLControl.OpenGL;
            //Bind Texture
            texture.Bind(gl1);

            //------------------------------------------------------------------
            //VẼ HỆ TRỤC TOẠ ĐỘ
            //-----------------------------------------------------------------
            View view = new View(height);
            if (coordinate==true)
            {
                view.DrawCoordinates(gl);   
            }

            //----------------------------------------------------------------
            //VẼ MẶT PHẲNG ĐÁY
            //----------------------------------------------------------------
            if(plane==true)
            {
                view.DrawPlane(gl);
            }
            //--------------------------------------------------------------
            //VẼ ĐỐI TƯỢNG 3D
            //--------------------------------------------------------------
            switch (shshape)
            {
                case 1:
                    Cube cube = new Cube(pStart,pEnd);
                    cube.Draw(gl);              
                    if (text == true) //Kiểm tra nếu đang trong chế độ gán Texture thì thực hiện gán
                    {
                        gl.Enable(OpenGL.GL_TEXTURE_2D);
                        cube.LoadTexture(gl);
                    }
                    height = cube.getHeight();
                    break;
                case 2:
                    Prismatic pris = new Prismatic(pStart, pEnd);
                    pris.Draw(gl);
                    gl.Disable(OpenGL.GL_TEXTURE_2D);
                    height = pris.getHeight();
                    break;
                case 3:
                    Pyramid pyra = new Pyramid(pStart, pEnd);
                    pyra.Draw(gl);
                    if (text == true)
                    {
                        gl.Enable(OpenGL.GL_TEXTURE_2D);
                        pyra.LoadTexture(gl);
                    }
                    height = pyra.getHeight();
                    break;
            }
            //-------------------------------------------------------------------
            //CHO XOAY VẬT THỂ QUANH TRỤC 0y
            //-------------------------------------------------------------------
            if(rotate==true)
            {
                gl.Rotate(0.0f, 2.0f, 0.0f);
            }

            //=-------------------------------------------------------------------
            //HƯỚNG GÓC NHÌN CAMERA
            //--------------------------------------------------------------------
            if(camera==true && checkStop==0)
            {
                CameraObjcet c = new CameraObjcet();
                c.KeyValue(key);
                cx = c.getLeft();
                cz = c.getRight();
                gl.LookAt(cx, 5.0f, cz, 0.0, 0.0f, 0.0, 0.0f, 1.0f, 0.0f);
            }
        }
        //-------------------------------------------------------------------------
        //CÁC LỚP ĐỐI TƯỢNG 3D
        //-------------------------------------------------------------------------

        public abstract class Shape3D
        {
            public Point _pStart, _pEnd;
            public float _height;
            public int _shape;

            public Shape3D()
            {
                _pStart = new Point(0, 0);
                _pEnd = _pStart;
            }

            public Shape3D(Point p1, Point p2)
            {
                _pStart = p1;
                _pEnd = p2;
            }

            public void setStart(Point p)
            {
                _pStart = p;
            }

            public void setEnd(Point p)
            {
                _pEnd = p;
            }

            public void setHeight(float v)
            {
                _height = v;
            }

            public void setShape(int s)
            {
                _shape = s;
            }

            public Point getStart()
            {
                return _pStart;
            }

            public Point getEnd()
            {
                return _pEnd;
            }

            public float getHeight()
            {
                return _height;
            }

            public int getShape()
            {
                return _shape;
            }

            public virtual void Draw() { }

            public virtual void LoadTexture() { }
        }

        public class Cube : Shape3D
        {
            public Cube()
            {
                _pStart = new Point(0, 0);
                _pEnd = _pStart;
                _shape = 1;
            }

            public Cube(Point p1, Point p2)
            {
                _pStart = p1;
                _pEnd = p2;
                _shape = 1;
            }

            public void Draw(OpenGL gl)
            {
                float a;
                a = (float)Math.Sqrt(Math.Pow(_pEnd.X - _pStart.X, 2) + Math.Pow(_pEnd.Y - _pStart.Y, 2)); //Tính độ dài cạnh dựa vào vị trí chuột đầu cuối
                a = a / (float)Math.Sqrt(2);
                gl.Color(255.0, 255.0, 255.0);
                gl.Begin(OpenGL.GL_QUADS);

                _height = a / 2;

                //Bottom
                gl.Normal(0.0, -1.0, 0.0);
                gl.Vertex(a / 2, -a / 2, a / 2);
                gl.Vertex(a / 2, -a / 2, -a / 2);
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

            public void LoadTexture(OpenGL gl)
            {
                float a;
                a = (float)Math.Sqrt(Math.Pow(_pEnd.X - _pStart.X, 2) + Math.Pow(_pEnd.Y - _pStart.Y, 2));
                a = a / (float)Math.Sqrt(2);
                gl.Color(255.0, 255.0, 255.0);

                _height = a / 2;
                gl.Begin(OpenGL.GL_QUADS);

                //Bottom
                gl.Normal(0.0, -1.0, 0.0);
                gl.TexCoord(0.0, 0.0); gl.Vertex(a / 2, -a / 2, a / 2);
                gl.TexCoord(0.0, 1.0); gl.Vertex(a / 2, -a / 2, -a / 2);
                gl.TexCoord(1.0, 1.0); gl.Vertex(-a / 2, -a / 2, -a / 2);
                gl.TexCoord(1.0, 0.0); gl.Vertex(-a / 2, -a / 2, a / 2);

                //Top
                gl.Normal(0.0, 1.0, 0.0);
                gl.TexCoord(1.0, 0.0); gl.Vertex(a / 2, a / 2, a / 2);
                gl.TexCoord(1.0, 1.0); gl.Vertex(a / 2, a / 2, -a / 2);
                gl.TexCoord(0.0, 1.0); gl.Vertex(-a / 2, a / 2, -a / 2);
                gl.TexCoord(0.0, 0.0); gl.Vertex(-a / 2, a / 2, a / 2);

                //Front
                gl.Normal(0.0, 0.0, 1.0);
                gl.TexCoord(1.0, 1.0); gl.Vertex(a / 2, a / 2, a / 2);
                gl.TexCoord(1.0, 0.0); gl.Vertex(a / 2, -a / 2, a / 2);
                gl.TexCoord(0.0, 0.0); gl.Vertex(-a / 2, -a / 2, a / 2);
                gl.TexCoord(0.0, 1.0); gl.Vertex(-a / 2, a / 2, a / 2);

                //Back
                gl.Normal(0.0, 0.0, -1.0);
                gl.TexCoord(0.0, 1.0); gl.Vertex(a / 2, a / 2, -a / 2);
                gl.TexCoord(0.0, 0.0); gl.Vertex(a / 2, -a / 2, -a / 2);
                gl.TexCoord(1.0, 0.0); gl.Vertex(-a / 2, -a / 2, -a / 2);
                gl.TexCoord(1.0, 1.0); gl.Vertex(-a / 2, a / 2, -a / 2);

                //Left
                gl.Normal(-1.0, 0.0, 0.0);
                gl.TexCoord(0.0, 1.0); gl.Vertex(-a / 2, a / 2, -a / 2);
                gl.TexCoord(0.0, 0.0); gl.Vertex(-a / 2, -a / 2, -a / 2);
                gl.TexCoord(1.0, 0.0); gl.Vertex(-a / 2, -a / 2, a / 2);
                gl.TexCoord(1.0, 1.0); gl.Vertex(-a / 2, a / 2, a / 2);

                //Right
                gl.Normal(1.0, 0.0, 0.0);
                gl.TexCoord(1.0, 1.0); gl.Vertex(a / 2, a / 2, -a / 2);
                gl.TexCoord(1.0, 0.0); gl.Vertex(a / 2, -a / 2, -a / 2);
                gl.TexCoord(0.0, 0.0); gl.Vertex(a / 2, -a / 2, a / 2);
                gl.TexCoord(0.0, 1.0); gl.Vertex(a / 2, a / 2, a / 2);

                gl.End();
                gl.Flush();
            }
        }
        public class Prismatic : Shape3D
        {
            public Prismatic()
            {
                _pStart = new Point(0, 0);
                _pEnd = _pStart;
                _shape = 2;
            }

            public Prismatic(Point p1, Point p2)
            {
                _pStart = p1;
                _pEnd = p2;
                _shape = 2;
            }

            public void Draw(OpenGL gl)
            {
                float a, a1, a2, b;
                a = Math.Abs(_pStart.X - _pEnd.X);
                a1 = a * (float)Math.Sqrt(3) / 3.0f;
                a2 = a * (float)Math.Sqrt(3) / 6.0f;
                b = Math.Abs(_pStart.Y - _pEnd.Y);

                _height = b / 2;

                gl.Color(255.0, 255.0, 255.0);

                gl.Begin(OpenGL.GL_TRIANGLES);
                //Bottom

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
        }
        public class Pyramid : Shape3D
        {
            public Pyramid()
            {
                _pStart = new Point(0, 0);
                _pEnd = _pStart;
                _shape = 3;
            }

            public Pyramid(Point p1, Point p2)
            {
                _pStart = p1;
                _pEnd = p2;
                _shape = 3;
            }

            public void Draw(OpenGL gl)
            {
                float a, b;
                a = Math.Abs(_pEnd.X - _pStart.X);
                b = Math.Abs(_pEnd.Y - _pStart.Y);
                float R;
                R = ((3 * a * a + 4 * b * b) / 4) / (2 * b);
                _height = b - R;

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

            public void LoadTexture(OpenGL gl)
            {
                float a, b;
                a = Math.Abs(_pEnd.X - _pStart.X);
                b = Math.Abs(_pEnd.Y - _pStart.Y);
                float R;
                R = ((3 * a * a + 4 * b * b) / 4) / (2 * b);
                _height = b - R;

                gl.Color(255.0, 255.0, 255.0);

                gl.Begin(OpenGL.GL_QUADS); //Bottom
                gl.Normal(0.0, -1.0, 0.0);
                gl.TexCoord(0.0, 0.0); gl.Vertex(a / 2, R - b, a / 2);
                gl.TexCoord(0.0, 1.0); gl.Vertex(a / 2, R - b, -a / 2);
                gl.TexCoord(1.0, 1.0); gl.Vertex(-a / 2, R - b, -a / 2);
                gl.TexCoord(1.0, 0.0); gl.Vertex(-a / 2, R - b, a / 2);
                gl.End();

                gl.Begin(OpenGL.GL_TRIANGLES);

                //right
                gl.Normal(1.0, 0.0, 0.0);
                gl.TexCoord(0.5, 1.0); gl.Vertex(0.0, R, 0.0);
                gl.TexCoord(0.0, 0.0); gl.Vertex(a / 2, R - b, a / 2);
                gl.TexCoord(1.0, 0.0); gl.Vertex(a / 2, R - b, -a / 2);

                //back
                gl.Normal(0.0, 0.0, -1.0);
                gl.TexCoord(0.5, 1.0); gl.Vertex(0.0, R, 0.0);
                gl.TexCoord(0.0, 0.0); gl.Vertex(a / 2, R - b, -a / 2);
                gl.TexCoord(1.0, 0.0); gl.Vertex(-a / 2, R - b, -a / 2);

                //left
                gl.Normal(-1.0, 0.0, 0.0);
                gl.TexCoord(0.5, 1.0); gl.Vertex(0.0, R, 0.0);
                gl.TexCoord(0.0, 0.0); gl.Vertex(-a / 2, R - b, -a / 2);
                gl.TexCoord(1.0, 0.0); gl.Vertex(-a / 2, R - b, a / 2);

                //front
                gl.Normal(0.0, 0.0, 1.0);
                gl.TexCoord(0.5, 1.0); gl.Vertex(0.0, R, 0.0);
                gl.TexCoord(0.0, 0.0); gl.Vertex(-a / 2, R - b, a / 2);
                gl.TexCoord(1.0, 0.0); gl.Vertex(a / 2, R - b, a / 2);

                gl.End();
                gl.Flush();
            }
        }

        //LỚP KHUNG CẢNH:
        public class View
        {
            public float _height;

            public View() { _height = 0; }

            public View(float height)
            {
                _height = height;
            }

            public void DrawCoordinates(OpenGL gl)
            {
                gl.LineWidth(3.0f);
                gl.Disable(OpenGL.GL_LIGHTING);
                gl.Disable(OpenGL.GL_TEXTURE_2D);
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
                gl.Enable(OpenGL.GL_TEXTURE_2D);
            }

            public void DrawPlane(OpenGL gl)
            {
                float h = _height;
                gl.Disable(OpenGL.GL_LIGHTING);
                gl.Disable(OpenGL.GL_TEXTURE_2D);
                gl.LineWidth(0.01f);
                gl.Color(255.0, 255.0, 255.0);
                gl.Begin(OpenGL.GL_LINES);

                for (int i = 0; i < 1000; i++)
                {
                    gl.Begin(OpenGL.GL_LINES);
                    gl.Vertex(i + 500, -h, 100);
                    gl.Vertex(i + 500, -h, -100);
                    gl.End();

                    gl.Begin(OpenGL.GL_LINES);
                    gl.Vertex(i - 500, -h, 100);
                    gl.Vertex(i - 500, -h, -100);
                    gl.End();
                }
                gl.End();


                for (int i = 0; i < 1000; i++)
                {
                    gl.Begin(OpenGL.GL_LINES);
                    gl.Vertex(100, -h, i + 500);
                    gl.Vertex(-100, -h, i + 500);
                    gl.End();

                    gl.Begin(OpenGL.GL_LINES);
                    gl.Vertex(100, -h, i - 500);
                    gl.Vertex(-100, -h, i - 500);
                    gl.End();
                }

                gl.Flush();
                gl.Enable(OpenGL.GL_LIGHTING);
                gl.Enable(OpenGL.GL_TEXTURE_2D);
            }
        }

        //-------------------------------------------------------------------------------------------
        //CÁC HÀM SỰ KIỆN:
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
            if (text == false)
            {
                text = true;
                OpenGL gl = openGLControl.OpenGL;
                gl.Enable(OpenGL.GL_TEXTURE_2D);
            }
            else
            {
                text = false;
                OpenGL gl = openGLControl.OpenGL;
                gl.Disable(OpenGL.GL_TEXTURE_2D);
            }
            camera = true;
        }

        private void openGLControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            keyPress = e.KeyChar;
        }

        private void openGLControl_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }
        //Envet of key down
        private void openGLControl_KeyDown(object sender, KeyEventArgs e)
        {
            key = e.KeyValue;
            checkStop = 0;
        }

        private void openGLControl_KeyUp(object sender, KeyEventArgs e)
        {
            key = e.KeyValue;
            checkStop = 1;
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

        bool rotate = false;

        private void gBox_Transform_Enter(object sender, EventArgs e)
        {

        }

        private void createCombo()
        {
            var item = new List<string>();
            item.Add("(None)");
            item.Add("Translate");
            item.Add("Rotate");
            item.Add("Scale");

            comboBox1.DataSource = item;
        }

        bool trans=false,ro=false,scale=false;

        float tx=0, ty=0, tz=0;

        private void textBoxZ_TextChanged(object sender, EventArgs e)
        {
            string s;
            s = textBoxZ.Text;
            tz = float.Parse(s);
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            string s;
            s = textBoxY.Text;
            ty = float.Parse(s);
        }

        private void textBoxX_TextChanged(object sender, EventArgs e)
        {
            string s;
            s = textBoxX.Text;
            tx = float.Parse(s);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value;
            value = comboBox1.Text;
            
            if(value=="Translate")
            {
                if (ro == false && scale == false)
                {
                    trans = true;
                    
                }
            }
            else if(value=="Rotate")
            {
                if (trans == false && scale == false)
                    ro = true;
            }
            else if(value=="Scale")
            {
                if (trans == false && ro == false)
                    scale = true;
            }
            else
            {
                trans = false;
                ro = false;
                scale = false;
            }
        }

        private void bt_Rotate_Click(object sender, EventArgs e)
        {
            if (rotate == false)
                rotate = true;
            else
                rotate = false;
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

        //Texture 3D
        //  The texture identifier.
        Texture texture = new Texture();

        private void bt_LoadTexture_Click(object sender, EventArgs e)
        {
            text = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //  Destroy the existing texture.
                texture.Destroy(openGLControl.OpenGL);

                //  Create a new texture.
                texture.Create(openGLControl.OpenGL, openFileDialog1.FileName);

                //  Redraw.
                openGLControl.Invalidate();
            }
        }
        //---------------------------------------------------------------------------------------------------------
        //LỚP ĐỐI TƯỢNG CAMERA
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
