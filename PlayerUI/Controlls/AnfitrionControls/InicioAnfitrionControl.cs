using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using PlayerUI.Forms;

namespace PlayerUI.Controlls.AnfitrionControls
{
    public partial class InicioAnfitrionControl : Form
    {
        private int idAnfitrion;

        public InicioAnfitrionControl(int Id_Anfitrion)
        {
            InitializeComponent();
            this.idAnfitrion = Id_Anfitrion;

            string nombreAnfitrion = cargarNombreAnfitrion(idAnfitrion);
            int num_Propiedades = contarPropiedades(idAnfitrion);

            lblBienAnfi.Text = $"¡Bienvenido {nombreAnfitrion}!";
            numPropiedades.Text = num_Propiedades.ToString();

            CargarReservasPendientes();
            CargarReservasAceptadas();
        }

        private void CargarReservasPendientes()
        {
            panel4.Controls.Clear();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    SELECT 
                        ISNULL(P.Nombre, 'Propiedad eliminada') AS Nombre,
                        ISNULL(P.RutaImagen, '') AS RutaImagen,
                        R.Id_Reservacion
                    FROM Reservas R
                    LEFT JOIN Propiedades P ON R.PropiedadId = P.Id_Propiedad
                    WHERE R.Estado = 'Pendiente' AND P.IdAnfitrion = @id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idAnfitrion);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader["Nombre"].ToString();
                            string rutaImagen = reader["RutaImagen"].ToString();

                            var tarjeta = CrearTarjetaReserva(nombre, rutaImagen, "Pendiente");
                            panel4.Controls.Add(tarjeta);
                        }
                    }
                }
            }
        }

        private void CargarReservasAceptadas()
        {
            panel5.Controls.Clear();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                string query = @"
                    SELECT 
                        ISNULL(P.Nombre, 'Propiedad eliminada') AS Nombre,
                        ISNULL(P.RutaImagen, '') AS RutaImagen,
                        R.Id_Reservacion
                    FROM Reservas R
                    LEFT JOIN Propiedades P ON R.PropiedadId = P.Id_Propiedad
                    WHERE R.Estado = 'Aceptada' AND P.IdAnfitrion = @id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idAnfitrion);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader["Nombre"].ToString();
                            string rutaImagen = reader["RutaImagen"].ToString();

                            var tarjeta = CrearTarjetaReserva(nombre, rutaImagen, "Aceptada");
                            panel5.Controls.Add(tarjeta);
                        }
                    }
                }
            }
        }

        private Panel CrearTarjetaReserva(string nombre, string rutaImagen, string estado)
        {
            var tarjeta = new RoundedPanel
            {
                Width = 250,
                Height = 270,
                BorderRadius = 20,
                Margin = new Padding(10),
                BackColor = Color.White
            };

            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1,
                Padding = new Padding(5)
            };

            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));

            PictureBox pic = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            try
            {
                if (!string.IsNullOrEmpty(rutaImagen) && File.Exists(rutaImagen))
                    pic.Image = Image.FromFile(rutaImagen);
                else
                    pic.Image = Properties.Resources.imagen_no_disponible;
            }
            catch
            {
                pic.Image = Properties.Resources.imagen_no_disponible;
            }

            var panelInfo = new Panel { Dock = DockStyle.Fill };

            var lblNombre = new Label
            {
                Text = nombre,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 25
            };

            var lblEstado = new Label
            {
                Text = estado,
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = estado == "Pendiente" ? Color.Orange : Color.Green,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 20
            };

            panelInfo.Controls.Add(lblEstado);
            panelInfo.Controls.Add(lblNombre);

            layout.Controls.Add(pic, 0, 0);
            layout.Controls.Add(panelInfo, 0, 1);
            layout.Controls.Add(new Panel(), 0, 2);

            tarjeta.Controls.Add(layout);
            return tarjeta;
        }

        public string cargarNombreAnfitrion(int Id_Anfitrion)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT Nombre FROM Anfitrion WHERE ID_Anfitrion = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", Id_Anfitrion);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            return reader["Nombre"].ToString();
                    }
                }
            }

            return "Anfitrión desconocido";
        }

        public int contarPropiedades(int Id_Anfitrion)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Propiedades WHERE IdAnfitrion = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", Id_Anfitrion);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        // Eventos vacíos para evitar errores
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void numPropiedades_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }

        // Clase de panel con bordes redondeados y sombra
        public class RoundedPanel : Panel
        {
            public int BorderRadius { get; set; } = 20;
            public Color ShadowColor { get; set; } = Color.FromArgb(40, 0, 0, 0);
            public int ShadowSize { get; set; } = 8;

            public RoundedPanel()
            {
                DoubleBuffered = true;
                BackColor = Color.White;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle bounds = new Rectangle(ShadowSize, ShadowSize, Width - ShadowSize * 2, Height - ShadowSize * 2);

                using (GraphicsPath path = GetRoundedRectanglePath(bounds, BorderRadius))
                {
                    // Sombra
                    using (SolidBrush shadowBrush = new SolidBrush(ShadowColor))
                    {
                        Rectangle shadowRect = new Rectangle(bounds.X + 2, bounds.Y + 2, bounds.Width, bounds.Height);
                        using (GraphicsPath shadowPath = GetRoundedRectanglePath(shadowRect, BorderRadius))
                        {
                            e.Graphics.FillPath(shadowBrush, shadowPath);
                        }
                    }

                    // Fondo
                    using (SolidBrush backgroundBrush = new SolidBrush(BackColor))
                    {
                        e.Graphics.FillPath(backgroundBrush, path);
                    }

                    // Borde
                    using (Pen borderPen = new Pen(Color.LightGray, 1))
                    {
                        e.Graphics.DrawPath(borderPen, path);
                    }
                }
            }

            private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
            {
                GraphicsPath path = new GraphicsPath();
                int diameter = radius * 2;

                path.StartFigure();
                path.AddArc(rect.Left, rect.Top, diameter, diameter, 180, 90);
                path.AddArc(rect.Right - diameter, rect.Top, diameter, diameter, 270, 90);
                path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
                path.AddArc(rect.Left, rect.Bottom - diameter, diameter, diameter, 90, 90);
                path.CloseFigure();

                return path;
            }
        }
    }
}


