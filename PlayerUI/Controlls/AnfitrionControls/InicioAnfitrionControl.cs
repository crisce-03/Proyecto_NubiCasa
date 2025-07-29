using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlayerUI.Forms;

namespace PlayerUI.Controlls.AnfitrionControls
{
    public partial class InicioAnfitrionControl : Form
    {
        public InicioAnfitrionControl(int Id_Anfitrion)
        {
            InitializeComponent();
            string nombreAnfitrion =  cargarNombreAnfitrion(Id_Anfitrion);
            int num_Propiedades = contarPropiedades(Id_Anfitrion);


            lblBienAnfi.Text = $"¡Bienvenido {nombreAnfitrion}!";
            numPropiedades.Text = num_Propiedades.ToString();
        }

        public string cargarNombreAnfitrion(int Id_Anfitrion)
        {

            

            using (SqlConnection con = Conexion.ObtenerConexion())
            {

               

                SqlCommand cmd = new SqlCommand(@"
                    SELECT Nombre
                    FROM Anfitrion
                    WHERE ID_Anfitrion = @id", con);

                cmd.Parameters.AddWithValue("@id", Id_Anfitrion);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return reader["Nombre"].ToString();
                }
                else
                {
                    return "Anfitrión desconocido";
                }
            }

        }

        public int contarPropiedades(int Id_Anfitrion)
        {
            using (SqlConnection con = Conexion.ObtenerConexion())
            {

                SqlCommand cmd = new SqlCommand(@"
                    SELECT COUNT(*) 
                    FROM Propiedades
                    WHERE IdAnfitrion = @id", con);

                cmd.Parameters.AddWithValue("@id", Id_Anfitrion);

                int total = (int)cmd.ExecuteScalar(); // COUNT(*) devuelve un número entero

                return total;
            }
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numPropiedades_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
