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
    public class CambiardatosController : ApiController
    {
        [HttpGet]
        public Cambiandocontraseñamodels inicio(string usuario, string contraseña, string nuevacontraseña)
        {
            string sql = "UPDATE registros SET contraseña = @nuevacontraseña  WHERE contraseña = @contraseña AND correo = @correo" ;
            MySqlConnection cnt = (new dbconnect()).getConnect();
            MySqlCommand cmd = new MySqlCommand(sql, cnt);
            cmd.Parameters.AddWithValue("@correo", usuario);
            cmd.Parameters.AddWithValue("@contraseña", contraseña);
            cmd.Parameters.AddWithValue("@nuevacontraseña", nuevacontraseña);
            try
            {
                cnt.Open();

                MySqlDataReader cursor = cmd.ExecuteReader();
                Cambiandocontraseñamodels login = new Cambiandocontraseñamodels();
                while (cursor.Read())
                {
                    login.correo = cursor.GetString(1);
                    login.contraseña = cursor.GetString(2);
                    login.nuevacontraseña = cursor.GetString(3);
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

    

