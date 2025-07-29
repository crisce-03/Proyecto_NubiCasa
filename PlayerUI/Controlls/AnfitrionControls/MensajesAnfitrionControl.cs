using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PlayerUI.Controlls.AnfitrionControls
{
    public partial class MensajesAnfitrionControl : Form
    {
        private int anfitrionId;
        private string cadenaConexion = "Data Source=CRIS;Initial Catalog=Plater_UI;Integrated Security=True";

        public MensajesAnfitrionControl(int idAnfitrion)
        {
            InitializeComponent();
            anfitrionId = idAnfitrion;
            CargarReservas();
        }

        private void CargarReservas()
        {
            cbReservas.Items.Clear();

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                string query = @"
            SELECT R.Id_Reservacion, P.Nombre
            FROM Reservas R
            INNER JOIN Propiedades P ON R.PropiedadId = P.Id_Propiedad
            WHERE P.IdAnfitrion = @AnfitrionId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AnfitrionId", anfitrionId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idReserva = (int)reader["Id_Reservacion"];
                    string nombre = reader["Nombre"].ToString();
                    cbReservas.Items.Add(new ReservaItem { Id = idReserva, Nombre = nombre });
                }
            }
        }


        private void cbReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpMensajes.Controls.Clear();
            if (cbReservas.SelectedItem is ReservaItem item)
            {
                List<Mensaje> mensajes = ObtenerMensajes(item.Id);
                foreach (var msg in mensajes)
                {
                    AgregarBurbujaMensaje(msg);
                }
            }
        }

        private List<Mensaje> ObtenerMensajes(int reservacionId)
        {
            List<Mensaje> mensajes = new List<Mensaje>();


            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                string query = @"SELECT * FROM Mensajes WHERE ReservacionId = @Id ORDER BY FechaEnvio";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", reservacionId);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mensajes.Add(new Mensaje
                    {
                        IdMensaje = (int)reader["IdMensaje"],
                        ReservacionId = (int)reader["ReservacionId"],
                        EmisorId = (int)reader["EmisorId"],
                        TipoEmisor = reader["TipoEmisor"].ToString(),
                        Contenido = reader["Contenido"].ToString(),
                        FechaEnvio = (DateTime)reader["FechaEnvio"]
                    });
                }
            }

            return mensajes;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (cbReservas.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una reserva antes de enviar un mensaje.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir sin enviar nada
            }

            if (string.IsNullOrWhiteSpace(txtMensaje.Text))
            {
                MessageBox.Show("El mensaje no puede estar vacío.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var item = (ReservaItem)cbReservas.SelectedItem;
            string contenido = txtMensaje.Text.Trim();

            EnviarMensaje(item.Id, anfitrionId, "Anfitrion", contenido);
            txtMensaje.Clear();
            cbReservas_SelectedIndexChanged(null, null); // Refrescar mensajes
        }


        private void EnviarMensaje(int reservacionId, int emisorId, string tipoEmisor, string contenido)
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                string query = @"INSERT INTO Mensajes (ReservacionId, EmisorId, TipoEmisor, Contenido)
                                 VALUES (@ReservacionId, @EmisorId, @TipoEmisor, @Contenido)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ReservacionId", reservacionId);
                cmd.Parameters.AddWithValue("@EmisorId", emisorId);
                cmd.Parameters.AddWithValue("@TipoEmisor", tipoEmisor);
                cmd.Parameters.AddWithValue("@Contenido", contenido);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void AgregarBurbujaMensaje(Mensaje msg)
        {
            string prefijo = msg.TipoEmisor == "Anfitrion" ? "Tú" : "Huésped";
            string texto = $"[{msg.FechaEnvio:HH:mm}] {prefijo}: {msg.Contenido}";

            Label burbuja = new Label();
            burbuja.AutoSize = true;
            burbuja.MaximumSize = new Size(flpMensajes.Width - 50, 0);
            burbuja.Text = texto;
            burbuja.BackColor = msg.TipoEmisor == "Anfitrion" ? Color.LightGreen : Color.LightGray;
            burbuja.Padding = new Padding(10);
            burbuja.Margin = new Padding(5);
            burbuja.Font = new Font("Segoe UI", 10);
            burbuja.BorderStyle = BorderStyle.FixedSingle;

            Panel contenedor = new Panel();
            contenedor.AutoSize = true;
            contenedor.Dock = DockStyle.Top;
            contenedor.Padding = new Padding(5);
            contenedor.Width = flpMensajes.Width - 10;
            contenedor.Controls.Add(burbuja);

            // Alineación opcional (puedes mejorarla con anchoring si quieres)
            if (msg.TipoEmisor == "Anfitrion")
                burbuja.TextAlign = ContentAlignment.MiddleRight;
            else
                burbuja.TextAlign = ContentAlignment.MiddleLeft;

            flpMensajes.Controls.Add(contenedor);
        }
    }

    public class ReservaItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public override string ToString() => Nombre;
    }

    public class Mensaje
    {
        public int IdMensaje { get; set; }
        public int ReservacionId { get; set; }
        public int EmisorId { get; set; }
        public string TipoEmisor { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaEnvio { get; set; }
    }
}
