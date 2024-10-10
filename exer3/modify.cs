using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exer3
{
    internal class modify
    {
        public modify() { }
        SqlCommand cm;
        SqlDataReader rdr;
        public List<account> taikhoans(string query, params SqlParameter[] parameters)
        {
            List<account> taikhoans = new List<account>();
            using (SqlConnection sqlconnect = connection.getConnection())
            {
                sqlconnect.Open();
                using (SqlCommand cm = new SqlCommand(query, sqlconnect))
                {
                    if (parameters != null)
                    {
                        cm.Parameters.AddRange(parameters);
                    }

                    using (SqlDataReader rdr = cm.ExecuteReader())
                    {
                        while (rdr.Read())
                        {


                            taikhoans.Add(new account(
                                rdr.GetString(0),
                                rdr.GetString(1),
                                rdr.GetString(2),
                                rdr.GetString(3),
                                rdr.GetString(4),
                                rdr.GetString(5)
                            ));
                        }
                    }
                }

            }
            return taikhoans;
        }


        public void Command(string query, params SqlParameter[] parameters)
        {
            using SqlConnection sqlconnect = connection.getConnection();
            sqlconnect.Open();
            using SqlCommand cm = new SqlCommand(query, sqlconnect);
            if (parameters != null)
            {
                cm.Parameters.AddRange(parameters);
            }

            cm.ExecuteNonQuery();
            sqlconnect.Close();
        }

        public int ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using SqlConnection sqlconnect = connection.getConnection();
            sqlconnect.Open();
            using SqlCommand cm = new SqlCommand(query, sqlconnect);
            if (parameters != null)
            {
                cm.Parameters.AddRange(parameters);
            }
            object result = cm.ExecuteScalar();
            sqlconnect.Close();
            return Convert.ToInt32(result);
        }

    }
}
