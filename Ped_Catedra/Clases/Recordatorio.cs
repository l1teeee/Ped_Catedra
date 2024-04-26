using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ped_Catedra
{
    public class Recordatorio
    {
        public int id { get; set; }
        public string titulo { get; set; }

        public int prioridadId { get; set; }
        public string prioridadName { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string descripcion { get; set; }
        public int objetivosId { get; set; }

        public string usuarioId { get; set; }

        public Recordatorio()
        {

        }
    }
}
