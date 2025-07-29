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
using PlayerUI.Forms;

namespace PlayerUI.Controlls.AnfitrionControls
{
    public partial class MisPropiedadesControl : Form
    {
        private int idAnfitrion;

        public MisPropiedadesControl(int ID_Anfitrion)
        {
            InitializeComponent();
            idAnfitrion = ID_Anfitrion;
    
        }

        private void btnAgregarPropiedad_Click(object sender, EventArgs e)
        {
            AgregarPropiedadForm agregarPropiedad =new  AgregarPropiedadForm(idAnfitrion);
            agregarPropiedad.Show();
        }

        private void MisPropiedadesForm_Load(object sender, EventArgs e)
        {
            CargarPropiedades();
        }


        private void CargarPropiedades()
        {
            flowLayoutPanelPropiedades.Controls.Clear();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT Id_Propiedad, Nombre, Precio, RutaImagen 
            FROM Propiedades 
            WHERE IdAnfitrion = @id AND Activo = 1", con); // muestra solo activos

                cmd.Parameters.AddWithValue("@id", idAnfitrion);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Crear tarjeta (panel)
                    Panel card = new Panel();
                    card.Width = 200;
                    card.Height = 250;
                    card.Margin = new Padding(10);
                    card.BorderStyle = BorderStyle.FixedSingle;

                    // Imagen
                    PictureBox pic = new PictureBox();
                    pic.Width = 180;
                    pic.Height = 100;
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Top = 10;
                    pic.Left = 10;

                    string rutaImagen = reader["RutaImagen"].ToString();
                    if (File.Exists(rutaImagen))
                    {
                        pic.Image = Image.FromFile(rutaImagen);
                    }
                    else
                    {
                        // Imagen por defecto si no existe la ruta
                        pic.Image = Properties.Resources.imagen_no_disponible; // agrega esta imagen a tus recursos si deseas
                    }

                    // Nombre
                    Label lblNombre = new Label();
                    lblNombre.Text = reader["Nombre"].ToString();
                    lblNombre.Top = 120;
                    lblNombre.Left = 10;
                    lblNombre.Width = 180;

                    // Precio
                    Label lblPrecio = new Label();
                    lblPrecio.Text = $"${reader["Precio"]} / noche";
                    lblPrecio.Top = 145;
                    lblPrecio.Left = 10;
                    lblPrecio.Width = 180;

                    // Botón Editar
                    Button btnEditar = new Button();
                    btnEditar.Text = "Editar";
                    btnEditar.Top = 180;
                    btnEditar.Left = 10;
                    btnEditar.Width = 80;
                    // opcional: agregar evento click para editar

                    // Botón Ocultar
                    Button btnOcultar = new Button();
                    btnOcultar.Text = "Ocultar";
                    btnOcultar.Top = 180;
                    btnOcultar.Left = 100;
                    btnOcultar.Width = 80;
                    // opcional: evento click para desactivar la propiedad

                    // Agregar controles al panel
                    card.Controls.Add(pic);
                    card.Controls.Add(lblNombre);
                    card.Controls.Add(lblPrecio);
                    card.Controls.Add(btnEditar);
                    card.Controls.Add(btnOcultar);

                    // Agregar el panel al FlowLayout
                    flowLayoutPanelPropiedades.Controls.Add(card);
                }

                reader.Close();
            }
        }


    }

}
