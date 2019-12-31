using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Data.Connection
{
    public class Connection
    {
        private static Connection _instance = null;
        private static string _connectionString = null;
        static object _syncObject = new object();
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }
        private Connection()
        {
            if (String.IsNullOrEmpty(_connectionString))
            {
                _connectionString = "Server=localhost\\SQLEXPRESS;Database=TicTacToe;Trusted_Connection=True;MultipleActiveResultSets=true";
            }
        }
        public static Connection Current
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new Connection();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}