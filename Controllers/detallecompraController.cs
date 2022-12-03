using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using servicios_todo_en_uno.Models;
namespace servicios_todo_en_uno.Controllers
{
    public class detallecompraController : ApiController
    {
        [HttpGet]
        public detallesresultadomodels datos(string usuario)
        {
            string sql = "SELECT nombres,apellidos,correo,nombre,precio,cantidad, numerocuenta, tarjetabancaria FROM registros  INNER JOIN agregarproductoscliente ON registros.idregistros = agregarproductosclientes.idmostrarproductos INNER JOIN tarjetabancaria ON tarjetabancaria.idtarjetabancaria = registros.idregistros; WHERE correo = @correo";

          
            MySqlConnection cnt = (new dbconnect()).getConnect();
            MySqlCommand cmd = new MySqlCommand(sql, cnt);
            cmd.Parameters.AddWithValue("@correo", usuario);
            try
            {
                cnt.Open();

                MySqlDataReader cursor = cmd.ExecuteReader();
                detallesresultadomodels login = new detallesresultadomodels();
                while (cursor.Read())
                {
                    login.nombres = cursor.GetString(0);
                    login.apellidos = cursor.GetString(1);
                    login.correo = cursor.GetString(2);
                    login.nombre= cursor.GetString(3);
                    login.precio = cursor.GetInt32(4);
                    login.numerocuenta = cursor.GetString(5);
                    login.tarjetabancaria = cursor.GetString(6);


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

