namespace PlayerUI
{
    partial class PanelUsuario
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
            this.gradientPanel1 = new PlayerUI.GradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnHuesped = new System.Windows.Forms.Button();
            this.btnAnfitrion = new System.Windows.Forms.Button();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.gradientPanel1.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.gradientPanel1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.gradientPanel1.Controls.Add(this.pictureBox1);
            this.gradientPanel1.Controls.Add(this.btnHuesped);
            this.gradientPanel1.Controls.Add(this.btnAnfitrion);
            this.gradientPanel1.Controls.Add(this.panelContenido);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1252, 687);
            this.gradientPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PlayerUI.Properties.Resources.logo_sin_fondo;
            this.pictureBox1.Location = new System.Drawing.Point(450, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 246);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnHuesped
            // 
            this.btnHuesped.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHuesped.BackColor = System.Drawing.Color.Transparent;
            this.btnHuesped.BackgroundImage = global::PlayerUI.Properties.Resources.huesped_logo1;
            this.btnHuesped.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHuesped.Location = new System.Drawing.Point(335, 361);
            this.btnHuesped.Name = "btnHuesped";
            this.btnHuesped.Size = new System.Drawing.Size(254, 224);
            this.btnHuesped.TabIndex = 3;
            this.btnHuesped.UseVisualStyleBackColor = false;
            this.btnHuesped.Click += new System.EventHandler(this.btnHuesped_Click);
            // 
            // btnAnfitrion
            // 
            this.btnAnfitrion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAnfitrion.BackColor = System.Drawing.Color.Transparent;
            this.btnAnfitrion.BackgroundImage = global::PlayerUI.Properties.Resources.anfitrion_logo1;
            this.btnAnfitrion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnfitrion.Location = new System.Drawing.Point(626, 361);
            this.btnAnfitrion.Name = "btnAnfitrion";
            this.btnAnfitrion.Size = new System.Drawing.Size(253, 224);
            this.btnAnfitrion.TabIndex = 2;
            this.btnAnfitrion.UseVisualStyleBackColor = false;
            this.btnAnfitrion.Click += new System.EventHandler(this.btnAnfitrion_Click);
            // 
            // panelContenido
            // 
            this.panelContenido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelContenido.Location = new System.Drawing.Point(0, 0);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(1252, 687);
            this.panelContenido.TabIndex = 4;
            // 
            // PanelUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1252, 687);
            this.Controls.Add(this.gradientPanel1);
            this.Name = "PanelUsuario";
            this.Text = "PanelUsuario";
            this.gradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAnfitrion;
        private System.Windows.Forms.Button btnHuesped;
        private System.Windows.Forms.Panel panelContenido;
    }
}