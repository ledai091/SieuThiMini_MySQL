using System;
using System.Data;
using System.Diagnostics;
using MySql.Data.MySqlClient;
namespace SieuThiMini.DAL
{
    class DataProvider
    {
        private static DataProvider _instance;
        public static DataProvider Instance
        {
            get
            {
                if (_instance == null) _instance = new DataProvider();
                return DataProvider._instance;
            }
            private set { DataProvider._instance = value; }
        }
        public DataProvider() { }
        public static string strConn = "SERVER=localhost; uid=root; DATABASE=sieu_thi_mini; port=3306; Convert Zero Datetime=True";
        public static MySqlConnection GetConnection()
        {
            MySqlConnection _conn = new MySqlConnection(strConn);
            return _conn;
        }

        public static void OpenConnection()
        {
            try
            {
                if (GetConnection().State == ConnectionState.Closed)
                {
                    Debug.WriteLine("Connecting to MySQL...");
                    GetConnection().Open();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public static void CloseConnection()
        {
            try
            {
                if (GetConnection().State == ConnectionState.Open)
                {
                    Debug.WriteLine("Disconnecting...");
                    GetConnection().Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public bool ExecuteReader(string query, object[] parameter)
        {
            MySqlConnection _conn = new MySqlConnection(strConn);
            MySqlCommand _command = new MySqlCommand(query, _conn);

            _conn.Open();
            string[] listParameter = query.Split(' ');
            int i = 0;

            foreach (string item in listParameter)
            {
                if (item.Contains("@"))
                {
                    _command.Parameters.AddWithValue(item, parameter[i]);
                    i++;
                }
            }

            MySqlDataReader reader = _command.ExecuteReader();
            if (!reader.HasRows) return false;
            _conn.Close();
            return true;
        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable _dt = new DataTable();

            using (MySqlConnection _conn = new MySqlConnection(strConn))
            {
                _conn.Open();
                using (MySqlCommand _command = new MySqlCommand(query, _conn))
                {
                    if (parameter != null)
                    {
                        // Lấy danh sách tham số từ câu truy vấn (những phần tử có ký hiệu '@')
                        int i = 0;
                        foreach (MySqlParameter param in _command.Parameters)
                        {
                            if (param.ParameterName.StartsWith("@") && i < parameter.Length)
                            {
                                _command.Parameters.AddWithValue(param.ParameterName, parameter[i]);
                                i++;
                            }
                        }
                    }

                    MySqlDataAdapter _da = new MySqlDataAdapter(_command);
                    _da.Fill(_dt);
                }
            }

            return _dt;
        }

        public int ExecuteNonQuery(string query, object[] parameter=null)
        {
            int data = 0;
            MySqlConnection _conn = new MySqlConnection(strConn);
            _conn.Open();
            MySqlCommand _command = new MySqlCommand(query, _conn);

            if (parameter != null)
            {
                string[] listParameter = query.Split(' ');
                int i = 0;
                foreach(string item in listParameter)
                {
                    if (item.Contains("@"))
                    {
                        _command.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }
            data = _command.ExecuteNonQuery();
            Console.WriteLine(data);
            _conn.Close();
            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (GetConnection())
            {
                OpenConnection();
                MySqlCommand _command = new MySqlCommand(query, GetConnection());
                if (parameter != null)
                {
                    string[] listParameter = query.Split(' ');
                    int i = 0;
                    foreach(string item in listParameter)
                    {
                        if(item.Contains("@"))
                        {
                            _command.Parameters.AddWithValue(query, parameter[i]);
                            i++;
                        }
                    }
                }
                data = _command.ExecuteScalar();
                CloseConnection();
            }
            return data;
        } 
        public DataSet ExcuteQueryList(string query, object[] parameter = null)
        {
            DataSet _ds = new DataSet();
            using (GetConnection())
            {
                OpenConnection();
                MySqlCommand _command = new MySqlCommand(query, GetConnection());

                if (parameter != null)
                {
                    string[] listParameter = query.Split(' ');
                    int i = 0;
                    foreach(string item in listParameter)
                    {
                        if (item.Contains("@"))
                        {
                            _command.Parameters.AddWithValue(query, parameter[i]);
                            i++;
                        }
                    }
                }
                MySqlDataAdapter _da = new MySqlDataAdapter(_command);
                _da.Fill(_ds);
                CloseConnection();
            }
            return _ds;
        }
    }
}
