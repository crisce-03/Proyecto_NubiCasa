using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PlayerUI.Forms
{
    internal class Conexion
    {
        private static string cadenaConexion = "Server=LAPTOPCARLOS\\SQLEXPRESS;Database=Plater_UI;Trusted_Connection=True;";

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            conexion.Open(); 
            return conexion;
        }

    }
}
