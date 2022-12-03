using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using servicios_todo_en_uno.Models;
namespace servicios_todo_en_uno.Controllers
{
    public class ProductoClienteController : ApiController
    {
       
        [HttpGet]
        public Boolean productos(string nombreproducto,  double precio, Int64 cantidad)
        {
            string sql = "INSERT INTO agregarproductosclientes(`nombre`,`precio`,`cantidad`) VALUES (@nombreproducto,  @precio, @cantidad)";

           
            MySqlConnection cnt = (new dbconnect()).getConnect();
            MySqlCommand cmd = new MySqlCommand(sql, cnt);

            cmd.Parameters.AddWithValue("@nombreproducto", nombreproducto);
            cmd.Parameters.AddWithValue("@precio", precio);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            try
            {
                cnt.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException p)
            {
                return false;
            }

        }
    }

}
