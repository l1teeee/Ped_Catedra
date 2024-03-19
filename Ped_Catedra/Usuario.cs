using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ped_Catedra
{
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public string descripcion { get; set; }

        public Usuario()
        {

        }
        public Usuario(int id, string nombre, string apellido, string usuario, string contraseña, string descripcion)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.descripcion = descripcion;
        }



    }
}
