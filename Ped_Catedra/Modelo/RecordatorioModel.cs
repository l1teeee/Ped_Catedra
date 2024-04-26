﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Ped_Catedra.Modelo
{
    public class RecordatorioModel
    {
        //Insertar un nuevo recordatorio
        public bool InsertarRecor(Recordatorio recor)
        {
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO Recordatorio (UsuarioID, Titulo, PrioridadID, Fecha, Hora, Descripcion) " +
                                   "VALUES (@usuario, @titulo, @prioridad, @fecha, @hora, @descripcion)";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@usuario", recor.usuarioId);
                    comando.Parameters.AddWithValue("@titulo", recor.titulo);
                    comando.Parameters.AddWithValue("@prioridad", recor.prioridadId);
                    comando.Parameters.AddWithValue("@fecha", recor.fecha);
                    comando.Parameters.AddWithValue("@hora", recor.hora);
                    comando.Parameters.AddWithValue("@descripcion", recor.descripcion);
                    comando.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al insertar el recordatorio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = "SELECT R.ID, R.Titulo, P.Prioridad AS Prioridad, R.Fecha, R.Hora, R.Descripcion, R.ObjetivosID FROM Recordatorio AS R INNER JOIN Prioridad AS P ON R.PrioridadID = P.ID WHERE R.UsuarioID =@usuario";
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
                            if (!reader.IsDBNull(reader.GetOrdinal("ObjetivosID")))
                            {
                                recordatorio.objetivosId = Convert.ToInt32(reader["ObjetivosID"]);
                            }
                            else
                            {
                                recordatorio.objetivosId = 0;
                            }

                            // Insertar el objeto Recordatorio en la lista
                            lista.Insertar(recordatorio);
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

        //Eliminar un recordatorio
        public void EliminarRecor(int idRecordatorio)
        {
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
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
    }
}