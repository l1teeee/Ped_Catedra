using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ped_Catedra
{
    public class Prioridad
    {
        public int id { get; set; }
        public string prioridad { get; set; }

        public Prioridad()
        {

        }
        public Prioridad(int id, string prioridad)
        {
            this.id = id;
            this.prioridad = prioridad;
        }
    }
}
