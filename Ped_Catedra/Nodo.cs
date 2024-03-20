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
        public Nodo siguiente;

        public Nodo(Recordatorio recordatorio)
        {
            this.recordatorio= recordatorio;
            this.siguiente = null;
        }
    }
}
