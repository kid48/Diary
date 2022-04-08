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
            string answer = Console.ReadLine();
           
            if (int.Parse(answer) == 1 && answer != null)
            {
                Console.Write(" Введите ноавую запись:  ");
                string note = Console.ReadLine();
                DateTime thisDay = DateTime.Now;
                string query = "INSERT INTO notes (note, date) VALUES (@note, @date);";
                SQLiteCommand command = new SQLiteCommand(query, databaseObject.myConnection);
                databaseObject.OpenConnection();
                command.Parameters.AddWithValue("@note", note);
                command.Parameters.AddWithValue("@date", thisDay);
                command.ExecuteNonQuery();
                databaseObject.CloseConnection();
                Console.WriteLine("Запись создана");
                
            }
            else if (int.Parse(answer) == 2)
            {

            }else
            {
                
            }
        }
     
    }
}