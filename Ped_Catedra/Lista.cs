using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ped_Catedra
{
    public class Lista
    {
        public Nodo inicio;
        int totalnodos;

        public Lista()
        {
            this.inicio = null;
            this.totalnodos = 0;

        }

        public int TotalNodos()
        {
            return this.totalnodos;
        }


        public void Insertar(Recordatorio recor, string usuario)
        {
            // Obtener la prioridad seleccionada desde el ComboBox
            string textoSeleccionado = recor.prioridad;
            int idPrioridad = int.Parse(textoSeleccionado.Split('-')[0].Trim());

            Conexion.InsertarRecor(recor, idPrioridad, usuario);
        }


        public void Eliminar(int idRecordatorio)
        {
            Conexion.EliminarRecor(idRecordatorio);
        }


        public void Mostrar(DataGridView tabla, string usuario)
        {
            //Limpiando filas y columnas
            tabla.Rows.Clear();
            tabla.Columns.Clear();

            // Agregando las columnas al DataGridView
            tabla.Columns.Add("ID", "ID");
            tabla.Columns.Add("Titulo", "Titulo");
            tabla.Columns.Add("PrioridadID", "Prioridad");
            tabla.Columns.Add("Fecha", "Fecha");
            tabla.Columns.Add("Hora", "Hora");
            tabla.Columns.Add("Descripcion", "Descripción");
            tabla.Columns.Add("ObjetivosID", "ObjetivosID");

            // Obtener los datos de la base de datos
            DataTable dtRecordatorios = Conexion.ObtenerRecordatoriosPorUsuario(usuario);

            // Agregar los datos al DataGridView
            foreach (DataRow row in dtRecordatorios.Rows)
            {
                tabla.Rows.Add(row.ItemArray);
            }
        }



    }
}
