using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PlayerUI.Forms;

namespace PlayerUI.Controlls
{
    public partial class MisReservasControl: Form
    {
        private int idHuesped;

        public MisReservasControl(int idHuesped)
        {
            InitializeComponent();
            this.idHuesped = idHuesped;
            this.Load += ReservasHuespedControl_Load;
            btnEliminarReserva.Click += btnEliminarReserva_Click;
        }

        private void ReservasHuespedControl_Load(object sender, EventArgs e)
        {

            cbEstados.Items.Add("Todos");
            cbEstados.Items.Add("Pendiente");
            cbEstados.Items.Add("Aceptada");
            cbEstados.Items.Add("Rechazada");
            cbEstados.SelectedIndex = 0; 

            cbEstados.SelectedIndexChanged += cbEstados_SelectedIndexChanged;

            CargarReservas();
        }

        private void cbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReservas();
        }



        private void CargarReservas()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = @"
            SELECT 
                R.Id_Reservacion,
                P.Nombre AS Propiedad,
                R.FechaEntrada,
                R.FechaSalida,
                R.Personas,
                R.PrecioTotal,
                R.Estado,
                R.FechaReserva
            FROM Reservas R
            INNER JOIN Propiedades P ON R.PropiedadId = P.Id_Propiedad
            WHERE R.HuespedId = @idHuesped";

                // Si se selecciona un estado específico (distinto de "Todos")
                if (cbEstados.SelectedItem != null && cbEstados.SelectedItem.ToString() != "Todos")
                {
                    query += " AND R.Estado = @estado";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idHuesped", idHuesped);

                if (cbEstados.SelectedItem != null && cbEstados.SelectedItem.ToString() != "Todos")
                {
                    cmd.Parameters.AddWithValue("@estado", cbEstados.SelectedItem.ToString());
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMisReservas.DataSource = dt;

                // Opcional: Formato
                dgvMisReservas.Columns["PrecioTotal"].DefaultCellStyle.Format = "C2";
                dgvMisReservas.Columns["FechaEntrada"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvMisReservas.Columns["FechaSalida"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvMisReservas.Columns["FechaReserva"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
            }
        }


        private void btnEliminarReserva_Click(object sender, EventArgs e)
        {
            if (dgvMisReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una reserva para cancelar.");
                return;
            }

            int idReserva = Convert.ToInt32(dgvMisReservas.SelectedRows[0].Cells["Id_Reservacion"].Value);

            DialogResult confirm = MessageBox.Show("¿Estás seguro de cancelar esta reserva?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string deleteQuery = "DELETE FROM Reservas WHERE Id_Reservacion = @id";

                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@id", idReserva);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Reserva cancelada.");
            CargarReservas(); // refrescar el datagrid
        }

        private void dgvMisReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
