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
    public class RegistroController : ApiController
    {
        [HttpGet]
        public Usuarios inicio(string usuario, string contraseña)
        {
            string sql = "SELECT * FROM registros where correo = @correo and contraseña = @contraseña";
            MySqlConnection cnt = (new dbconnect()).getConnect();
            MySqlCommand cmd = new MySqlCommand(sql, cnt);
            cmd.Parameters.AddWithValue("@correo", usuario);
            cmd.Parameters.AddWithValue("@contraseña", contraseña);
            try
            {
                cnt.Open();

                MySqlDataReader cursor = cmd.ExecuteReader();
                Usuarios login = new Usuarios();
                while (cursor.Read())
                {
                    login.idregistros = cursor.GetInt32(0);
                    login.nombres = cursor.GetString(1);
                    login.apellidos = cursor.GetString(2);
                    login.correo = cursor.GetString(3);
                    login.contraseña = cursor.GetString(4);
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
        [HttpGet]
        public Boolean registro(string usuario, string contraseña, string nombre, string apellido)
        {
            string sql = "INSERT INTO registros (`nombres`, `apellidos`, `correo`, `contraseña`) VALUES (@nombres, @apellidos, @correo, @contraseña)";

            MySqlConnection cnt = (new dbconnect()).getConnect();
            MySqlCommand cmd = new MySqlCommand(sql, cnt);

            cmd.Parameters.AddWithValue("@nombres", nombre);
            cmd.Parameters.AddWithValue("@apellidos", apellido);
            cmd.Parameters.AddWithValue("@correo", usuario);
            cmd.Parameters.AddWithValue("@contraseña", contraseña);

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

