using MySql.Data.MySqlClient;
using System.Data;

namespace ATM_CONSOLE_APPLICATION.Model
{
    public static class DBHelper
    {
        public static MySqlConnection? Connection = null;
        public static MySqlConnection connectStr(string host, int port, string database, string userdb, string passdb)
        {
            string connStr = $"Server={host};Port={port};Database={database};Uid={userdb};Pwd={passdb};";
            Connection = new MySqlConnection(connStr);
            return Connection;
        }
        public static MySqlConnection Open()
        {
            if (Connection == null)
            {
                Connection = MySql();
            }
            do
            {
                try
                {
                    if (Connection.State == ConnectionState.Closed)
                    {
                        Connection.Open();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Thread.Sleep(3000);
                }
                if (Connection.State == ConnectionState.Open)
                {
                    break;
                }
            } while (true);
            return Connection;
        }
        public static void Close()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
        public static MySqlConnection MySql()
        {
            string host = "103.149.28.150";
            int port = 3306;
            string database = "atm";
            string userdb = "atm";
            string passdb = "123456789a";
            return connectStr(host, port, database, userdb, passdb);
        }
    }
}
