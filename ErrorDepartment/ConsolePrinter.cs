#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace ErrorDepartment
{
    public static class ConsolePrinter
    {
        /// <summary>
        /// Prints red words.
        /// Use it to indicate an error.
        /// </summary>
        /// <param name="s"></param>
        public static void RedPrint(string s)
        {
            var bC = Console.BackgroundColor;
            var fC = Console.ForegroundColor;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);

            Console.BackgroundColor = bC;
            Console.ForegroundColor = fC;
        }
        /// <summary>
        /// Prints green words.
        /// Use it to indicate success.
        /// </summary>
        /// <param name="s"></param>
        public static void GreenPrint(string s)
        {
            var bC = Console.BackgroundColor;
            var fC = Console.ForegroundColor;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);

            Console.BackgroundColor = bC;
            Console.ForegroundColor = fC;
        }
        /// <summary>
        /// Prints blue words.
        /// Use it to indicate loading.
        /// </summary>
        /// <param name="s"></param>
        public static void BluePrint(string s)
        {
            var bC = Console.BackgroundColor;
            var fC = Console.ForegroundColor;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(s);

            Console.BackgroundColor = bC;
            Console.ForegroundColor = fC;
        }
        /// <summary>
        /// Prints yellow words.
        /// Use it to indicate problems that
        /// may be annoyances, small bugs, or whatever.
        /// </summary>
        /// <param name="s"></param>
        public static void YellowPrint(string s)
        {
            var bC = Console.BackgroundColor;
            var fC = Console.ForegroundColor;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s);

            Console.BackgroundColor = bC;
            Console.ForegroundColor = fC;
        }
        /// <summary>
        /// Prints gray words.
        /// Use it to display the exceptions on
        /// screen to confuse normal human beings.
        /// </summary>
        /// <param name="s"></param>
        public static void GrayPrint(string s)
        {
            var bC = Console.BackgroundColor;
            var fC = Console.ForegroundColor;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(s);

            Console.BackgroundColor = bC;
            Console.ForegroundColor = fC;
        }
    }
}
