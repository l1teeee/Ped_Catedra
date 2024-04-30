using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ped_Catedra.Modelo;


namespace Ped_Catedra
{
    public class Lista
    {
        public Nodo inicio;
        int totalNodos;
        RecordatorioModel recordatorioModel;
        PrioridadModel prioridadModel;

        public int TotalNodos()
        {
            return this.totalNodos;
        }

        public Lista()
        {
            recordatorioModel = new RecordatorioModel();
            prioridadModel = new PrioridadModel();
            this.inicio = null;
            this.totalNodos = 0;;

        }

        //Inserta en la lista los recordatorios
        public void InsertarRecordatorio(Recordatorio recor)
        {
            Nodo auxiliar = new Nodo(recor);

            if (inicio == null)
            {
                inicio = auxiliar;
            }
            else
            {
                Nodo puntero = inicio;
                while (puntero.siguiente != null)
                {
                    puntero = puntero.siguiente;
                }
                puntero.siguiente = auxiliar;
            }
            this.totalNodos++;
        }

        //Inserta en la lista las prioridades
        public void InsertarPrioridades(Prioridad priori)
        {
            Nodo auxiliar = new Nodo(priori);

            if (inicio == null)
            {
                inicio = auxiliar;
            }
            else
            {
                Nodo puntero = inicio;
                while (puntero.siguiente != null)
                {
                    puntero = puntero.siguiente;
                }
                puntero.siguiente = auxiliar;
            }
            this.totalNodos++;
        }
    }
}
