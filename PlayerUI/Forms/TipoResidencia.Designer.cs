namespace PlayerUI.Forms
{
    partial class TipoResidencia
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelIzquierdo = new PlayerUI.GradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelDerecho = new System.Windows.Forms.Panel();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnviarResidencia = new System.Windows.Forms.Button();
            this.txtTipoResidencia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowPanelLogin = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelDerecho.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelDerecho, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelIzquierdo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1082, 767);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.panelIzquierdo.Size = new System.Drawing.Size(535, 761);
            this.panelIzquierdo.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PlayerUI.Properties.Resources.logo_sin_fondo;
            this.pictureBox1.Location = new System.Drawing.Point(113, 253);
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
            this.pictureBox2.Location = new System.Drawing.Point(327, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(208, 761);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // panelDerecho
            // 
            this.panelDerecho.BackColor = System.Drawing.Color.White;
            this.panelDerecho.Controls.Add(this.btnRegresar);
            this.panelDerecho.Controls.Add(this.label4);
            this.panelDerecho.Controls.Add(this.btnEnviarResidencia);
            this.panelDerecho.Controls.Add(this.txtTipoResidencia);
            this.panelDerecho.Controls.Add(this.label1);
            this.panelDerecho.Controls.Add(this.flowPanelLogin);
            this.panelDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDerecho.Location = new System.Drawing.Point(544, 3);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Size = new System.Drawing.Size(535, 761);
            this.panelDerecho.TabIndex = 7;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnRegresar.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Location = new System.Drawing.Point(71, 606);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(164, 63);
            this.btnRegresar.TabIndex = 12;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.label4.Location = new System.Drawing.Point(92, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tipo residencia:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEnviarResidencia
            // 
            this.btnEnviarResidencia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEnviarResidencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.btnEnviarResidencia.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarResidencia.Location = new System.Drawing.Point(284, 606);
            this.btnEnviarResidencia.Name = "btnEnviarResidencia";
            this.btnEnviarResidencia.Size = new System.Drawing.Size(164, 63);
            this.btnEnviarResidencia.TabIndex = 4;
            this.btnEnviarResidencia.Text = "Enviar";
            this.btnEnviarResidencia.UseVisualStyleBackColor = false;
            this.btnEnviarResidencia.Click += new System.EventHandler(this.btnEnviarResidencia_Click);
            // 
            // txtTipoResidencia
            // 
            this.txtTipoResidencia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTipoResidencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipoResidencia.Font = new System.Drawing.Font("Gadugi", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoResidencia.Location = new System.Drawing.Point(94, 335);
            this.txtTipoResidencia.Name = "txtTipoResidencia";
            this.txtTipoResidencia.Size = new System.Drawing.Size(354, 38);
            this.txtTipoResidencia.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(163, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 76);
            this.label1.TabIndex = 1;
            this.label1.Text = "TIPO\r\nRESIDENCIA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flowPanelLogin
            // 
            this.flowPanelLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowPanelLogin.AutoSize = true;
            this.flowPanelLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowPanelLogin.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelLogin.Location = new System.Drawing.Point(117, 57);
            this.flowPanelLogin.Name = "flowPanelLogin";
            this.flowPanelLogin.Size = new System.Drawing.Size(0, 0);
            this.flowPanelLogin.TabIndex = 0;
            this.flowPanelLogin.WrapContents = false;
            // 
            // TipoResidencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 767);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TipoResidencia";
            this.Text = "TipoResidencia";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelIzquierdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelDerecho.ResumeLayout(false);
            this.panelDerecho.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private GradientPanel panelIzquierdo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelDerecho;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEnviarResidencia;
        private System.Windows.Forms.TextBox txtTipoResidencia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowPanelLogin;
    }
}