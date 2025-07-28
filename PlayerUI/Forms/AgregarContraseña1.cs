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
    public partial class AgregarContraseña1 : Form
    {
        public AgregarContraseña1()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            LoginAnfitrion loginAnfitrion = new LoginAnfitrion();
            loginAnfitrion.Show();
            this.Close();
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            string Correo = txtCorreo.Text.Trim();
            string nuevaContrasena = txtContraseña.Text.Trim();
            string confirmarContrasena = txtConfirmarContraseña.Text.Trim();

            if (nuevaContrasena != confirmarContrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(Correo) || string.IsNullOrEmpty(nuevaContrasena))
            {
                MessageBox.Show("Debe completar todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conexion = Conexion.ObtenerConexion())
            {
                string consulta = "UPDATE Anfitrion SET Contrasena = @Contrasena WHERE Correo = @Correo";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Contrasena", nuevaContrasena);
                comando.Parameters.AddWithValue("@Correo", Correo);

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Contraseña actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    LoginAnfitrion loginAnfitrion = new LoginAnfitrion();
                    loginAnfitrion.Show();


                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se encontró el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
