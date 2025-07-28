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
    public partial class TipoResidencia : Form
    {
        public TipoResidencia()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            OpcionesAnfitrion opcionesAnfitrion = new OpcionesAnfitrion();
            opcionesAnfitrion.Show();
            this.Close();
        }

        private void btnEnviarResidencia_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Capturar el dato desde el TextBox
                string nombreTipo = txtTipoResidencia.Text.Trim();

                // 2. Validar que no esté vacío
                if (string.IsNullOrWhiteSpace(nombreTipo))
                {
                    MessageBox.Show("Por favor, ingresa un tipo de residencia.");
                    return;
                }

                // 3. Insertar en la base de datos
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    string query = "INSERT INTO TipoResidencia (NombreTipo) VALUES (@NombreTipo)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@NombreTipo", nombreTipo);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Tipo de residencia guardado correctamente.");

                // 4. Limpiar el TextBox
                txtTipoResidencia.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el tipo de residencia: " + ex.Message);
            }
        }

    }
}
