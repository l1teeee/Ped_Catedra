using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using Ped_Catedra.Clases;

namespace Ped_Catedra.Modelo
{
    public class UsuarioModel
    {

        //Insertar un nuevo usuario
        public string InsertarUsuario(Usuario nuevoUsuario)
        {
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();

                    // Si no existe, proceder con la inserción
                    string contraseñaEncriptada = EncriptarContraseña(nuevoUsuario.contraseña);
                    string query = "INSERT INTO Usuario (ID, Nombres, Apellidos, Correo, Contraseña) VALUES (@usuario, @nombres, @apellidos, @correo, @contraseña)";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@usuario", nuevoUsuario.id);
                    comando.Parameters.AddWithValue("@nombres", nuevoUsuario.nombres);
                    comando.Parameters.AddWithValue("@apellidos", nuevoUsuario.apellidos);
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

        //Obtener datos del usuario en sesión
        public Usuario ObtenerDatosUsuario(string idUsuario)
        {
            Usuario usuario = null;

            string query = $"SELECT * FROM usuario WHERE ID = @idUsuario";

            try
            {
                using (MySqlConnection conexion = Conexion.ObtenerConexion())
                {
                    conexion.Open();
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario();

                            usuario.id = reader["ID"].ToString();
                            usuario.nombres = reader["Nombres"].ToString();
                            usuario.apellidos = reader["Apellidos"].ToString();
                            usuario.correo = reader["Correo"].ToString();
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return usuario; 
        }

        //Obteniendo el id del usuario (el nombre de usuario)
        public string ObtenerIdUsuario(string correo)
        {
            string id = "";

            string query = $"SELECT ID FROM usuario WHERE Correo = @correo";

            try
            {
                using (MySqlConnection conexion = Conexion.ObtenerConexion())
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

        //Cambiando la contraseña
        public void ActualizarContraseña(string idUsuario, string nuevaContraseña)
        {
            string contraseñaEncriptada = EncriptarContraseña(nuevaContraseña);

            string query = "UPDATE usuario SET Contraseña = @nuevaContraseña WHERE ID = @idUsuario";

            try
            {
                using (MySqlConnection conexion = Conexion.ObtenerConexion())
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

        //Validando las contraseñas para el incio de sesión
        public bool VerificarCredenciales(string usuario, string contraseña)
        {
            bool credencialesValidas = false;

            using (MySqlConnection conexion = Conexion.ObtenerConexion())
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

        //Validar si el nombre de usuario ya esta registrado
        public string ValidarExistenciaUsuario(string usuario)
        {
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
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

        //Validar si el correo nuevo ya esta registrado
        public string ValidarExistenciaCorreo(string correo)
        {
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
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

        //Obtener el correo del usuario
        public string CorreoUsu(string idUsuario)
        {
            string correo = "";

            using (MySqlConnection conexion = Conexion.ObtenerConexion())
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


        //Generar código para verificar el correo
        public string GenerarCodigo()
        {
            Random rnd = new Random();
            int codigo = rnd.Next(100000, 999999);
            return codigo.ToString();
        }

        //Función para encriptar contraseña
        public string EncriptarContraseña(string contraseña)
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

        public int updateEstadoRecordatorios(string idUsuario)
        {
            int filas = 0;
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string qr = @"UPDATE recordatorio
                                SET Estado = 'Caducado'
                                WHERE UsuarioID = @id
                                AND Estado = 'Disponible'
                                AND (Fecha <= CURRENT_DATE() 
                                    OR (Fecha = CURRENT_DATE() AND Hora <= CURRENT_TIME()))";
                    MySqlCommand comando = new MySqlCommand(qr, conexion);

                    comando.Parameters.AddWithValue("@id", idUsuario);
                    filas = comando.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al verificar informacion" +ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            return filas;
        }

        public Lista obtenerCaducados(string usuario)
        {
            Lista lista = new Lista();
            Recordatorio recordatorio;
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT R.ID, R.Titulo, P.Prioridad AS Prioridad, R.Fecha, R.Hora, R.Descripcion FROM Recordatorio AS R INNER JOIN Prioridad AS P ON R.PrioridadID = P.ID " +
                        "WHERE R.UsuarioID =@usuario AND R.Estado = 'Caducado'";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@usuario", usuario);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        //lista.LimpiarLista();
                        while (reader.Read())
                        {
                            recordatorio = new Recordatorio();
                            recordatorio.id = Convert.ToInt32(reader["ID"]);
                            recordatorio.titulo = reader["Titulo"].ToString();
                            recordatorio.prioridadName = reader["Prioridad"].ToString();
                            recordatorio.fecha = ((DateTime)reader["Fecha"]).ToString("yyyy-MM-dd");
                            recordatorio.hora = reader["Hora"].ToString();
                            recordatorio.descripcion = reader["Descripcion"].ToString();
                            lista.InsertarRecordatorio(recordatorio);
                        }
                    }

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al obtener los recordatorios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return lista;
        }

        public string obtenerCorreo(string usuario)
        {

            string correo = null;

            using( MySqlConnection conexion = Conexion.ObtenerConexion()){
                try
                {
                    conexion.Open();
                    string qr = "SELECT Correo FROM usuario WHERE ID = @id";
                    MySqlCommand comando = new MySqlCommand(qr, conexion);
                    comando.Parameters.AddWithValue("@id", usuario);
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        // Verificar si se obtuvo alguna fila
                        if (reader.Read())
                        {
                            // Obtener el valor de la columna "Correo"
                            correo = reader["Correo"].ToString();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al obtener el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            return correo;
        }
    }
}
