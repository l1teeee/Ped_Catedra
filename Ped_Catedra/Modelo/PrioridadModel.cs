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
        public Dictionary<int, string> ObtenerPrioridades()
        {
            Dictionary<int, string> prioridades = new Dictionary<int, string>();

            using (MySqlConnection conexion = Conexion.ObtenerConexion())
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
