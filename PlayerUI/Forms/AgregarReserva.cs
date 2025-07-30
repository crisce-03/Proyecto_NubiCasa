using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PlayerUI.Forms
{
    public partial class AgregarReserva : Form
    {
        private int idPropiedad;
        private int idAnfitrion;
        private decimal precioPorNoche;
        private int capacidad;

        public AgregarReserva(int idAnfitrion, int idPropiedad)
        {
            InitializeComponent();
            this.idAnfitrion = idAnfitrion;
            this.idPropiedad = idPropiedad;

            this.Load += AgregarReserva_Load;

            // Eventos para actualizar el total cuando termina de seleccionar la fecha
            this.dtpEntrada.CloseUp += (s, e) => ActualizarFechasYTotal();
            this.dtpSalida.CloseUp += (s, e) => CalcularPrecioTotal();

            this.dtpEntrada.Leave += (s, e) => ActualizarFechasYTotal();
            this.dtpSalida.Leave += (s, e) => CalcularPrecioTotal();
        }

        private void AgregarReserva_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = "SELECT Nombre, Ubicacion, Precio, Capacidad FROM Propiedades WHERE Id_Propiedad = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", idPropiedad);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string nombre = reader["Nombre"].ToString();
                    string ubicacion = reader["Ubicacion"].ToString();
                    precioPorNoche = Convert.ToDecimal(reader["Precio"]);
                    capacidad = Convert.ToInt32(reader["Capacidad"]);

                    lblPropiedad.Text = $"{nombre} ({ubicacion})";
                    lblPrecioPorNoche.Text = $"${precioPorNoche:F2}";
                    nudHuespedes.Maximum = capacidad;

                    dtpEntrada.MinDate = DateTime.Today;
                    dtpSalida.MinDate = DateTime.Today.AddDays(1);
                }

                reader.Close();
            }

            dtpEntrada.Value = DateTime.Today;
            dtpSalida.Value = DateTime.Today.AddDays(1);
            CalcularPrecioTotal();
        }

        private void ActualizarFechasYTotal()
        {
            dtpSalida.MinDate = dtpEntrada.Value.AddDays(1);
            CalcularPrecioTotal();
        }

        private void CalcularPrecioTotal()
        {
            DateTime entrada = dtpEntrada.Value.Date;
            DateTime salida = dtpSalida.Value.Date;

            if (salida > entrada)
            {
                int noches = (salida - entrada).Days;
                decimal total = noches * precioPorNoche;
                lblTotal.Text = $"${total:F2}";
            }
            else
            {
                lblTotal.Text = "$0.00";
            }
        }
    


        private void btnReservar_Click(object sender, EventArgs e)
        {
            DateTime entrada = dtpEntrada.Value.Date;
            DateTime salida = dtpSalida.Value.Date;
            int huespedes = (int)nudHuespedes.Value;

            if (salida <= entrada)
            {
                MessageBox.Show("La fecha de salida debe ser posterior a la de entrada.", "Fechas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int noches = (salida - entrada).Days;
            decimal total = noches * precioPorNoche;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = @"INSERT INTO Reservas 
                                 (PropiedadId, HuespedId, FechaEntrada, FechaSalida, Personas, PrecioTotal, Estado, FechaReserva)
                                 VALUES 
                                 (@PropiedadId, @HuespedId, @FechaEntrada, @FechaSalida, @Personas, @PrecioTotal, 'Pendiente', GETDATE())";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@PropiedadId", idPropiedad);
                cmd.Parameters.AddWithValue("@HuespedId", ObtenerIdHuesped()); // <-- Personaliza según tu login
                cmd.Parameters.AddWithValue("@FechaEntrada", entrada);
                cmd.Parameters.AddWithValue("@FechaSalida", salida);
                cmd.Parameters.AddWithValue("@Personas", huespedes);
                cmd.Parameters.AddWithValue("@PrecioTotal", total);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("¡Reserva realizada exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int ObtenerIdHuesped()
        {
            // Reemplaza esto con tu lógica de sesión/login
            return 1; // Simulado por ahora
        }
    
}
}




