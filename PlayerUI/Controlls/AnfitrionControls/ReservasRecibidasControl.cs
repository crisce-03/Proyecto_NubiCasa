using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using PlayerUI.Forms;

namespace PlayerUI.Controlls
{
    public partial class ReservasRecibidasControl : Form
    {
        private int idAnfitrion;

        public ReservasRecibidasControl(int idAnfitrion)
        {
            InitializeComponent();
            this.idAnfitrion = idAnfitrion;

            this.Load += ReservasRecibidasControl_Load;

            btnAceptar.Click += btnAceptar_Click;
            btnRechazar.Click += btnRechazar_Click;

            dgvReservas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservas.MultiSelect = false;
            dgvReservas.SelectionChanged += DgvReservas_SelectionChanged;
        }

        private void ReservasRecibidasControl_Load(object sender, EventArgs e)
        {

            cbEstados.Items.Add("Todos");
            cbEstados.Items.Add("Pendiente");
            cbEstados.Items.Add("Aceptada");
            cbEstados.Items.Add("Rechazada");
            cbEstados.SelectedIndex = 0;

            cbEstados.SelectedIndexChanged += cbEstados_SelectedIndexChanged;

            CargarReservas();
            ActualizarBotonesEstado();
        }

        private void cbEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarReservas();
            ActualizarBotonesEstado();
        }


        private void CargarReservas()
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                string query = @"
            SELECT 
                R.Id_Reservacion,
                P.Nombre AS Propiedad,
                R.HuespedId,
                R.FechaEntrada,
                R.FechaSalida,
                R.Personas,
                R.PrecioTotal,
                R.Estado,
                R.FechaReserva
            FROM Reservas R
            INNER JOIN Propiedades P ON R.PropiedadId = P.Id_Propiedad
            WHERE P.IdAnfitrion = @idAnfitrion
        ";

                if (cbEstados.SelectedItem != null && cbEstados.SelectedItem.ToString() != "Todos")
                {
                    query += " AND R.Estado = @estado";
                }

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idAnfitrion", idAnfitrion);

