using System;
using System.Configuration;
using Figgle;
using System.Data.SQLite;


namespace Diary_1._0
{
    class Program
    {
    //Starting the program and waiting for user input
    //Zahájení programu a čekání na vstup uživatele
        static void Main(string[] args)
        {
            //Creating a table if it did not exist.
            //Vytvoření tabulky, pokud neexistovala.
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
                        //Using the function to create a note
                        //Použití funkce pro vytvoření poznámky
                        CreateNote();
                        Console.WriteLine("Enter the function number / Zadejte číslo funkce");
                        continue;
                    case "2":
                        //Using the function to display all notes
                        //Použití funkce pro zobrazení všech poznámek
                        DisplayAllNotes();
                        Console.WriteLine("Enter the function number / Zadejte číslo funkce");
                        continue;
                    case "3":
                        //Using the function to delete all notes
                        //Použití funkce pro odstranění všech poznámek
                        DeleteAllNotes();
                        Console.WriteLine("Enter the function number / Zadejte číslo funkce");
                        continue;
                    case "4":
                        //Choose this to end the program
                        // Zvolte toto pro ukončení programu
                        Console.WriteLine("End of the program / Konec programu");
                        return;
                    default: 
                        //Filtering out incorrect numbers and signs
                        //Odstranění nesprávných čísel a značek
                        Console.WriteLine("Enter the function number / Zadejte číslo funkce");
                        continue;
                        
                }

            }

           
        }
        //This function creates notes and writes them to the Database
        //Tato funkce vytváří poznámky a zaznamenává a do databáze
        //
        //
        //
        static void CreateNote()
        {
            Console.WriteLine("Write a note / Napište poznámku");
            //Defining the database
            //Definujeme dB
            Database databaseObject = new Database();
            
            string note = Console.ReadLine();
            
            //Getting the current time
            //Získáme aktuální čas
            DateTime thisDay = DateTime.Now;
            
            //Forming a query to the database
            //Vytvoření dotazu do databáze
            string query = "INSERT INTO notes (note, time) VALUES";
            
            //Adding parameters to the query
            //Přidání parametrů do dotazu
            query += string.Format("('{0}','{1}')", note, thisDay);
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.myConnection);
            
            //Opening the connection to DB
            //Otevírám připojení k DB
            databaseObject.OpenConnection();
            
            //Executing a query to the database
            //Spuštění dotazu do databáze
            command.ExecuteNonQuery();
            
            //Closing the connection to the database
            //Uzavřeme spojení s DB
            databaseObject.CloseConnection();
            Console.WriteLine("Note created / Poznámka vytvořena");
        }
        //It works the same way here
        //This function outputs all notes
        //Zde funguje podobně
        //Tato funkce zobrazuje všechny poznámky
        static void DisplayAllNotes()
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
        //This function deletes all notes
        //Tato funkce odstraní všechny poznámky
        static void DeleteAllNotes()
        {
            Database databaseObject = new Database();
            string query = "DELETE FROM notes";
            SQLiteCommand command = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            command.ExecuteNonQuery();
            databaseObject.CloseConnection();
            Console.WriteLine("Notes deleted / Poznámky odstraněny");
        }
        //This function creates a table if it wasn't there before.
        //Tato funkce vytvoří tabulku, pokud nebyla předtím.
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