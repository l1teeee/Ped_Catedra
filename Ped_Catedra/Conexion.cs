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


        //RECORDAR CONTRASEÑA
        public static string ObtenerIdUsuario(string correo)
        {
            string id = "";

            string query = $"SELECT ID FROM usuario WHERE Correo = @correo";

            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@correo", correo);
                    object result = comando.ExecuteScalar();

                    if (result != null)
                    {
                        id = result.ToString();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return id;
        }

        //ACTUALIZAR CONTRASEÑA
        public static void ActualizarContraseña(string idUsuario, string nuevaContraseña)
        {
            string contraseñaEncriptada = EncriptarContraseña(nuevaContraseña);

            string query = "UPDATE usuario SET Contraseña = @nuevaContraseña WHERE ID = @idUsuario";

            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    conexion.Open();
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nuevaContraseña", contraseñaEncriptada);
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la contraseña: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //LOGIN
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

        //LOGIN
        public static string ValidarExistenciaUsuario(string usuario)
        {
            using (MySqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    conexion.Open();

                    // Verificar si el usuario ya existe por ID
                    string queryUsuario = "SELECT COUNT(*) FROM Usuario WHERE ID = @usuario";
                    MySqlCommand comandoUsuario = new MySqlCommand(queryUsuario, conexion);
                    comandoUsuario.Parameters.AddWithValue("@usuario", usuario);
                    int countUsuario = Convert.ToInt32(comandoUsuario.ExecuteScalar());
                    if (countUsuario > 0)
                    {
                        return "usuario";
                    }

                    // Si no existe, retorna cadena vacía
                    return "";
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al validar la existencia del usuario: " + ex.Message);
                    return ""; // Retorna cadena vacía en caso de error
                }
            }
        }

        //LOGIN
        public static string ValidarExistenciaCorreo(string correo)
        {
            using (MySqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    conexion.Open();

                    // Verificar si el correo ya existe
                    string queryCorreo = "SELECT COUNT(*) FROM Usuario WHERE Correo = @correo";
                    MySqlCommand comandoCorreo = new MySqlCommand(queryCorreo, conexion);
                    comandoCorreo.Parameters.AddWithValue("@correo", correo);
                    int countCorreo = Convert.ToInt32(comandoCorreo.ExecuteScalar());
                    if (countCorreo > 0)
                    {
                        return "correo";
                    }

                    // Si no existe, retorna cadena vacía
                    return "";
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al validar la existencia del correo: " + ex.Message);
                    return ""; // Retorna cadena vacía en caso de error
                }
            }
        }



        //CREAR USUARIO
        public static string InsertarUsuario(Usuario nuevoUsuario)
        {
            using (MySqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    conexion.Open();

                    // Si no existe, proceder con la inserción
                    string contraseñaEncriptada = EncriptarContraseña(nuevoUsuario.contraseña);
                    string query = "INSERT INTO Usuario (ID, Nombres, Apellidos, Correo, Contraseña) VALUES (@usuario, @nombres, @apellidos, @correo, @contraseña)";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@usuario", nuevoUsuario.usuario);
                    comando.Parameters.AddWithValue("@nombres", nuevoUsuario.nombre);
                    comando.Parameters.AddWithValue("@apellidos", nuevoUsuario.apellido);
                    comando.Parameters.AddWithValue("@correo", nuevoUsuario.correo);
                    comando.Parameters.AddWithValue("@contraseña", contraseñaEncriptada);
                    comando.ExecuteNonQuery();
                    return ""; // Retorna cadena vacía indicando éxito
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al insertar el usuario: " + ex.Message);
                    return ""; // Retorna cadena vacía en caso de error
                }
            }
        }





        //CREAR USUARIO
        public static string GenerarCodigo()
        {
            Random rnd = new Random();
            int codigo = rnd.Next(100000, 999999);
            return codigo.ToString();
        }

        //CREAR USUARIO
        public static void EnviarCodigoVerificacion(string correoDestinatario, string codigo)
        {
            string contraseñaCorreo = "qukrhapiaxidtdfj";
            string asuntoCorreo = "Código de Verificación";
            string mensajeCorreo = "Su código de verificación es: " + codigo;

            try
            {
                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com");
                clienteSmtp.Port = 587;
                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential("cuponerarivas@gmail.com", contraseñaCorreo); 

                MailMessage correo = new MailMessage("cuponerarivas@gmail.com", correoDestinatario, asuntoCorreo, mensajeCorreo); 

                clienteSmtp.Send(correo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo electrónico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //CREAR USUARIO
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


        //DASHBOARD
        public static DataTable ObtenerRecordatoriosPorUsuario(string usuario)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT R.ID, R.Titulo, P.Prioridad AS Prioridad, R.Fecha, R.Hora, R.Descripcion, R.ObjetivosID FROM Recordatorio AS R INNER JOIN Prioridad AS P ON R.PrioridadID = P.ID WHERE R.UsuarioID =@usuario";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@usuario", usuario);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al obtener los recordatorios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return dt;
        }


        //DASHBOARD

        public static void InsertarRecor(Recordatorio recor, int idPrioridad, string usuario)
        {
            using (MySqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO Recordatorio (UsuarioID, Titulo, PrioridadID, Fecha, Hora, Descripcion) " +
                                   "VALUES (@usuario, @titulo, @prioridad, @fecha, @hora, @descripcion)";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@titulo", recor.titulo);
                    comando.Parameters.AddWithValue("@prioridad", idPrioridad); // Utiliza el ID de la prioridad
                    comando.Parameters.AddWithValue("@fecha", recor.fecha);
                    comando.Parameters.AddWithValue("@hora", recor.hora);
                    comando.Parameters.AddWithValue("@descripcion", recor.descripcion);
                    comando.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al insertar el recordatorio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //DASHBOARD

        public static string CorreoUsu(string idUsuario)
        {
            string correo = "";

            using (MySqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT Correo FROM usuario WHERE ID = @idUsuario";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                    object resultado = comando.ExecuteScalar();
                    if (resultado != null)
                    {
                        correo = resultado.ToString();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al obtener el correo del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return correo;
        }


        //DASHBOARD

        public static void EnviarCorreo(string contraseña, string destinatario, string asunto, string mensaje)
        {
            try
            {
                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com");
                clienteSmtp.Port = 587;
                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential("cuponerarivas@gmail.com", contraseña);

                MailMessage correo = new MailMessage("cuponerarivas@gmail.com", destinatario, asunto, mensaje);

                clienteSmtp.Send(correo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar correo electrónico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //DASHBOARD

        public static void EliminarRecor(int idRecordatorio)
        {
            using (MySqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "DELETE FROM Recordatorio WHERE ID = @idRecordatorio";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@idRecordatorio", idRecordatorio);
                    comando.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al eliminar el recordatorio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //DASHBOARD

        public static Dictionary<int, string> ObtenerPrioridades()
        {
            Dictionary<int, string> prioridades = new Dictionary<int, string>();

            using (MySqlConnection conexion = ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT ID, Prioridad FROM prioridad";
                    MySqlCommand comando = new MySqlCommand(query, conexion);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("ID");
                            string prioridad = reader.GetString("Prioridad");
                            prioridades.Add(id, prioridad);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al obtener las prioridades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return prioridades;
        }


    }
}
