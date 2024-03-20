using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public static int VerificarCredenciales(string usuario, string contraseña)
        {
            int count = 0;

            using (MySqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT COUNT(*) FROM Usuario WHERE ID = @usuario AND Contraseña = @contraseña";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contraseña", contraseña);
                    count = Convert.ToInt32(comando.ExecuteScalar());
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message);
                }
            }

            return count;
        }


    }
}
