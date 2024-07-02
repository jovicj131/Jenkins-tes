using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace ConsoleApp1
{
    internal class Connection
    {
        public static MySqlConnection ConnClient;
        public static string ConnStrClient = "server=172.24.16.136;port=3306;" + "user id=prog;password=ind0M4rcO^Pri$;database=test_jovi;" + "Persist Security Info=True;pooling=false;connection timeout=500";


        public Connection()
        {
            ConnClient = GetKoneksi(ConnStrClient);
        }

        public static MySqlConnection GetKoneksi(string ConnStr)
        {
            MySqlConnection Mcon = new MySqlConnection();
            try
            {
                Mcon = new MySqlConnection(ConnStr);
                return (MySqlConnection)Mcon.Clone();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message, "KoneksiMySQL");
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "KoneksiMySQL");
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }
        public static MySqlConnection GetClientConn
        {
            get
            {
                return ConnClient;
            }
        }
    }
}
