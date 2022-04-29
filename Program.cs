using System;
using System.Configuration;
using Figgle;
using System.Data.SQLite;


namespace Diary_1._0
{
    class Program
    {

        static void Main(string[] args)
        {
          Create_table();
            Console.WriteLine(
                FiggleFonts.Slant.Render("Diary v 1.0"));
            Console.WriteLine("1. Create a note / Vytvořit poznámku");
            Console.WriteLine("2. Show all notes / Zobrazit všechny poznámky ");
            Console.WriteLine("3. Delete all notes / Odstranit všechny poznámky");
            Console.WriteLine("4. Exit the app / Ukončit aplikaci");
            while (true)
            {
                string input_answer = "0";
                input_answer = Console.ReadLine();
               

                switch (input_answer)
                {
                    case "1":
                        Create_Note();
                        Console.WriteLine("Enter the function number / Zadejte číslo funkce");
                        continue;
                    case "2":
                        Display_all_notes();
                        Console.WriteLine("Enter the function number / Zadejte číslo funkce");
                        continue;
                    case "3":
                        Deleta_all_notes();
                        Console.WriteLine("Enter the function number / Zadejte číslo funkce");
                        continue;
                    case "4":
                        Console.WriteLine("End of the program / Konec programu");
                        return;
                    default: 
                        Console.WriteLine("Enter the function number / Zadejte číslo funkce");
                        continue;
                        
                }

            }

           
        }

        static void Create_Note()
        {
            Console.WriteLine("Write a note / Napište poznámku");
            Database databaseObject = new Database();
            string note = Console.ReadLine();
            DateTime thisDay = DateTime.Now;
            string query = "INSERT INTO notes (note, time) VALUES";
            query += string.Format("('{0}','{1}')", note, thisDay);
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            command.ExecuteNonQuery();
            databaseObject.CloseConnection();
            Console.WriteLine("Note created / Poznámka vytvořena");
        }

        static void Display_all_notes()
        {
            Database databaseObject = new Database();
            string query = "SELECT * FROM notes";
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            SQLiteDataReader result = command.ExecuteReader();
            Console.WriteLine("-------------------------------------------------------------");
            if (result.HasRows)
            {
                while (result.Read())
                {
                    Console.WriteLine("{0} ", result["time"]);
                    Console.WriteLine("{0} ", result["note"]);
                    Console.WriteLine("-------------------------------------------------------------");
                }
            }
            databaseObject.CloseConnection();
            Console.WriteLine("notes displayed / zobrazené poznámky.");
        }

        static void Deleta_all_notes()
        {
            Database databaseObject = new Database();
            string query = "DELETE FROM notes";
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            command.ExecuteNonQuery();
            databaseObject.CloseConnection();
            Console.WriteLine("Notes deleted / Poznámky odstraněny");
        }

        static void Create_table()
        {
            Database databaseObject = new Database();
            string query = "CREATE TABLE IF NOT EXISTS notes (note TEXT NOT NULL, time TEXT NOT NULL); ";
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            command.ExecuteNonQuery();
            databaseObject.CloseConnection();
            
        }
     
    }
}