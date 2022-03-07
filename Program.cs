using System;
using Figgle;
using System.Data.SQLite;

namespace Diary_1._0
{
    class Program
    {
        static SQLiteConnection connection;
        static SQLiteCommand command;

        static public bool Connect(string fileName)
        {
            try
            {
                connection = new SQLiteConnection("Data Source=" + fileName + ";Version=3; FailIfMissing=False");
                connection.Open();
                return true;
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
                return false;
            }
        }

 

 

        static void Main(string[] args)
        {
            if (Connect("main.db"))
            {
                Console.WriteLine("Connected");
            }

            Console.WriteLine(
                FiggleFonts.Slant.Render("Diary v 1.0"));
            Console.WriteLine("1. Create note [1]");
            Console.WriteLine("2. Edit note [2]");
            Console.WriteLine("3. Delete [d]");
            Console.WriteLine("4. Exit [E]");
            string answer = Console.ReadLine();
           
            if (int.Parse(answer) == 1)
            {
                string note = Console.ReadLine();
                string request = GenerateRequest(note);
                Console.WriteLine(value: request);
            }
            else if (int.Parse(answer) == 2)
            {
                fact(8);
            }else
            {
                
            }
        }
        static string GenerateRequest(string note)
        {
            DateTime thisDay = DateTime.Today;
            return $"INSERT INTO notes (note, time) VALUES ('{note}', '{thisDay}');";
        }
        static int fact(int cislo)
        {
            if (cislo > 1)
            {
                int result = 1;
                int i = 1;
                while (i <= cislo)
                {
                    result = result * i;
                    i++;
                    
                }
                return cislo;
            }else
            {
                return 1;
            }
        }
    }
}