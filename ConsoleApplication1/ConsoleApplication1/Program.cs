using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)       
        {
            string message = "";
            Bot chatBot = new Bot();

            Console.WriteLine("Witaj w chatbocie! Jeśli chcesz zakończyć rozmowę wpisz \"koniec\". Czat działa w języku polskim. Chatbot jest w wersji alpha więc prosimy używać tylko małych liter. Polskie znaki niestety nie są mile widziane. \n");

            while (message != "koniec")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                message = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(chatBot.Response(message));
            }

            chatBot.SaveData();
        }
    }
}
