using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class LoginAnfitrion : Form
    {
        public LoginAnfitrion()
        {
            InitializeComponent();
        }

        private void panelDerecho_Resize(object sender, EventArgs e)
        {
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void LoginCopia_Load(object sender, EventArgs e)
        {
        

        }


        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDerecho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelIzquierdo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.Font = new Font(label2.Font, FontStyle.Underline);
            label2.ForeColor = Color.FromArgb(255, 128, 150);  // Cambia a otro color si quieres
            this.Cursor = Cursors.Hand;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Font = new Font(label2.Font, FontStyle.Regular);
            label2.ForeColor = Color.FromArgb(235, 42, 83); ; // O el color original que usabas
            this.Cursor = Cursors.Default;
        }

        private void labelRegistrar_MouseEnter(object sender, EventArgs e)
        {
            labelRegistrar.Font = new Font(labelRegistrar.Font, FontStyle.Underline);
            labelRegistrar.ForeColor = Color.FromArgb(255, 128, 150);  // Cambia a otro color si quieres
            this.Cursor = Cursors.Hand;
        }

        private void labelRegistrar_MouseLeave(object sender, EventArgs e)
        {
            labelRegistrar.Font = new Font(labelRegistrar.Font, FontStyle.Regular);
            labelRegistrar.ForeColor = Color.FromArgb(235, 42, 83); ; // O el color original que usabas
            this.Cursor = Cursors.Default;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
