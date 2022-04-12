using System;
using Figgle;
using System.Data.SQLite;


namespace Diary_1._0
{
    class Program
    {

        static void Main(string[] args)
        {
            Database databaseObject = new Database();
            Console.WriteLine(
                FiggleFonts.Slant.Render("Diary v 1.0"));
            Console.WriteLine("1. Create note [1]");
            Console.WriteLine("2. Display notes [2]");
            Console.WriteLine("3. Delete [d]");
            Console.WriteLine("4. Exit [E]");
            string answer = "0";
                answer = Console.ReadLine();
           
            if (int.Parse(answer) == 1 && answer != "0")
            {
                Console.Write(" Введите ноавую запись:  ");
                string note = Console.ReadLine();
                DateTime thisDay = DateTime.Now;
                string query = "INSERT INTO notes (note, datum) VALUES";
                query += string.Format("({0},{1})", note, note);
                SQLiteCommand command = new SQLiteCommand(query, databaseObject.myConnection);
                databaseObject.OpenConnection();
               // command.Parameters.AddWithValue("@note", note);
               // command.Parameters.AddWithValue("@date", thisDay);
                command.ExecuteNonQuery();
                databaseObject.CloseConnection();
                Console.WriteLine("Запись создана");
                
            }
            else if (int.Parse(answer) == 2)
            {
                string query = "SELECT * FROM sqlite_master";
                SQLiteCommand command = new SQLiteCommand(query, databaseObject.myConnection);
                databaseObject.OpenConnection();
                SQLiteDataReader result = command.ExecuteReader();
                if (result.HasRows)
                {
                    while (result.Read())
                    {
                        Console.WriteLine("Name: {0} ", result["name"]);
                        //Console.WriteLine("Note: {0} ", result["note"]);
                    }
                }
                databaseObject.CloseConnection();
            }else
            {
                
            }
        }
     
    }
}