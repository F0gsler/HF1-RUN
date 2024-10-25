using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Methods
{
    internal class Welcome
    {
        public Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to HANGMAN!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
