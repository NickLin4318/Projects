using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtosWindowsForms
{
    class CInsert
    {
        public void executeSQL(string sql)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.;Initial Catalog=testGYM;Integrated Security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //T-SQL語法
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //internal static void method(string fName, string fPhone, string fEmail, string fAddress)
        //{
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = @"Data Source =.; Initial Catalog = DBdemo; Integrated Security = True";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = con;
        //    cmd.CommandText = "INSERT INTO tCustomer(fName,fPhone,fEmail,fAddress)" +
        //                     $"VALUES('{fName}','{fPhone}','{fEmail}','{fAddress}')";
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //}
    }
}
