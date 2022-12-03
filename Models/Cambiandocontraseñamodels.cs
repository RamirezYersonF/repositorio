using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace servicios_todo_en_uno.Models
{
    public class Cambiandocontraseñamodels
    {
       public int idregistros { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public string nuevacontraseña { get; set; }
    }
}