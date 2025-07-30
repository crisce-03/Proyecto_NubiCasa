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

namespace PlayerUI
{
    public partial class Form1 : Form
    {
        private int idHuesped;

        public Form1(int ID_Huesped)
        {
            InitializeComponent();
            this.idHuesped = ID_Huesped;
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            // Oculta todos los submenús si tuvieras
        }

        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            openChildForm(new InicioHuespedControl(idHuesped)); // CORREGIDO
            hideSubMenu();
        }

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            openChildForm(new BuscarPropiedadControl());
            hideSubMenu();
        }

        #region PlayListManagementSubMenu
        private void button8_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        #endregion

        private void btnTools_Click(object sender, EventArgs e)
        {
            openChildForm(new MisReservasControl(idHuesped));
            hideSubMenu();
        }

        #region ToolsSubMenu
        private void button13_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        #endregion

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
            openChildForm(new InicioHuespedControl(idHuesped)); // CORREGIDO
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
            if (activeForm != null)
                activeForm.Close();

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
            // Puedes agregar lógica inicial si se requiere
        }
    }
}


