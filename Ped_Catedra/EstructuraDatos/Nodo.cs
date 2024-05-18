using Ped_Catedra.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ped_Catedra
{
    public class Nodo
    {
        public Recordatorio recordatorio;
        public Prioridad prioridad;
        public Objetivos obj;
        public Nodo siguiente;

        public Nodo(Recordatorio recordatorio)
        {
            this.recordatorio= recordatorio;
            this.siguiente = null;
        }

        public Nodo(Prioridad priroridad)
        {
            this.prioridad = priroridad;
            this.siguiente = null;
        }

        public Nodo(Objetivos obj)
        {
            this.obj = obj;
            this.siguiente = null;
        }
    }
}
