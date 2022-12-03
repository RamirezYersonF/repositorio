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
    public class RegistroempleadoController : ApiController
    {
        [HttpGet]
        public Boolean registro(string nombre, string transporte, string telefono)
        {
            string sql = "INSERT INTO empleados(`nombre`, `transporte`,`telefono`) VALUES (@nombres, @transporte,@telefono)";

            MySqlConnection cnt = (new dbconnect()).getConnect();
            MySqlCommand cmd = new MySqlCommand(sql, cnt);

            cmd.Parameters.AddWithValue("@nombres", nombre);
            cmd.Parameters.AddWithValue("@transporte", transporte);
            cmd.Parameters.AddWithValue("@telefono", telefono);

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


