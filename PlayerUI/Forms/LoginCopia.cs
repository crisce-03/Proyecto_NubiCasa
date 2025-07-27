using PlayerUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI
{
    public partial class LoginCopia : Form
    {
        public LoginCopia()
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
            AgregarContraseña2 olvidarContraseña = new AgregarContraseña2();
            olvidarContraseña.Show();
            this.Hide();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text.Trim();

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string consulta = "SELECT COUNT(*) FROM Huesped WHERE Nombre = @Nombre AND Contrasena = @Contrasena";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Nombre", usuario);
                comando.Parameters.AddWithValue("@Contrasena", contrasena);

                int resultado = (int)comando.ExecuteScalar();

                if (resultado > 0)
                {
                    MessageBox.Show("Inicio de sesión exitoso", "Bienvenido");

                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error");
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
