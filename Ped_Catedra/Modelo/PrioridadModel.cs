using System;
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
    }


}
