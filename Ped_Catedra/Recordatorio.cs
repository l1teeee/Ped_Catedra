using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ped_Catedra
{
    public class Recordatorio
    {
        private int id;
        public string titulo { get; set; }

        public string prioridad { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string descripcion { get; set; }
        public string objetivos { get; set; }

        public Recordatorio()
        {

        }
    }
}
