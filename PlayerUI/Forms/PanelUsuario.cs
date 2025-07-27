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
    public partial class PanelUsuario : Form
    {
        public PanelUsuario()
        {
            InitializeComponent();
        }

        private void PanelUsuario_Resize(object sender, EventArgs e)
        {
        }

        private void btnHuesped_Click(object sender, EventArgs e)
        {
            LoginCopia loginCopia = new LoginCopia();
            loginCopia.Show();
            this.Hide();
        }

        private void btnAnfitrion_Click(object sender, EventArgs e)
        {
            LoginAnfitrion loginAnfitrion = new LoginAnfitrion();
            loginAnfitrion.Show();
            this.Hide();
        }
    }
}
