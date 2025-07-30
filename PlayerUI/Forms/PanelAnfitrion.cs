using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlayerUI.Controlls;
using PlayerUI.Controlls.AnfitrionControls;

namespace PlayerUI
{
    public partial class PanelAnfitrion : Form
    {
        private int idAnfitrion;

        public PanelAnfitrion(int ID_Anfitrion)
        {


            InitializeComponent();

            this.idAnfitrion = ID_Anfitrion;
            hideSubMenu();
        }

        private void hideSubMenu()
        {
        
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }


        private void btnInicio_Click(object sender, EventArgs e)
        {
            openChildForm(new InicioAnfitrionControl(idAnfitrion));
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnMisPropiedades_Click(object sender, EventArgs e)
        {
            openChildForm(new MisPropiedadesControl(idAnfitrion));
            //..
            //your codes
            //..
            hideSubMenu();
        }

        #region PlayListManagemetSubMenu
        private void button8_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnMensajes_Click(object sender, EventArgs e)
        {
            openChildForm(new MensajesAnfitrionControl(idAnfitrion));
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #region ToolsSubMenu
        private void button13_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnReservarRecibidas_Click(object sender, EventArgs e)
        {
            openChildForm(new ReservasRecibidasControl(idAnfitrion));
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            
            PanelUsuario panelUsuario = new PanelUsuario();
            panelUsuario.Show();

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
