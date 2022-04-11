using System;
using System.Data.SQLite;
using System.IO;

namespace Diary_1._0

{
    public class Database
    {
        public SQLiteConnection myConnection;

        public Database()
        {
            myConnection = new SQLiteConnection("Data Source=main.db;Version=3;");
            if (!File.Exists("./main.db")){}
            {
                SQLiteConnection.CreateFile("main.db");
            }
        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
    }
}