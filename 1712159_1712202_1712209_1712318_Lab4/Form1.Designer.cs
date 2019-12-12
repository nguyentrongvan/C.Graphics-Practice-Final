namespace _1712159_1712202_1712209_1712318_Lab4
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openGLControl = new SharpGL.OpenGLControl();
            this.bt_Cube = new System.Windows.Forms.Button();
            this.bt_Prismatic = new System.Windows.Forms.Button();
            this.bt_Pyramid = new System.Windows.Forms.Button();
            this.bt_Camera = new System.Windows.Forms.Button();
            this.bt_Coordinates = new System.Windows.Forms.Button();
            this.bt_Plane = new System.Windows.Forms.Button();
            this.bt_LoadTexture = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bt_Rotate = new System.Windows.Forms.Button();
            this.gBox_Transform = new System.Windows.Forms.GroupBox();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.gBox_Transform.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(3, 78);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(1074, 538);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openGLControl_KeyDown);
            this.openGLControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.openGLControl_KeyPress);
            this.openGLControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.openGLControl_KeyUp);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            this.openGLControl.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.openGLControl_PreviewKeyDown);
            // 
            // bt_Cube
            // 
            this.bt_Cube.Location = new System.Drawing.Point(12, 3);
            this.bt_Cube.Name = "bt_Cube";
            this.bt_Cube.Size = new System.Drawing.Size(75, 23);
            this.bt_Cube.TabIndex = 1;
            this.bt_Cube.Text = "Cube";
            this.bt_Cube.UseVisualStyleBackColor = true;
            this.bt_Cube.Click += new System.EventHandler(this.bt_Cube_Click);
            // 
            // bt_Prismatic
            // 
            this.bt_Prismatic.Location = new System.Drawing.Point(13, 33);
            this.bt_Prismatic.Name = "bt_Prismatic";
            this.bt_Prismatic.Size = new System.Drawing.Size(75, 23);
            this.bt_Prismatic.TabIndex = 2;
            this.bt_Prismatic.Text = "Prismatic";
            this.bt_Prismatic.UseVisualStyleBackColor = true;
            this.bt_Prismatic.Click += new System.EventHandler(this.bt_Prismatic_Click);
            // 
            // bt_Pyramid
            // 
            this.bt_Pyramid.Location = new System.Drawing.Point(93, 3);
            this.bt_Pyramid.Name = "bt_Pyramid";
            this.bt_Pyramid.Size = new System.Drawing.Size(75, 23);
            this.bt_Pyramid.TabIndex = 3;
            this.bt_Pyramid.Text = "Pyramid";
            this.bt_Pyramid.UseVisualStyleBackColor = true;
            this.bt_Pyramid.Click += new System.EventHandler(this.bt_Pyramid_Click);
            // 
            // bt_Camera
            // 
            this.bt_Camera.Location = new System.Drawing.Point(989, 33);
            this.bt_Camera.Name = "bt_Camera";
            this.bt_Camera.Size = new System.Drawing.Size(75, 23);
            this.bt_Camera.TabIndex = 4;
            this.bt_Camera.Text = "Camera";
            this.bt_Camera.UseVisualStyleBackColor = true;
            this.bt_Camera.Click += new System.EventHandler(this.bt_Camera_Click);
            // 
            // bt_Coordinates
            // 
            this.bt_Coordinates.Location = new System.Drawing.Point(908, 3);
            this.bt_Coordinates.Name = "bt_Coordinates";
            this.bt_Coordinates.Size = new System.Drawing.Size(75, 23);
            this.bt_Coordinates.TabIndex = 5;
            this.bt_Coordinates.Text = "Coordinate";
            this.bt_Coordinates.UseVisualStyleBackColor = true;
            this.bt_Coordinates.Click += new System.EventHandler(this.bt_Coordinates_Click);
            // 
            // bt_Plane
            // 
            this.bt_Plane.Location = new System.Drawing.Point(908, 33);
            this.bt_Plane.Name = "bt_Plane";
            this.bt_Plane.Size = new System.Drawing.Size(75, 23);
            this.bt_Plane.TabIndex = 6;
            this.bt_Plane.Text = "Plane";
            this.bt_Plane.UseVisualStyleBackColor = true;
            this.bt_Plane.Click += new System.EventHandler(this.bt_Plane_Click);
            // 
            // bt_LoadTexture
            // 
            this.bt_LoadTexture.Location = new System.Drawing.Point(94, 33);
            this.bt_LoadTexture.Name = "bt_LoadTexture";
            this.bt_LoadTexture.Size = new System.Drawing.Size(75, 23);
            this.bt_LoadTexture.TabIndex = 7;
            this.bt_LoadTexture.Text = "Texture";
            this.bt_LoadTexture.UseVisualStyleBackColor = true;
            this.bt_LoadTexture.Click += new System.EventHandler(this.bt_LoadTexture_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // bt_Rotate
            // 
            this.bt_Rotate.Location = new System.Drawing.Point(988, 3);
            this.bt_Rotate.Name = "bt_Rotate";
            this.bt_Rotate.Size = new System.Drawing.Size(75, 23);
            this.bt_Rotate.TabIndex = 9;
            this.bt_Rotate.Text = "Rotate";
            this.bt_Rotate.UseVisualStyleBackColor = true;
            this.bt_Rotate.Click += new System.EventHandler(this.bt_Rotate_Click);
            // 
            // gBox_Transform
            // 
            this.gBox_Transform.Controls.Add(this.textBoxZ);
            this.gBox_Transform.Controls.Add(this.textBoxY);
            this.gBox_Transform.Controls.Add(this.textBoxX);
            this.gBox_Transform.Controls.Add(this.comboBox1);
            this.gBox_Transform.Location = new System.Drawing.Point(403, 3);
            this.gBox_Transform.Name = "gBox_Transform";
            this.gBox_Transform.Size = new System.Drawing.Size(322, 53);
            this.gBox_Transform.TabIndex = 13;
            this.gBox_Transform.TabStop = false;
            this.gBox_Transform.Text = "Transform";
            this.gBox_Transform.Enter += new System.EventHandler(this.gBox_Transform_Enter);
            // 
            // textBoxZ
            // 
            this.textBoxZ.Location = new System.Drawing.Point(275, 20);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(31, 20);
            this.textBoxZ.TabIndex = 16;
            this.textBoxZ.TextChanged += new System.EventHandler(this.textBoxZ_TextChanged);
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(223, 20);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(32, 20);
            this.textBoxY.TabIndex = 15;
            this.textBoxY.TextChanged += new System.EventHandler(this.textBoxY_TextChanged);
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(172, 19);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(31, 20);
            this.textBoxX.TabIndex = 14;
            this.textBoxX.TextChanged += new System.EventHandler(this.textBoxX_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 617);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gBox_Transform);
            this.Controls.Add(this.bt_Rotate);
            this.Controls.Add(this.bt_LoadTexture);
            this.Controls.Add(this.bt_Plane);
            this.Controls.Add(this.bt_Coordinates);
            this.Controls.Add(this.bt_Camera);
            this.Controls.Add(this.bt_Pyramid);
            this.Controls.Add(this.bt_Prismatic);
            this.Controls.Add(this.bt_Cube);
            this.Controls.Add(this.openGLControl);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.gBox_Transform.ResumeLayout(false);
            this.gBox_Transform.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Button bt_Cube;
        private System.Windows.Forms.Button bt_Prismatic;
        private System.Windows.Forms.Button bt_Pyramid;
        private System.Windows.Forms.Button bt_Camera;
        private System.Windows.Forms.Button bt_Coordinates;
        private System.Windows.Forms.Button bt_Plane;
        private System.Windows.Forms.Button bt_LoadTexture;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bt_Rotate;
        private System.Windows.Forms.GroupBox gBox_Transform;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Button button1;
    }
}

