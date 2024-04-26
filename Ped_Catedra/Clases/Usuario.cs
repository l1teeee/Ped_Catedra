using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ped_Catedra
{
    public class Usuario
    {
        public string id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        

        public Usuario()
        {

        }
        public Usuario(string id, string nombre, string apellido, string contraseña, string correo)
        {
            this.id = id;
            this.nombres = nombre;
            this.apellidos = apellido;
            this.contraseña = contraseña;
            this.correo = correo;
        }



    }
}
