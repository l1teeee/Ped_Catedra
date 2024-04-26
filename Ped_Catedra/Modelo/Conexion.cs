using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ped_Catedra
{
    internal class Conexion
    {
        
        private static string servidor = "localhost";
        private static string baseDatos = "memberme";
        private static string usuario = "root";
        private static string contraseña = "";

        public static MySqlConnection ObtenerConexion()
        {
            string cadenaConexion = $"server={servidor};user={usuario};database={baseDatos};password={contraseña};";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            return conexion;
        }
    }
}
