using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PlayerUI.Forms;

namespace PlayerUI
{
    public partial class InicioHuespedControl : Form
    {
        private int idHuesped;

        public InicioHuespedControl(int idHuesped)
        {
            InitializeComponent();
            this.idHuesped = idHuesped;

            CargarBienvenida();
            CargarReservas();
            CargarRecomendaciones();
            CargarNotificaciones();
        }

        private void CargarBienvenida()
        {
            // lblBienvenida.Text = $"Hola, Cristopher 👋";
        }

        private void CargarReservas()
        {
            flowLayoutPanel2.Controls.Clear();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = @"
                    SELECT P.Id_Propiedad, P.Nombre, P.Precio, P.RutaImagen, P.IdAnfitrion
                    FROM Reservas R
                    INNER JOIN Propiedades P ON R.PropiedadId = P.Id_Propiedad
                    WHERE R.HuespedId = @idHuesped AND R.Estado = 'Aceptada'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idHuesped", idHuesped);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idPropiedad = Convert.ToInt32(reader["Id_Propiedad"]);
                    int idAnfitrion = Convert.ToInt32(reader["IdAnfitrion"]);

                    var card = new PanelRedondeado
                    {
                        Width = 240,
                        Height = 270,
                        Margin = new Padding(10),
                        BorderRadius = 20,
                        BackColor = Color.White
                    };

                    var layout = new TableLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        RowCount = 3,
                        ColumnCount = 1,
                        Padding = new Padding(5),
                        BackColor = Color.Transparent
                    };

                    layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
                    layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                    layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45));

                    var pic = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = Color.Transparent
                    };

                    string rutaImagen = reader["RutaImagen"].ToString();
                    pic.Image = File.Exists(rutaImagen) ? Image.FromFile(rutaImagen) : Properties.Resources.imagen_no_disponible;

                    var infoPanel = new Panel { Dock = DockStyle.Fill };

                    var lblNombre = new Label
                    {
                        Text = reader["Nombre"].ToString(),
                        Font = new Font("Segoe UI", 11, FontStyle.Bold),
                        ForeColor = Color.Black,
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    var lblPrecio = new Label
                    {
                        Text = "$" + reader["Precio"] + " por noche",
                        Font = new Font("Segoe UI", 9),
                        ForeColor = Color.Gray,
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter
                    };

                    infoPanel.Controls.Add(lblPrecio);
                    infoPanel.Controls.Add(lblNombre);

                    var panelBoton = new FlowLayoutPanel
                    {
                        FlowDirection = FlowDirection.LeftToRight,
                        AutoSize = true,
                        AutoSizeMode = AutoSizeMode.GrowAndShrink,
                        Dock = DockStyle.Fill,
                        BackColor = Color.Transparent,
                        Padding = new Padding(0),
                        WrapContents = false
                    };

                    var btnVisualizar = CrearBoton("Visualizar", Color.SeaGreen, Color.MediumSeaGreen);
                    btnVisualizar.Click += (s, e) =>
                    {
                        var form = new AgregarPropiedadForm(idAnfitrion, idPropiedad, soloLectura: true);
                        form.ShowDialog();
                    };

                    panelBoton.Controls.Add(btnVisualizar);

                    layout.Controls.Add(pic, 0, 0);
                    layout.Controls.Add(infoPanel, 0, 1);
                    layout.Controls.Add(panelBoton, 0, 2);

                    card.Controls.Add(layout);
                    flowLayoutPanel2.Controls.Add(card);
                }

                reader.Close();
            }
        }

        private void CargarRecomendaciones() { }

        private void CargarNotificaciones() { }

        private Button CrearBoton(string texto, Color colorFondo, Color colorHover)
        {
            var btn = new Button
            {
                Text = texto,
                BackColor = colorFondo,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 120,
                Height = 35,
                Font = new Font("Segoe UI", 9.75f, FontStyle.Bold),
                Margin = new Padding(10),
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 20, 20));
            btn.MouseEnter += (s, e) => btn.BackColor = colorHover;
            btn.MouseLeave += (s, e) => btn.BackColor = colorFondo;

            return btn;
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );
    }

    public class PanelRedondeado : Panel
    {
        public int BorderRadius { get; set; } = 20;
        public Color ShadowColor { get; set; } = Color.FromArgb(50, 0, 0, 0);
        public int ShadowSize { get; set; } = 8;

        public PanelRedondeado()
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
                using (SolidBrush shadowBrush = new SolidBrush(ShadowColor))
                {
                    Rectangle shadowRect = new Rectangle(bounds.X + 3, bounds.Y + 3, bounds.Width, bounds.Height);
                    using (GraphicsPath shadowPath = GetRoundedRectanglePath(shadowRect, BorderRadius))
                    {
                        e.Graphics.FillPath(shadowBrush, shadowPath);
                    }
                }

                using (SolidBrush backgroundBrush = new SolidBrush(BackColor))
                {
                    e.Graphics.FillPath(backgroundBrush, path);
                }

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
