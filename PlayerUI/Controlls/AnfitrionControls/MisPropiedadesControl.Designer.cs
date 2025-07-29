namespace PlayerUI.Controlls.AnfitrionControls
{
    partial class MisPropiedadesControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelPropiedades = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1140, 189);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(42)))), ((int)(((byte)(83)))));
            this.button1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(48, 76);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(313, 84);
            this.button1.TabIndex = 1;
            this.button1.Text = "Agregar Propiedad  +";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnAgregarPropiedad_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(400, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mis Propiedades";
            // 
            // flowLayoutPanelPropiedades
            // 
            this.flowLayoutPanelPropiedades.AutoScroll = true;
            this.flowLayoutPanelPropiedades.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanelPropiedades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelPropiedades.Location = new System.Drawing.Point(0, 189);
            this.flowLayoutPanelPropiedades.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanelPropiedades.Name = "flowLayoutPanelPropiedades";
            this.flowLayoutPanelPropiedades.Size = new System.Drawing.Size(1140, 611);
            this.flowLayoutPanelPropiedades.TabIndex = 1;
            // 
            // MisPropiedadesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 800);
            this.Controls.Add(this.flowLayoutPanelPropiedades);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MisPropiedadesControl";
            this.Text = "MisPropiedadesControlcs";
            this.Load += new System.EventHandler(this.MisPropiedadesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPropiedades;
    }
}