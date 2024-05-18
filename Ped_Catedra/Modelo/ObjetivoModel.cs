using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Ped_Catedra.Clases;


namespace Ped_Catedra.Modelo
{
    public class ObjetivoModel
    {
        public bool InsertarObj(Objetivos obj)
        {
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {

                try
                {
                    conexion.Open();
                    string query = "INSERT INTO Objetivos (Titulo, Descripcion, IdRecordatorio)" +
                                   "VALUES (@titulo, @descripcion, @IdRecor)";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@titulo", obj.titulo);
                    comando.Parameters.AddWithValue("@descripcion", obj.descrip);
                    comando.Parameters.AddWithValue("@IdRecor", obj.idRecordatorio);
                    comando.ExecuteNonQuery();
                    return true;
                }catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar el objetivo "+ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                

            }
        }

        public Lista ObtenerRecordatorios(string usuario)
        {
            Lista lista = new Lista();
            Recordatorio recordatorio;
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT R.ID, R.Titulo, P.Prioridad AS Prioridad FROM Recordatorio AS R INNER JOIN Prioridad AS P ON R.PrioridadID = P.ID " +
                        "WHERE R.UsuarioID =@usuario AND R.Estado = 'Disponible'";
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

        public bool ModificarObj(Objetivos obj)
        {
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "UPDATE objetivos SET Titulo=@titu, Descripcion=@descri, IdRecordatorio = @idRecord " +
                                   "WHERE ID = @idObj";
                    MySqlCommand comando = new MySqlCommand(query, conexion);

                    comando.Parameters.AddWithValue("@titu", obj.titulo);
                    comando.Parameters.AddWithValue("@descri", obj.descrip);
                    comando.Parameters.AddWithValue("@idRecord", obj.idRecordatorio);
                    comando.Parameters.AddWithValue("@idObj", obj.id);
                    comando.ExecuteNonQuery();
                    return true;
                }catch(MySqlException ex)
                {
                    MessageBox.Show("Error al modificar el objetivo " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public void EliminarObj(int idObjetivo)
        {
            using(MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "DELETE FROM objetivos WHERE ID = @ID";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@ID", idObjetivo);
                    comando.ExecuteNonQuery() ;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al eliminar el objetivo " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
        }

        public Lista obtenerObjetviosRecord(string idRecord)
        {
            Lista list = new Lista();
            Objetivos obj;

            using(MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string qr = "SELECT * FROM objetivos WHERE idRecordatorio = @id";
                    MySqlCommand comando = new MySqlCommand(qr, conexion);
                    comando.Parameters.AddWithValue("@id", idRecord);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            obj = new Objetivos();
                            obj.id = reader.GetInt32("ID");
                            obj.descrip = reader.GetString("Descripcion");
                            list.InsertarObjetivos(obj);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al obtener los objetivos" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return list;
        }
    }
}
