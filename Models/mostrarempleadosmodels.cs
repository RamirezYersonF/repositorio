using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace servicios_todo_en_uno.Models
{
    public class detallesresultadomodels
    {
       public int iddetallecompra { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public string nombreproducto { get; set; }
        public double precio { get; set; }
        public string numerocuenta { get; set; }
        public string nombretarjeta{ get; set; }

    }
}