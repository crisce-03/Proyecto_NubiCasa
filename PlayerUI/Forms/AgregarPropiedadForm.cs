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
    public partial class AgregarPropiedadForm : Form
    {
        private int idAnfitrion;
        private int? idPropiedad = null;
        public bool PropiedadAgregada { get; private set; } = false;
        private string rutaImagenSeleccionada = "";
        private string rutaImagenActual;
        private bool soloLectura;

        public AgregarPropiedadForm(int idAnfitrion, int? idPropiedad = null, bool soloLectura = false)
        {
            InitializeComponent();
            this.idAnfitrion = idAnfitrion;
            this.idPropiedad = idPropiedad;
            this.soloLectura = soloLectura;
            cbTipo.Items.AddRange(new string[] { "Casa", "Departamento", "Cabaña", "Estudio" });
            cbTipo.SelectedIndex = 0;

            if (idPropiedad.HasValue)
                CargarDatosPropiedad(idPropiedad.Value);

            if (soloLectura)
                EstablecerSoloLectura();
        }

        private void CargarDatosPropiedad(int id)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Propiedades WHERE Id_Propiedad = @id", con);
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtNombre.Text = reader["Nombre"].ToString();
                        cbTipo.SelectedItem = reader["Tipo"].ToString();
                        txtUbicacion.Text = reader["Ubicacion"].ToString();
                        numPrecio.Value = Convert.ToDecimal(reader["Precio"]);
                        numCapacidad.Value = Convert.ToInt32(reader["Capacidad"]);
                        txtDescripcion.Text = reader["Descripcion"].ToString();
                        rutaImagenActual = reader["RutaImagen"].ToString();

                        if (File.Exists(rutaImagenActual))
                        {
                            using (var imgTemp = Image.FromFile(rutaImagenActual))
                            {
                                pictureBoxImagen.Image = new Bitmap(imgTemp); 
                            }
                        }
                    }
                }
            }
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.jpg;*.png;*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaImagenSeleccionada = ofd.FileName;

                    using (var imgTemp = Image.FromFile(rutaImagenSeleccionada))
                    {
                        pictureBoxImagen.Image = new Bitmap(imgTemp); 
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUbicacion.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string rutaFinal = rutaImagenActual;

            if (!string.IsNullOrEmpty(rutaImagenSeleccionada) &&
                File.Exists(rutaImagenSeleccionada) &&
                rutaImagenSeleccionada != rutaImagenActual)
            {
                rutaFinal = GuardarImagenEnCarpeta(rutaImagenSeleccionada);
            }

            SqlCommand cmd;

            if (idPropiedad.HasValue)
            {
                cmd = new SqlCommand(@"
                    UPDATE Propiedades SET
                        Nombre = @nombre,
                        Tipo = @tipo,
                        Ubicacion = @ubicacion,
                        Precio = @precio,
                        Capacidad = @capacidad,
                        RutaImagen = @ruta,
                        Descripcion = @descripcion
                    WHERE Id_Propiedad = @idPropiedad", Conexion.ObtenerConexion());

                cmd.Parameters.AddWithValue("@idPropiedad", idPropiedad.Value);
            }
            else
            {
                cmd = new SqlCommand(@"
                    INSERT INTO Propiedades (IdAnfitrion, Nombre, Tipo, Ubicacion, Precio, Capacidad, RutaImagen, Descripcion, Activo)
                    VALUES (@idAnfitrion, @nombre, @tipo, @ubicacion, @precio, @capacidad, @ruta, @descripcion, 1)", Conexion.ObtenerConexion());

                cmd.Parameters.AddWithValue("@idAnfitrion", idAnfitrion);
            }

            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@tipo", cbTipo.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@ubicacion", txtUbicacion.Text);
            cmd.Parameters.AddWithValue("@precio", numPrecio.Value);
            cmd.Parameters.AddWithValue("@capacidad", numCapacidad.Value);
            cmd.Parameters.AddWithValue("@ruta", rutaFinal);
            cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);

            cmd.ExecuteNonQuery();

            PropiedadAgregada = true;
            MessageBox.Show(idPropiedad.HasValue ? "Propiedad actualizada correctamente." : "Propiedad agregada correctamente.", "Éxito");
            this.Close();
        }

        private string GuardarImagenEnCarpeta(string rutaOriginal)
        {
            string destinoCarpeta = Path.Combine(Application.StartupPath, "ImagenesPropiedades");
            if (!Directory.Exists(destinoCarpeta))
                Directory.CreateDirectory(destinoCarpeta);

            string nombreArchivo = Path.GetFileName(rutaOriginal);
            string rutaDestino = Path.Combine(destinoCarpeta, nombreArchivo);

            
            if (!rutaOriginal.Equals(rutaDestino, StringComparison.OrdinalIgnoreCase))
            {
                File.Copy(rutaOriginal, rutaDestino, overwrite: true);
            }

            return rutaDestino;
        }

        private void EstablecerSoloLectura()
        {
            txtNombre.ReadOnly = true;
            cbTipo.Enabled = false;
            txtUbicacion.ReadOnly = true;
            numPrecio.Enabled = false;
            numCapacidad.Enabled = false;
            txtDescripcion.ReadOnly = true;
            pictureBoxImagen.Enabled = false;
            btnSeleccionarImagen.Enabled = false;
            btnGuardar.Visible = false; // Oculta botón Guardar
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



