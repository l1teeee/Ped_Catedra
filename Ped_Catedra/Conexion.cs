using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public static bool VerificarCredenciales(string usuario, string contraseña)
        {
            bool credencialesValidas = false;

            using (MySqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT Contraseña FROM Usuario WHERE ID = @usuario";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    string hashAlmacenado = (string)comando.ExecuteScalar();

                    // Calcular el hash de la contraseña ingresada
                    string hashIngresado = EncriptarContraseña(contraseña);

                    // Comparar los hashes
                    credencialesValidas = hashIngresado == hashAlmacenado;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error de conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return credencialesValidas;
        }


        public static void InsertarUsuario(Usuario nuevoUsuario, string confirmacionContraseña)
        {
            // Validar que las contraseñas sean iguales
            if (nuevoUsuario.contraseña != confirmacionContraseña)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string contraseñaEncriptada = EncriptarContraseña(nuevoUsuario.contraseña);

            using (MySqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO Usuario (ID, Nombres, Apellidos, Contraseña) VALUES (@usuario, @nombres, @apellidos, @contraseña)";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@usuario", nuevoUsuario.usuario);
                    comando.Parameters.AddWithValue("@nombres", nuevoUsuario.nombre);
                    comando.Parameters.AddWithValue("@apellidos", nuevoUsuario.apellido);
                    comando.Parameters.AddWithValue("@contraseña", contraseñaEncriptada);
                    comando.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al insertar el usuario: " + ex.Message);
                }
            }
        }

        private static string EncriptarContraseña(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }




    }
}
