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
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(3, 58);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(1074, 558);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.Load += new System.EventHandler(this.openGLControl1_Load);
            this.openGLControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openGLControl_KeyDown);
            this.openGLControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.openGLControl_KeyPress);
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
            this.bt_Camera.Location = new System.Drawing.Point(93, 33);
            this.bt_Camera.Name = "bt_Camera";
            this.bt_Camera.Size = new System.Drawing.Size(75, 23);
            this.bt_Camera.TabIndex = 4;
            this.bt_Camera.Text = "Camera";
            this.bt_Camera.UseVisualStyleBackColor = true;
            this.bt_Camera.Click += new System.EventHandler(this.bt_Camera_Click);
            // 
            // bt_Coordinates
            // 
            this.bt_Coordinates.Location = new System.Drawing.Point(988, 3);
            this.bt_Coordinates.Name = "bt_Coordinates";
            this.bt_Coordinates.Size = new System.Drawing.Size(75, 23);
            this.bt_Coordinates.TabIndex = 5;
            this.bt_Coordinates.Text = "Coordinate";
            this.bt_Coordinates.UseVisualStyleBackColor = true;
            this.bt_Coordinates.Click += new System.EventHandler(this.bt_Coordinates_Click);
            // 
            // bt_Plane
            // 
            this.bt_Plane.Location = new System.Drawing.Point(988, 33);
            this.bt_Plane.Name = "bt_Plane";
            this.bt_Plane.Size = new System.Drawing.Size(75, 23);
            this.bt_Plane.TabIndex = 6;
            this.bt_Plane.Text = "Plane";
            this.bt_Plane.UseVisualStyleBackColor = true;
            this.bt_Plane.Click += new System.EventHandler(this.bt_Plane_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 617);
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
    }
}