                if (cbEstados.SelectedItem != null && cbEstados.SelectedItem.ToString() != "Todos")
                {
                    cmd.Parameters.AddWithValue("@estado", cbEstados.SelectedItem.ToString());
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvReservas.DataSource = dt;

                if (dgvReservas.Columns.Contains("PrecioTotal"))
                    dgvReservas.Columns["PrecioTotal"].DefaultCellStyle.Format = "C2";

                if (dgvReservas.Columns.Contains("FechaEntrada"))
                    dgvReservas.Columns["FechaEntrada"].DefaultCellStyle.Format = "dd/MM/yyyy";

                if (dgvReservas.Columns.Contains("FechaSalida"))
                    dgvReservas.Columns["FechaSalida"].DefaultCellStyle.Format = "dd/MM/yyyy";

                if (dgvReservas.Columns.Contains("FechaReserva"))
                    dgvReservas.Columns["FechaReserva"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una reserva primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgvReservas.SelectedRows[0];
            int idReserva = Convert.ToInt32(fila.Cells["Id_Reservacion"].Value);
            string estadoActual = fila.Cells["Estado"].Value.ToString();

            if (estadoActual == "Aceptada")
            {
                MessageBox.Show("Esta reserva ya fue aceptada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CambiarEstadoReserva(idReserva, "Aceptada");
        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una reserva primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgvReservas.SelectedRows[0];
            int idReserva = Convert.ToInt32(fila.Cells["Id_Reservacion"].Value);
            string estadoActual = fila.Cells["Estado"].Value.ToString();

            if (estadoActual == "Rechazada")
            {
                MessageBox.Show("Esta reserva ya fue rechazada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CambiarEstadoReserva(idReserva, "Rechazada");
        }

        private void CambiarEstadoReserva(int idReserva, string nuevoEstado)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {
                // Si el nuevo estado es "Aceptada", validar que no haya otra reserva aceptada para esa propiedad
                if (nuevoEstado == "Aceptada")
                {
                    string obtener_Propiedad = "SELECT PropiedadId FROM Reservas WHERE Id_Reservacion = @id";
                    SqlCommand cmd_GetPropiedad = new SqlCommand(obtener_Propiedad, con);
                    cmd_GetPropiedad.Parameters.AddWithValue("@id", idReserva);
                    int id_Propiedad = (int)cmd_GetPropiedad.ExecuteScalar();

                    string validarReservaAceptada = @"
                SELECT COUNT(*) FROM Reservas 
                WHERE PropiedadId = @idPropiedad AND Estado = 'Aceptada'
            ";
                    SqlCommand cmdValidar = new SqlCommand(validarReservaAceptada, con);
                    cmdValidar.Parameters.AddWithValue("@idPropiedad", id_Propiedad);

                    int cantidadAceptadas = (int)cmdValidar.ExecuteScalar();

                    if (cantidadAceptadas > 0)
                    {
                        MessageBox.Show("Ya existe una reserva aceptada para esta propiedad.", "No permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // No se cambia el estado
                    }

                    // Si no hay otra aceptada, bloquea la propiedad
                    string bloquearPropiedad = "UPDATE Propiedades SET Activo = 0 WHERE Id_Propiedad = @idPropiedad";
                    SqlCommand cmdBloquear = new SqlCommand(bloquearPropiedad, con);
                    cmdBloquear.Parameters.AddWithValue("@idPropiedad", id_Propiedad);
                    cmdBloquear.ExecuteNonQuery();
                }

                // Actualizar estado
                string query = "UPDATE Reservas SET Estado = @estado WHERE Id_Reservacion = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@estado", nuevoEstado);
                cmd.Parameters.AddWithValue("@id", idReserva);
                cmd.ExecuteNonQuery();

                // Obtener el id de la propiedad relacionada con la reserva
                string obtenerPropiedad = "SELECT PropiedadId FROM Reservas WHERE Id_Reservacion = @id";
                SqlCommand cmdGetPropiedad = new SqlCommand(obtenerPropiedad, con);
                cmdGetPropiedad.Parameters.AddWithValue("@id", idReserva);
                int idPropiedad = (int)cmdGetPropiedad.ExecuteScalar();

                // Revisar si quedan reservas aceptadas para esa propiedad
                string verificarAceptadas = @"
                SELECT COUNT(*) FROM Reservas
                WHERE PropiedadId = @idPropiedad AND Estado = 'Aceptada'";
                SqlCommand cmdVerificar = new SqlCommand(verificarAceptadas, con);
                cmdVerificar.Parameters.AddWithValue("@idPropiedad", idPropiedad);
                int aceptadasRestantes = (int)cmdVerificar.ExecuteScalar();

                // Si ya no hay reservas aceptadas, reactivar la propiedad
                if (aceptadasRestantes == 0)
                {
                    string activarPropiedad = "UPDATE Propiedades SET Activo = 1 WHERE Id_Propiedad = @idPropiedad";
                    SqlCommand cmdActivar = new SqlCommand(activarPropiedad, con);
                    cmdActivar.Parameters.AddWithValue("@idPropiedad", idPropiedad);
                    cmdActivar.ExecuteNonQuery();
                }

            }

            CargarReservas();
            ActualizarBotonesEstado();
        }


        private void BloquearPropiedad(int idReserva, SqlConnection con)
        {
            string obtenerPropiedad = "SELECT PropiedadId FROM Reservas WHERE Id_Reservacion = @id";
            SqlCommand cmdGet = new SqlCommand(obtenerPropiedad, con);
            cmdGet.Parameters.AddWithValue("@id", idReserva);

            int idPropiedad = (int)cmdGet.ExecuteScalar();

            string bloquearPropiedad = "UPDATE Propiedades SET Activo = 0 WHERE Id_Propiedad = @idPropiedad";
            SqlCommand cmdUpdate = new SqlCommand(bloquearPropiedad, con);
            cmdUpdate.Parameters.AddWithValue("@idPropiedad", idPropiedad);

            cmdUpdate.ExecuteNonQuery();
        }

        private void DgvReservas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonesEstado();
        }

        private void ActualizarBotonesEstado()
        {
            if (dgvReservas.SelectedRows.Count == 0)
            {
                btnAceptar.Enabled = false;
                btnRechazar.Enabled = false;
                return;
            }

            string estado = dgvReservas.SelectedRows[0].Cells["Estado"].Value.ToString();

            btnAceptar.Enabled = estado != "Aceptada";
            btnRechazar.Enabled = estado != "Rechazada";
        }
    }
}
