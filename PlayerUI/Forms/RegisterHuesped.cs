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

namespace PlayerUI.Forms
{
    public partial class RegisterHuesped : Form
    {
        public RegisterHuesped()
        {
            InitializeComponent();
        }

        private void panelDerecho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            LoginCopia LoginHuesped = new LoginCopia();
            LoginHuesped.Show();
            this.Close();
        }

        private void RegisterHuesped_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDUI.Text) ||
                string.IsNullOrWhiteSpace(txtNacionalidad.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtOcupacion.Text))
            {
                MessageBox.Show("Por favor, llená todos los campos antes de continuar.");
                return;
            }



            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    if (conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }
                    string query = "INSERT INTO Huesped (Nombre, Apellido, Dui, Nacionalidad, Telefono, Contrasena, Correo, Fecha_Nacimiento, Ocupacion) VALUES (@Nombre, @Apellido, @Dui, @Nacionalidad, @Telefono, @Contrasena, @Correo, @Fecha_Nacimiento, @Ocupacion)";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        comando.Parameters.AddWithValue("@Apellido", txtApellido.Text);
                        comando.Parameters.AddWithValue("@Dui", txtDUI.Text);
                        comando.Parameters.AddWithValue("@Nacionalidad", txtNacionalidad.Text);
                        comando.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                        comando.Parameters.AddWithValue("@Contrasena", txtContrasena.Text);
                        comando.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                        comando.Parameters.AddWithValue("@Fecha_Nacimiento", FechaNacimiento.Value.Date);
                        comando.Parameters.AddWithValue("@Ocupacion", txtOcupacion.Text);

                        int resultado = comando.ExecuteNonQuery();

                        if (resultado > 0)
                        {
                            MessageBox.Show("¡Registro exitoso!");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo registrar el usuario.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtDUI.Text = "";
                txtNacionalidad.Text = "";
                txtTelefono.Text = "";
                txtContrasena.Text = "";
                txtCorreo.Text = "";
                txtOcupacion.Text = "";
                FechaNacimiento.Value = DateTime.Now;
            }
        }
    }
}
