using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace SieuThiMini.DAL
{
    class DataConnection
    {
        public MySqlConnection conn = null;
        string strConn = @"SERVER=localhost; uid=root; DATABASE=sieu_thi_mini; port=3306";


        public void Moketnoi()
        {
            if (conn == null)
            {
                conn = new MySqlConnection(strConn);
                conn.Open();
                Console.WriteLine("Mo ket noi");
            }
            if (conn.State == ConnectionState.Closed)
            {
                Console.WriteLine("Mo ket noi");
                conn.Open();
            }
        }

        public void Dongketnoi()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
