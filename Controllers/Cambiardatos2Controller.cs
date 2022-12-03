using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using servicios_todo_en_uno.Models;
namespace servicios_todo_en_uno.Controllers
{
    public class Cambiardatos2Controller : ApiController
    {
        [HttpGet]
        public Cambiandocontraseñamodels2 inicio(string usuario, string nombre, string nuevonombre, string apellido, string nuevoapellido)
        {
            string sql = "UPDATE registros SET nombres = @nuevonombre,apellidos = @nuevoapellido  WHERE nombres = @nombres and  apellidos = @apellido AND correo = @correo"; ;
            MySqlConnection cnt = (new dbconnect()).getConnect();
            MySqlCommand cmd = new MySqlCommand(sql, cnt);
            cmd.Parameters.AddWithValue("@correo", usuario);
            cmd.Parameters.AddWithValue("@nombres", nombre);
            cmd.Parameters.AddWithValue("@nuevonombre", nuevonombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@nuevoapellido", nuevoapellido);
            try
            {
                cnt.Open();

                MySqlDataReader cursor = cmd.ExecuteReader();
                Cambiandocontraseñamodels2 login = new Cambiandocontraseñamodels2();
                while (cursor.Read())
                {
                    login.correo = cursor.GetString(1);
                    login.nombre = cursor.GetString(2);
                    login.nuevonombre = cursor.GetString(3);
                    login.apellido = cursor.GetString(4);
                    login.nuevoapellido = cursor.GetString(5);
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

    

