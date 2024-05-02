using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ped_Catedra.Modelo;

namespace Ped_Catedra.Controlador
{
    public class PrioridadControlador
    {
        PrioridadModel prioridadModel;
        public PrioridadControlador()
        {
            prioridadModel = new PrioridadModel();
        }

        //Llena el combobox con las prioridades
        public void LlenarCmbPrioridades(ComboBox cmb, string id)
        {
            Lista listaPrioridades = prioridadModel.ObtenerPrioridades(id);

            Nodo puntero = listaPrioridades.inicio;
            cmb.Items.Clear();
            while (puntero != null)
            {
                Prioridad priori = puntero.prioridad;
                cmb.Items.Add(priori.id + " - " + priori.prioridad);
                puntero = puntero.siguiente;
            }
        }


        //Regresa el index dentro del cmb de una prioridad en especifico
        public int IndexCmbPrioridades(string nombre, string id)
        {
            Lista listaPrioridades = prioridadModel.ObtenerPrioridades(id);

            Nodo puntero = listaPrioridades.inicio;
            int index = 0;
            while (puntero != null)
            {
                Prioridad priori = puntero.prioridad;
                if (nombre == priori.prioridad)
                {
                    return index;
                }
                index++;
                puntero = puntero.siguiente;
            }
            return -1;
        }

        //Regresa el total de prioridades
        public int TotalPrioridades(string id)
        {
            Lista listaPrioridades = prioridadModel.ObtenerPrioridades(id);
            return listaPrioridades.TotalNodos();
        }
    }
}
