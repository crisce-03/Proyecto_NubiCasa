namespace PlayerUI
{
    partial class LoginAnfitrion
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
            this.panel = new System.Windows.Forms.TableLayoutPanel();
            this.panelIzquierdo = new PlayerUI.GradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelDerecho = new System.Windows.Forms.Panel();
            this.labelRegistrar = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowPanelLogin = new System.Windows.Forms.FlowLayoutPanel();
            this.panel.SuspendLayout();
            this.panelIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelDerecho.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.ColumnCount = 2;
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.panel.Controls.Add(this.panelIzquierdo, 0, 0);
            this.panel.Controls.Add(this.panelDerecho, 1, 0);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.RowCount = 1;
            this.panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel.Size = new System.Drawing.Size(1252, 687);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // panelIzquierdo
            // 
            this.panelIzquierdo.BackColor = System.Drawing.Color.Transparent;
            this.panelIzquierdo.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(150)))));
            this.panelIzquierdo.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.panelIzquierdo.Controls.Add(this.pictureBox1);
            this.panelIzquierdo.Controls.Add(this.pictureBox2);
            this.panelIzquierdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIzquierdo.Location = new System.Drawing.Point(3, 3);
            this.panelIzquierdo.Name = "panelIzquierdo";
            this.panelIzquierdo.Size = new System.Drawing.Size(682, 681);
            this.panelIzquierdo.TabIndex = 0;
            this.panelIzquierdo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelIzquierdo_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PlayerUI.Properties.Resources.logo_sin_fondo;
            this.pictureBox1.Location = new System.Drawing.Point(129, 205);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 279);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = global::PlayerUI.Properties.Resources.clouds_upright_2x4;
            this.pictureBox2.Location = new System.Drawing.Point(474, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(208, 681);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // panelDerecho
            // 
            this.panelDerecho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelDerecho.BackColor = System.Drawing.Color.White;
            this.panelDerecho.Controls.Add(this.labelRegistrar);
            this.panelDerecho.Controls.Add(this.label5);
            this.panelDerecho.Controls.Add(this.label4);
            this.panelDerecho.Controls.Add(this.label3);
            this.panelDerecho.Controls.Add(this.label2);
            this.panelDerecho.Controls.Add(this.button1);
            this.panelDerecho.Controls.Add(this.textBox2);
            this.panelDerecho.Controls.Add(this.textBox1);
            this.panelDerecho.Controls.Add(this.label1);
            this.panelDerecho.Controls.Add(this.flowPanelLogin);
            this.panelDerecho.Location = new System.Drawing.Point(691, 3);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Size = new System.Drawing.Size(558, 681);
            this.panelDerecho.TabIndex = 1;
            this.panelDerecho.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDerecho_Paint);
            // 
            // labelRegistrar
            // 
            this.labelRegistrar.AutoSize = true;
            this.labelRegistrar.BackColor = System.Drawing.Color.White;
            this.labelRegistrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegistrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.labelRegistrar.Location = new System.Drawing.Point(270, 551);
            this.labelRegistrar.Name = "labelRegistrar";
            this.labelRegistrar.Size = new System.Drawing.Size(75, 15);
            this.labelRegistrar.TabIndex = 9;
            this.labelRegistrar.Text = "Registrate";
            this.labelRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRegistrar.MouseEnter += new System.EventHandler(this.labelRegistrar_MouseEnter);
            this.labelRegistrar.MouseLeave += new System.EventHandler(this.labelRegistrar_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(119, 551);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "¿No Tienes Cuenta?";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.label4.Location = new System.Drawing.Point(53, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Usuario Contraseña";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.label3.Location = new System.Drawing.Point(53, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Contraseña";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.label2.Location = new System.Drawing.Point(206, 361);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "¿Olvidasta Tu Contraseña?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(141, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 62);
            this.button1.TabIndex = 4;
            this.button1.Text = "Iniciar Sesion";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Gadugi", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(56, 309);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(360, 38);
            this.textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Gadugi", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(56, 223);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(360, 38);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 76);
            this.label1.TabIndex = 1;
            this.label1.Text = "INICIAR SESIÓN\r\nANFITRIÓN\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flowPanelLogin
            // 
            this.flowPanelLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowPanelLogin.AutoSize = true;
            this.flowPanelLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowPanelLogin.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelLogin.Location = new System.Drawing.Point(83, -40);
            this.flowPanelLogin.Name = "flowPanelLogin";
            this.flowPanelLogin.Size = new System.Drawing.Size(0, 0);
            this.flowPanelLogin.TabIndex = 0;
            this.flowPanelLogin.WrapContents = false;
            // 
            // LoginAnfitrion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 687);
            this.Controls.Add(this.panel);
            this.Name = "LoginAnfitrion";
            this.Text = "LoginCopia";
            this.Load += new System.EventHandler(this.LoginCopia_Load);
            this.panel.ResumeLayout(false);
            this.panelIzquierdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelDerecho.ResumeLayout(false);
            this.panelDerecho.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel panel;
        private GradientPanel panelIzquierdo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelDerecho;
        private System.Windows.Forms.FlowLayoutPanel flowPanelLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelRegistrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}