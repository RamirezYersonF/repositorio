using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace servicios_todo_en_uno.Models
{
    public class Usuarios
    {
       public int idregistros { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }

        public string correo { get; set; }
        public string contraseña { get; set; }
    }
}