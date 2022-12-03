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
    public class jefeController : ApiController
    {
        [HttpGet]
        public jefemodels datos(string usuario, string contraseña)
        {
            string sql = "SELECT * FROM administradorapp where correo = @correo and contraseña = @contraseña";
            MySqlConnection cnt = (new dbconnect()).getConnect();
            MySqlCommand cmd = new MySqlCommand(sql, cnt);
            cmd.Parameters.AddWithValue("@correo", usuario);
            cmd.Parameters.AddWithValue("@contraseña", contraseña);
            try
            {
                cnt.Open();

                MySqlDataReader cursor = cmd.ExecuteReader();
                jefemodels login = new jefemodels();
                while (cursor.Read())
                {
                    login.correo = cursor.GetString(1);
                    login.contraseña = cursor.GetString(2);
                }
                cursor.Close();
                cnt.Close();
                return login;
            }
            catch (MySqlException p)
            {
                return null;
            }

        }
       

        }

    }

