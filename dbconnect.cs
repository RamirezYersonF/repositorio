using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace servicios_todo_en_uno
{
    public class dbconnect
    {
        MySqlConnection cnt;
        public dbconnect()
        {
            MySqlConnectionStringBuilder cs = new MySqlConnectionStringBuilder();
            cs.Server = "localhost";
            cs.Database = "appventas";
            cs.UserID = "root";
            cs.Password = "";
            cnt = new MySqlConnection(cs.ConnectionString);
        }
        public MySqlConnection getConnect()
        {
            return cnt;
        }
    }
}