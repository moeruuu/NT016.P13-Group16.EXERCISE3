using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace exer3
{
    internal class connection
    {
        private static string connectionstring = @"Data Source=UYNTHYEE\MSSQLSERVER01;Initial Catalog=account;Integrated Security=True;Trust Server Certificate=True";
        public static SqlConnection getConnection()
        {
            return new SqlConnection(connectionstring);
        }
    }
}