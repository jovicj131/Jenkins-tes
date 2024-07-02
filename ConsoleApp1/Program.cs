using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MySqlConnector;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 15; i++)
            {
                panggil();
                Console.WriteLine();
            }


        }
        public static void panggil()
        {
            Connection conn = new Connection();
            string Sql = string.Empty;

            try
            {
                if (Connection.GetClientConn.State == ConnectionState.Closed)
                    Connection.GetClientConn.Open();

                Sql = "Update `" + Connection.GetClientConn.Database + "`.`counter_scale` set counter = NOW();";

                using (MySqlCommand cmd = new MySqlCommand(Sql, Connection.GetClientConn))
                {
                    cmd.ExecuteNonQuery();
                }
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }
    }
}
