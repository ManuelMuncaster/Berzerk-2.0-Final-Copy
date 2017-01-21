namespace Berzerk_2._0
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.life1 = new System.Windows.Forms.PictureBox();
            this.life2 = new System.Windows.Forms.PictureBox();
            this.life3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.life1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life3)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 16;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // life1
            // 
            this.life1.BackgroundImage = global::Berzerk_2._0.Properties.Resources.lifeIcon;
            this.life1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.life1.Location = new System.Drawing.Point(61, 420);
            this.life1.Name = "life1";
            this.life1.Size = new System.Drawing.Size(38, 40);
            this.life1.TabIndex = 0;
            this.life1.TabStop = false;
            // 
            // life2
            // 
            this.life2.BackgroundImage = global::Berzerk_2._0.Properties.Resources.lifeIcon;
            this.life2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.life2.Location = new System.Drawing.Point(106, 420);
            this.life2.Name = "life2";
            this.life2.Size = new System.Drawing.Size(32, 40);
            this.life2.TabIndex = 1;
            this.life2.TabStop = false;
            // 
            // life3
            // 
            this.life3.BackgroundImage = global::Berzerk_2._0.Properties.Resources.lifeIcon;
            this.life3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.life3.Location = new System.Drawing.Point(145, 420);
            this.life3.Name = "life3";
            this.life3.Size = new System.Drawing.Size(32, 40);
            this.life3.TabIndex = 2;
            this.life3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.life3);
            this.Controls.Add(this.life2);
            this.Controls.Add(this.life1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.life1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox life1;
        private System.Windows.Forms.PictureBox life2;
        private System.Windows.Forms.PictureBox life3;
    }
}

