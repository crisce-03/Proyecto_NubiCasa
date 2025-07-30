using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PlayerUI.Forms;

namespace PlayerUI.Controlls
{
    public partial class BuscarPropiedadControl : Form
    {
        public BuscarPropiedadControl()
        {
            InitializeComponent();
            this.Load += BuscarPropiedadControl_Load;
        }

        private void BuscarPropiedadControl_Load(object sender, EventArgs e)
        {
            CargarPropiedadesDisponibles();
        }

        private void CargarPropiedadesDisponibles(string ubicacion = null, decimal? precioMin = null, decimal? precioMax = null, int? habitaciones = null, string tipoResidencia = null)
        {
            flowLayoutPanelBusqueda.Controls.Clear();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = @"SELECT Id_Propiedad, Nombre, Precio, RutaImagen, IdAnfitrion, Ubicacion, Capacidad, Tipo 
                                 FROM Propiedades 
                                 WHERE Activo = 1";

                List<string> condiciones = new List<string>();
                List<SqlParameter> parametros = new List<SqlParameter>();

                if (!string.IsNullOrWhiteSpace(ubicacion))
                {
                    condiciones.Add("Ubicacion LIKE @ubicacion");
                    parametros.Add(new SqlParameter("@ubicacion", "%" + ubicacion + "%"));
                }

                if (precioMin.HasValue && precioMax.HasValue)
                {
                    condiciones.Add("Precio BETWEEN @precioMin AND @precioMax");
                    parametros.Add(new SqlParameter("@precioMin", precioMin.Value));
                    parametros.Add(new SqlParameter("@precioMax", precioMax.Value));
                }

                if (habitaciones.HasValue)
                {
                    condiciones.Add("Capacidad = @habitaciones");
                    parametros.Add(new SqlParameter("@habitaciones", habitaciones.Value));
                }

                if (!string.IsNullOrWhiteSpace(tipoResidencia))
                {
                    condiciones.Add("Tipo = @tipoResidencia");
                    parametros.Add(new SqlParameter("@tipoResidencia", tipoResidencia));
                }

                if (condiciones.Count > 0)
                {
                    query += " AND " + string.Join(" AND ", condiciones);
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddRange(parametros.ToArray());

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idPropiedad = Convert.ToInt32(reader["Id_Propiedad"]);
                    int idAnfitrion = Convert.ToInt32(reader["IdAnfitrion"]);

                    RoundedPanel card = new RoundedPanel
                    {
                        Width = 240,
                        Height = 275,
                        Margin = new Padding(10),
                        BorderRadius = 20,
                        BackColor = Color.White,
                    };

                    TableLayoutPanel layout = new TableLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        RowCount = 4,
                        ColumnCount = 1,
                        BackColor = Color.Transparent,
                        Padding = new Padding(5)
                    };

                    layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
                    layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
                    layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                    layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45));

                    PictureBox pic = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Margin = new Padding(0),
                        BackColor = Color.Transparent
                    };

                    string rutaImagen = reader["RutaImagen"].ToString();
                    pic.Image = File.Exists(rutaImagen) ? Image.FromFile(rutaImagen) : Properties.Resources.imagen_no_disponible;

                    Panel infoPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.Transparent };

                    Label lblNombre = new Label
                    {
                        Text = reader["Nombre"].ToString(),
                        Font = new Font("Segoe UI", 11, FontStyle.Bold),
                        ForeColor = Color.Black,
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.Transparent
                    };

                    Label lblPrecio = new Label
                    {
                        Text = "$" + reader["Precio"] + " por noche",
                        Font = new Font("Segoe UI", 9, FontStyle.Regular),
                        ForeColor = Color.Gray,
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.Transparent
                    };

                    infoPanel.Controls.Add(lblPrecio);
                    infoPanel.Controls.Add(lblNombre);

                    FlowLayoutPanel botones = new FlowLayoutPanel
                    {
                        FlowDirection = FlowDirection.LeftToRight,
                        AutoSize = true,
                        AutoSizeMode = AutoSizeMode.GrowAndShrink,
                        BackColor = Color.Transparent,
                        Margin = new Padding(0),
                        Padding = new Padding(0),
                        Anchor = AnchorStyles.None,
                        WrapContents = false
                    };

                    Button btnVisualizar = CrearBoton("Visualizar", Color.SeaGreen, Color.MediumSeaGreen);
                    btnVisualizar.Click += (s, e) =>
                    {
                        AgregarPropiedadForm visualizarForm = new AgregarPropiedadForm(idAnfitrion, idPropiedad, soloLectura: true);
                        visualizarForm.ShowDialog();
                    };

                    Button btnReservar = CrearBoton("Reservar", Color.RoyalBlue, Color.MediumBlue);
                    botones.Controls.Add(btnVisualizar);
                    botones.Controls.Add(btnReservar);

                    layout.Controls.Add(pic, 0, 0);
                    layout.Controls.Add(infoPanel, 0, 1);
                    layout.Controls.Add(new Panel { BackColor = Color.Transparent }, 0, 2);
                    layout.Controls.Add(botones, 0, 3);

                    card.Controls.Add(layout);
                    flowLayoutPanelBusqueda.Controls.Add(card);
                }

                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ubicacion = textBox1.Text.Trim();
            string tipoResidencia = comboBox1.SelectedItem?.ToString();
            decimal? precioMin = numericUpDown1.Value;
            decimal? precioMax = numericUpDown2.Value;

            if (precioMin > precioMax)
            {
                MessageBox.Show("El precio mínimo no puede ser mayor que el máximo.", "Error de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? habitaciones = int.TryParse(textBox2.Text, out int result) ? result : (int?)null;

            CargarPropiedadesDisponibles(
                string.IsNullOrWhiteSpace(ubicacion) ? null : ubicacion,
                precioMin > 0 ? precioMin : null,
                precioMax > 0 ? precioMax : null,
                habitaciones,
                string.IsNullOrWhiteSpace(tipoResidencia) ? null : tipoResidencia
            );
        }

        private Button CrearBoton(string texto, Color colorFondo, Color colorHover)
        {
            Button btn = new Button
            {
                Text = texto,
                BackColor = colorFondo,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Width = 95,
                Height = 32,
                Font = new Font("Segoe UI", 9.75f, FontStyle.Bold),
                Margin = new Padding(5),
                Cursor = Cursors.Hand
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 20, 20));

            btn.MouseEnter += (s, e) => btn.BackColor = colorHover;
            btn.MouseLeave += (s, e) => btn.BackColor = colorFondo;

            return btn;
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }

    public class RoundedPanel : Panel
    {
        public int BorderRadius { get; set; } = 20;
        public Color ShadowColor { get; set; } = Color.FromArgb(40, 0, 0, 0);
        public int ShadowSize { get; set; } = 8;

        public RoundedPanel()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle bounds = new Rectangle(ShadowSize, ShadowSize, this.Width - ShadowSize * 2, this.Height - ShadowSize * 2);

            using (GraphicsPath path = GetRoundedRectanglePath(bounds, BorderRadius))
            {
                using (SolidBrush shadowBrush = new SolidBrush(ShadowColor))
                {
                    Rectangle shadowRect = new Rectangle(bounds.X + 2, bounds.Y + 2, bounds.Width, bounds.Height);
                    using (GraphicsPath shadowPath = GetRoundedRectanglePath(shadowRect, BorderRadius))
                    {
                        e.Graphics.FillPath(shadowBrush, shadowPath);
                    }
                }

                using (SolidBrush backgroundBrush = new SolidBrush(this.BackColor))
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



