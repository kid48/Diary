using System;
using Figgle;

namespace Diary_1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
            FiggleFonts.Slant.Render("Diary v 1.0"));
            Console.WriteLine("1. Create note [c]");
            Console.WriteLine("2. Edit note [e]");
            Console.WriteLine("3. Delete [d]");
            Console.WriteLine("4. Exit [E]");
            var answer = Console.ReadKey().KeyChar;
            switch (answer)
            {
                case 'c':
                    break;
                case 'e':
                    break;
                case 'd':
                    break;
                case 'E':
                    break;
            }
            
          
        }
    }
}
