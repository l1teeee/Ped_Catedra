﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Ped_Catedra.Modelo
{
    public class PrioridadModel
    {
        //Inserta una prioridad
        public bool InsertarPrioridad(string nombrePriori, string usuario)
        {
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "INSERT INTO prioridad (Prioridad, IdUsuario) " +
                                   "VALUES (@prioridad, @usuario)";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@prioridad", nombrePriori);
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al insertar la prioridad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        //Obtiene todas las prioridades incluidas las predeterminadas (Alta, Media, Baja)
        public Lista ObtenerPrioridades(string idUsuario)
        {
            Lista lista = new Lista();
            Prioridad priori;

            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT * FROM prioridad WHERE IdUsuario = @usuario OR IdUsuario = 'admin'";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@usuario", idUsuario);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            priori = new Prioridad();
                            priori.id = reader.GetInt32("ID");
                            priori.prioridad = reader.GetString("Prioridad");
                            lista.InsertarPrioridades(priori);
                        }
                    }
                }
                catch (MySqlException ex)
                {

                    MessageBox.Show("Error al obtener las prioridades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return lista;
        }

        //Obtiene solo las prioridades ingresadas por el usuario
        public Lista ObtenerPrioridadesUsu(string idUsuario)
        {
            Lista lista = new Lista();
            Prioridad priori;

            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT * FROM prioridad WHERE IdUsuario = @usuario";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@usuario", idUsuario);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            priori = new Prioridad();
                            priori.id = reader.GetInt32("ID");
                            priori.prioridad = reader.GetString("Prioridad");
                            lista.InsertarPrioridades(priori);
                        }
                    }
                }
                catch (MySqlException ex)
                {

                    MessageBox.Show("Error al obtener las prioridades: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return lista;
        }

        //Modifica una prioridad
        public bool ModificarRecor(string nombre, int idPrioridad)
        {
            using (MySqlConnection conexion = Conexion.ObtenerConexion())
            {
                try
                {
                    conexion.Open();
                    string query = "UPDATE prioridad SET Prioridad = @prioridad WHERE ID = @idPrioridad";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@prioridad", nombre);
                    comando.Parameters.AddWithValue("@idprioridad", idPrioridad);
                    comando.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al modificar la prioridad: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }


}
