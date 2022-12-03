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
    public class BancoController : ApiController
    {
     
        [HttpGet]
        public Boolean tarjetabancaria(string numerocuenta, string nombretarjeta)
        {
            string sql = "INSERT INTO tarjetabancaria(`numerocuenta`, `tarjetabancaria`) VALUES (@numerocuenta, @tarjetabancaria)";

       
            MySqlConnection cnt = (new dbconnect()).getConnect();
            MySqlCommand cmd = new MySqlCommand(sql, cnt);

            cmd.Parameters.AddWithValue("@numerocuenta", numerocuenta);
            cmd.Parameters.AddWithValue("@tarjetabancaria", nombretarjeta);
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
