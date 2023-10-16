using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5HW.Models
{
    internal class Colored
    {
        public static void Write(string text,ConsoleColor color)
        {
            Console.ForegroundColor = color;

            Console.Write(text, Console.ForegroundColor);

            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(text, Console.ForegroundColor);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
