using System;
using System.Collections.Generic;
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


        public void Insertar(Recordatorio recor)
        {
            Nodo puntero;

            Nodo auxiliar = new Nodo(recor);

            if (inicio == null)
            {
                inicio = auxiliar;
            }
            else
            {
                puntero = inicio;
                inicio = auxiliar;
                auxiliar.siguiente = puntero;
            }
            this.totalnodos++;
        }

        public Nodo Eliminar(int pos)
        {
            if (inicio == null)
            {
                MessageBox.Show("La lista de recordatorios está vacía, no contiene ningún recordatorio para eliminar",
                    "Lista de Recordatorios Vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Nodo aux = null;

            if (pos > 0 && pos <= totalnodos)
            {
                if (pos == 1)
                {
                    aux = inicio;
                    inicio = inicio.siguiente;
                }
                else
                {
                    Nodo punteroanterior = null;
                    Nodo punteroposterior = inicio;

                    for (int i = 1; i < pos; i++)
                    {
                        punteroanterior = punteroposterior;
                        punteroposterior = punteroposterior.siguiente;

                    }
                    aux = punteroposterior;
                    punteroanterior.siguiente = punteroanterior.siguiente;
                }
                MessageBox.Show("¡Recordatorio eliminado!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.totalnodos--;
                return aux;
            }
            return null;
        }

        public void Mostrar(DataGridView tabla)
        {
            //Limpiando filas y columnas
            tabla.Rows.Clear();
            tabla.Columns.Clear();

            Nodo puntero = inicio;
            //Creando columnas
            tabla.Columns.Add("N°", "N°");
            tabla.Columns.Add("Titulo", "Titulo");
            tabla.Columns.Add("Prioridad", "Prioridad");
            tabla.Columns.Add("Fecha", "Fecha");
            tabla.Columns.Add("Hora", "Hora");
            tabla.Columns.Add("Descripción", "Descripción");
            int contador = 1;


            //Agregando datos a las filas iterando el puntero cuando sea diferente a null
            while (puntero != null)
            {
                tabla.Rows.Add(contador++, puntero.recordatorio.titulo, puntero.recordatorio.prioridad, puntero.recordatorio.fecha,
                    puntero.recordatorio.hora, puntero.recordatorio.descripcion);
                puntero = puntero.siguiente;
            }
        }


    }
}
