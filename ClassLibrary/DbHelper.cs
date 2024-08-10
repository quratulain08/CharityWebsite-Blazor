using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary
{
    public class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-HHRV8EU\SQLEXPRESS;Initial Catalog=donations;Integrated Security=True");
            return con;

        }
    }
}
