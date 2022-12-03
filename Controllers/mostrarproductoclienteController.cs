using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using servicios_todo_en_uno.Models;
namespace servicios_todo_en_uno.Controllers { 

    public class mostrarproductoclienteController : ApiController
    {
        [HttpGet]
        public List<String> IdResultado()
        {
            string sql = "SELECT idagregarproductosclientes,nombre, precio, cantidad FROM agregarproductosclientes";


            MySqlConnection cnt = (new dbconnect()).getConnect();
            MySqlCommand cmd = new MySqlCommand(sql, cnt);
            List<String> lst = new List<String>();
            try
            {
                cnt.Open();

                MySqlDataReader cursor = cmd.ExecuteReader();
                mostrarproductosclientesmodels resultado = new mostrarproductosclientesmodels();
                while (cursor.Read())
                {
                    lst.Add(cursor[0].ToString());
                    lst.Add(cursor[1].ToString());
                    lst.Add(cursor[2].ToString());
                    lst.Add(cursor[3].ToString());

                }

                cnt.Close();
                return lst;
            }
            catch (MySqlException p)
            {
                return null;
            }

        }
    }

}