using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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
            AgregarPropiedadForm agregarPropiedad = new AgregarPropiedadForm(idAnfitrion);
            agregarPropiedad.ShowDialog();
            if (agregarPropiedad.PropiedadAgregada)
            {
                CargarPropiedades();
            }
;
        }

        private void MisPropiedadesForm_Load(object sender, EventArgs e)
        {
            CargarPropiedades();
        }

        
        private class RoundedButton : Button
        {
            private int borderRadius = 15;
            private Color normalColor;
            private Color hoverColor;

            public RoundedButton(string text, Color backColor, Color hoverBackColor)
            {
                this.Text = text;
                this.normalColor = backColor;
                this.hoverColor = hoverBackColor;
                this.BackColor = normalColor;
                this.ForeColor = Color.White;
                this.FlatStyle = FlatStyle.Flat;
                this.FlatAppearance.BorderSize = 0;
                this.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                this.Width = 90;
                this.Height = 30;
                this.Margin = new Padding(5, 0, 0, 0);
                this.DoubleBuffered = true;

                this.MouseEnter += (s, e) => this.BackColor = hoverColor;
                this.MouseLeave += (s, e) => this.BackColor = normalColor;
            }

            protected override void OnPaint(PaintEventArgs pevent)
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = this.ClientRectangle;
                using (GraphicsPath path = GetRoundedRectanglePath(rect, borderRadius))
                {
                    this.Region = new Region(path);
                    using (SolidBrush brush = new SolidBrush(this.BackColor))
                    {
                        pevent.Graphics.FillPath(brush, path);
                    }
                    TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, rect, this.ForeColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
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

        private RoundedButton CrearBoton(string texto, Color colorFondo, Color colorHover)
        {
            return new RoundedButton(texto, colorFondo, colorHover);
        }

        private void CargarPropiedades()
        {

            flowLayoutPanelPropiedades.Controls.Clear();

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand(@"
                    SELECT Id_Propiedad, Nombre, Precio, RutaImagen 
                    FROM Propiedades 
                    WHERE IdAnfitrion = @id AND Activo = 1", con);

                cmd.Parameters.AddWithValue("@id", idAnfitrion);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idPropiedad = Convert.ToInt32(reader["Id_Propiedad"]);

                    
                    RoundedPanel card = new RoundedPanel
                    {
                        Width = 240,
                        Height = 275,
                        Margin = new Padding(10),
                        BorderRadius = 20,
                        BackColor = Color.Transparent,
                    };

                    
                    TableLayoutPanel layout = new TableLayoutPanel
                    {
                        Dock = DockStyle.Fill,
                        RowCount = 5,
                        ColumnCount = 1,
                        BackColor = Color.Transparent, 
                        Padding = new Padding(5)
                    };

                    layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100)); 
                    layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));  
                    layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));  
                    layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45));  
                    layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45));  

                    // Imagen
                    PictureBox pic = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Margin = new Padding(0),
                        BackColor = Color.Transparent 
                    };

                    string rutaImagen = reader["RutaImagen"].ToString();
                    pic.Image = File.Exists(rutaImagen)
                        ? Image.FromFile(rutaImagen)
                        : Properties.Resources.imagen_no_disponible;

                    // Info
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

                    Label lblEstado = new Label
                    {
                        Text = "Disponible",
                        Font = new Font("Segoe UI", 9, FontStyle.Regular),
                        ForeColor = Color.Green,
                        Dock = DockStyle.Top,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Margin = new Padding(0, 5, 0, 0),
                        BackColor = Color.Transparent
                    };

                    infoPanel.Controls.Add(lblEstado);
                    infoPanel.Controls.Add(lblNombre);

                    // Botones 1 (Editar, Ocultar)
                    FlowLayoutPanel botones1 = new FlowLayoutPanel
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

                    Button btnEditar = CrearBoton("Editar", Color.DodgerBlue, Color.RoyalBlue);
                    btnEditar.Click += (s, e) =>
                    {
                        AgregarPropiedadForm editarForm = new AgregarPropiedadForm(idAnfitrion, idPropiedad);
                        editarForm.ShowDialog();
                        if (editarForm.PropiedadAgregada)
                        {
                            CargarPropiedades();
                        }
                    };

                   

                    Button btnOcultar = CrearBoton("Ocultar", Color.Orange, Color.DarkOrange);

                    btnOcultar.Click += (s, e) =>
                    {
                        if (lblEstado.Text == "Disponible")
                        {
                            
                            using (SqlConnection conexion = Conexion.ObtenerConexion())
                            {
                                SqlCommand comandoDesactivar = new SqlCommand("UPDATE Propiedades SET Activo = 0 WHERE Id_Propiedad = @id", conexion);
                                comandoDesactivar.Parameters.AddWithValue("@id", idPropiedad);
                                comandoDesactivar.ExecuteNonQuery();
                            }

                            lblEstado.Text = "No disponible";
                            lblEstado.ForeColor = Color.Red;
                            btnOcultar.Text = "Mostrar";
                            btnOcultar.BackColor = Color.LightGray;
                            btnOcultar.ForeColor = Color.Black;
                        }
                        else
                        {
                            
                            using (SqlConnection conexion = Conexion.ObtenerConexion())
                            {
                                SqlCommand comandoActivar = new SqlCommand("UPDATE Propiedades SET Activo = 1 WHERE Id_Propiedad = @id", conexion);
                                comandoActivar.Parameters.AddWithValue("@id", idPropiedad);
                                comandoActivar.ExecuteNonQuery();
                            }

                            lblEstado.Text = "Disponible";
                            lblEstado.ForeColor = Color.Green;
                            btnOcultar.Text = "Ocultar";
                            btnOcultar.BackColor = Color.Orange;
                            btnOcultar.ForeColor = Color.White;
                        }
                    };


                    botones1.Controls.Add(btnEditar);
                    botones1.Controls.Add(btnOcultar);

                    
                    FlowLayoutPanel botones2 = new FlowLayoutPanel
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

                    Button btnEliminar = CrearBoton("Eliminar", Color.Crimson, Color.DarkRed);

                    btnEliminar.Click += (s, e) =>
                    {
                        if (MessageBox.Show("¿Seguro que quieres eliminar esta propiedad?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            try
                            {
                                using (SqlConnection conexion = Conexion.ObtenerConexion())
                                {
                                    SqlCommand cmdEliminar = new SqlCommand("DELETE FROM Propiedades WHERE Id_Propiedad = @id", conexion);
                                    cmdEliminar.Parameters.AddWithValue("@id", idPropiedad);
                                    cmdEliminar.ExecuteNonQuery();
                                }

                                flowLayoutPanelPropiedades.Controls.Remove(card);
                                card.Dispose();

                                MessageBox.Show("Propiedad eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al eliminar la propiedad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    };

                    botones2.Controls.Add(btnVisualizar);
                    botones2.Controls.Add(btnEliminar);

                    
                    layout.Controls.Add(pic, 0, 0);
                    layout.Controls.Add(infoPanel, 0, 1);
                    layout.Controls.Add(new Panel { BackColor = Color.Transparent }, 0, 2); 
                    layout.Controls.Add(botones1, 0, 3);
                    layout.Controls.Add(botones2, 0, 4);

                    
                    card.Controls.Add(layout);

                    
                    flowLayoutPanelPropiedades.Controls.Add(card);
                }

                reader.Close();
            }
        }
    }

    // Panel con bordes redondeados
    public class RoundedPanel : Panel
    {
        public int BorderRadius { get; set; } = 15;

        public RoundedPanel()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle bounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            using (var path = GetRoundedRectanglePath(bounds, BorderRadius))
            using (var brush = new SolidBrush(this.BackColor))
            using (var pen = new Pen(Color.LightGray, 1))
            {
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(pen, path);
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


