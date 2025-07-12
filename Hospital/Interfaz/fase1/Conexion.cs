using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace fase1
{
    public class Conexion
    {

        private static string cadena = "Data Source=DESKTOP-7TSC3GT;Initial Catalog=Hospital_Don_Bosco;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            return conexion;
        }



    }
}
