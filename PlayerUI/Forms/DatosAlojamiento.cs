using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerUI.Forms
{
    public partial class DatosAlojamiento : Form
    {
        private string rutaImagen = ""; // Variable de clase para guardar la ruta

        public DatosAlojamiento()
        {
            InitializeComponent();
            this.Load += DatosAlojamiento_Load; // Suscribo el evento Load
        }

        private void DatosAlojamiento_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    string query = "SELECT ID_TipoResidencia, NombreTipo FROM TipoResidencia";

                    SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbTipoResidencia.DataSource = dt;
                    cmbTipoResidencia.DisplayMember = "NombreTipo";  // Lo que ve el usuario
                    cmbTipoResidencia.ValueMember = "ID_TipoResidencia";  // El valor real
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando tipos de residencia: " + ex.Message);
            }
        }

        private void ptbImagenes_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Selecciona una imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    rutaImagen = openFileDialog.FileName;
                    ptbImagenes.Image = Image.FromFile(rutaImagen);
                    ptbImagenes.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Capturar datos de los TextBox
                string titulo = txtTitulo.Text;
                string descripcion = txtDescripcion.Text;
                string direccion = txtDireccion.Text;
                string reglas = txtReglas.Text;
                string servicios = txtServicios.Text;
                int numeroHabitaciones;

                // Validar que el número de habitaciones sea entero
                if (!int.TryParse(txtNumeroHabitaciones.Text, out numeroHabitaciones))
                {
                    MessageBox.Show("Ingrese un número válido en 'Número de habitaciones'.");
                    return;
                }

                // Verificar que haya una ruta de imagen válida
                if (string.IsNullOrWhiteSpace(rutaImagen))
                {
                    MessageBox.Show("Por favor, selecciona una imagen antes de guardar.");
                    return;
                }

                // Obtener el ID seleccionado del ComboBox
                int idTipoResidencia = Convert.ToInt32(cmbTipoResidencia.SelectedValue);

                // 3. Guardar en base de datos
                using (SqlConnection connection = Conexion.ObtenerConexion())
                {
                    string query = @"INSERT INTO Datos_Alojamiento 
                        (Titulo, Descripcion, Direccion, Reglas, Servicios, NumeroAbitaciones, Imagenes, ID_TipoResidencia)
                        VALUES (@Titulo, @Descripcion, @Direccion, @Reglas, @Servicios, @NumeroAbitaciones, @Imagenes, @ID_TipoResidencia)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Titulo", titulo);
                        cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                        cmd.Parameters.AddWithValue("@Direccion", direccion);
                        cmd.Parameters.AddWithValue("@Reglas", reglas);
                        cmd.Parameters.AddWithValue("@Servicios", servicios);
                        cmd.Parameters.AddWithValue("@NumeroAbitaciones", numeroHabitaciones);
                        cmd.Parameters.AddWithValue("@Imagenes", rutaImagen);
                        cmd.Parameters.AddWithValue("@ID_TipoResidencia", idTipoResidencia);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Datos guardados correctamente.");

                // Limpiar campos
                txtTitulo.Clear();
                txtDescripcion.Clear();
                txtDireccion.Clear();
                txtReglas.Clear();
                txtServicios.Clear();
                txtNumeroHabitaciones.Clear();
                ptbImagenes.Image = null;
                rutaImagen = "";
                cmbTipoResidencia.SelectedIndex = -1; // Opcional: deseleccionar ComboBox
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos: " + ex.Message);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            OpcionesAnfitrion opcionesAnfitrion = new OpcionesAnfitrion();
            opcionesAnfitrion.Show();
            this.Close();
        }
    }
}  

