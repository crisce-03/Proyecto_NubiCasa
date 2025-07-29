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
        public bool PropiedadAgregada { get; private set; } = false;
        private string rutaImagenSeleccionada = "";

        public AgregarPropiedadForm(int id)
        {
            InitializeComponent();
            idAnfitrion = id;

            cbTipo.Items.AddRange(new string[] { "Casa", "Departamento", "Cabaña", "Estudio" });
            cbTipo.SelectedIndex = 0;
        }

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imágenes|*.jpg;*.png;*.jpeg";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaImagenSeleccionada = ofd.FileName;
                    pictureBoxImagen.Image = Image.FromFile(rutaImagenSeleccionada);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtUbicacion.Text) || string.IsNullOrEmpty(rutaImagenSeleccionada))
            {
                MessageBox.Show("Por favor, completa todos los campos obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardar en base de datos
            var cmd = new SqlCommand(@"INSERT INTO Propiedades (IdAnfitrion, Nombre, Tipo, Ubicacion, Precio, Capacidad, RutaImagen, Descripcion, Activo)
                                   VALUES (@idAnfitrion, @nombre, @tipo, @ubicacion, @precio, @capacidad, @ruta, @descripcion, 1)", Conexion.ObtenerConexion());

            cmd.Parameters.AddWithValue("@idAnfitrion", idAnfitrion);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@tipo", cbTipo.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@ubicacion", txtUbicacion.Text);
            cmd.Parameters.AddWithValue("@precio", numPrecio.Value);
            cmd.Parameters.AddWithValue("@capacidad", numCapacidad.Value);
            cmd.Parameters.AddWithValue("@ruta", GuardarImagenEnCarpeta(rutaImagenSeleccionada));
            cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);

            cmd.ExecuteNonQuery();

            PropiedadAgregada = true;
            MessageBox.Show("Propiedad agregada correctamente.", "Éxito");
            this.Close();
        }

        private string GuardarImagenEnCarpeta(string rutaOriginal)
        {
            string destinoCarpeta = Path.Combine(Application.StartupPath, "ImagenesPropiedades");
            if (!Directory.Exists(destinoCarpeta))
                Directory.CreateDirectory(destinoCarpeta);

            string nombreArchivo = Path.GetFileName(rutaOriginal);
            string rutaDestino = Path.Combine(destinoCarpeta, nombreArchivo);

            File.Copy(rutaOriginal, rutaDestino, overwrite: true);
            return rutaDestino; // ruta guardada en la base
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

