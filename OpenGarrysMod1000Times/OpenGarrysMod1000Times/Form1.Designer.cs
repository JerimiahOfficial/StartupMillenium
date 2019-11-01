namespace Startup_Millenium
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.content = new System.Windows.Forms.Panel();
            this.github_Button = new System.Windows.Forms.Button();
            this.youtube_Button = new System.Windows.Forms.Button();
            this.Checker = new System.Windows.Forms.Timer(this.components);
            this.startButton = new Startup_Millenium.b();
            this.mainButton = new System.Windows.Forms.ImageList(this.components);
            this.closeButton = new Startup_Millenium.b();
            this.Status = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.content.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Startup Millenium";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(94, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 75);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Garry\'s Mod 1000 times";
            // 
            // content
            // 
            this.content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.content.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.content.Controls.Add(this.closeButton);
            this.content.Controls.Add(this.panel1);
            this.content.Controls.Add(this.startButton);
            this.content.Controls.Add(this.github_Button);
            this.content.Controls.Add(this.youtube_Button);
            this.content.Controls.Add(this.pictureBox1);
            this.content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.content.Location = new System.Drawing.Point(0, 0);
            this.content.Name = "content";
            this.content.Size = new System.Drawing.Size(375, 138);
            this.content.TabIndex = 4;
            // 
            // github_Button
            // 
            this.github_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.github_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("github_Button.BackgroundImage")));
            this.github_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.github_Button.FlatAppearance.BorderSize = 0;
            this.github_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.github_Button.Location = new System.Drawing.Point(11, 92);
            this.github_Button.Name = "github_Button";
            this.github_Button.Size = new System.Drawing.Size(30, 30);
            this.github_Button.TabIndex = 5;
            this.github_Button.UseVisualStyleBackColor = false;
            this.github_Button.Click += new System.EventHandler(this.button2_Click);
            // 
            // youtube_Button
            // 
            this.youtube_Button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.youtube_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("youtube_Button.BackgroundImage")));
            this.youtube_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.youtube_Button.FlatAppearance.BorderSize = 0;
            this.youtube_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.youtube_Button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.youtube_Button.Location = new System.Drawing.Point(47, 92);
            this.youtube_Button.Name = "youtube_Button";
            this.youtube_Button.Size = new System.Drawing.Size(30, 30);
            this.youtube_Button.TabIndex = 4;
            this.youtube_Button.UseVisualStyleBackColor = false;
            this.youtube_Button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Checker
            // 
            this.Checker.Interval = 8000;
            this.Checker.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.ImageIndex = 0;
            this.startButton.ImageList = this.mainButton;
            this.startButton.Location = new System.Drawing.Point(332, 92);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(30, 30);
            this.startButton.TabIndex = 6;
            this.startButton.TabStop = false;
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // mainButton
            // 
            this.mainButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mainButton.ImageStream")));
            this.mainButton.TransparentColor = System.Drawing.Color.Transparent;
            this.mainButton.Images.SetKeyName(0, "30.png");
            this.mainButton.Images.SetKeyName(1, "icons8-stop-24.png");
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Roboto Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(83, 92);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(243, 30);
            this.closeButton.TabIndex = 7;
            this.closeButton.TabStop = false;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // Status
            // 
            this.Status.Enabled = true;
            this.Status.Tick += new System.EventHandler(this.Status_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(375, 138);
            this.Controls.Add(this.content);
            this.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Startup Millenium";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.content.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel content;
        private System.Windows.Forms.Timer Checker;
        private System.Windows.Forms.Button github_Button;
        private System.Windows.Forms.Button youtube_Button;
        private b startButton;
        private System.Windows.Forms.ImageList mainButton;
        private b closeButton;
        private System.Windows.Forms.Timer Status;
    }
}

