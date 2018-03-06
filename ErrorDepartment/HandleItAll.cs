#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
#endregion

namespace ErrorDepartment
{
    public class HandleItAll
    {
        /// <summary>
        /// The game's response to failures in the game.
        /// It returns true if you say yes. It returns false for anything else.
        /// It also forms humorous responses.
        /// </summary>
        public static bool ResponseToFailure()
        {
            Console.WriteLine("Do you still want to continue? Y/N\n");

            string tempCatch = Console.ReadLine().ToLower().Trim();

            for (int i = tempCatch.Length - 1; i >= 0; i--)
            {
                if (tempCatch[i] == '.' || tempCatch[i] == '!' || tempCatch[i] == '?')
                {
                    tempCatch = tempCatch.Substring(0, i);
                }
            }

            tempCatch = tempCatch.Trim();

            switch (tempCatch)
            {
                case "y":
                case "yes":
                case "hai":
                case "ee":
                case "ja":
                case "yao":
                case "yiu":
                case "jiu":
                    return false;

                case "narf":
                    Console.WriteLine("\nNarf!");
                    Console.ReadKey();
                    return true;

                case "martino":
                case "kuan":
                case "martino kuan":
                    Console.WriteLine("He created the game. Thank you for playing!");
                    Console.ReadKey();
                    return true;

                case "is there a cow level":
                case "cow level":
                case "there is a cow level":
                    Console.WriteLine("\nThere is no cow level.");
                    Console.ReadKey();
                    return true;

                case "who created this":
                case "maker":
                case "creator":
                    Console.WriteLine("\n" + char.ConvertFromUtf32(77) + char.ConvertFromUtf32(97) + char.ConvertFromUtf32(114)
                        + char.ConvertFromUtf32(116) + char.ConvertFromUtf32(105) + char.ConvertFromUtf32(110)
                        + char.ConvertFromUtf32(111) + char.ConvertFromUtf32(32) + char.ConvertFromUtf32(75)
                        + char.ConvertFromUtf32(117) + char.ConvertFromUtf32(97) + char.ConvertFromUtf32(110));
                    Console.ReadKey();
                    return true;

                case "i am your father":
                case "no, i am your father":
                case "no i am your father":
                    Console.WriteLine("\nThat's impossible!");
                    Console.ReadKey();
                    Console.WriteLine("\nNOOO!!!");
                    Console.ReadKey();
                    return true;

                case "rick roll":
                case "rick roll'd":
                case "rick rolld":
                    Console.Write("You've been rick roll'd!");
                    Process.Start("http://www.youtube.com/watch?v=oHg5SJYRHA0");
                    Console.WriteLine();
                    Console.ReadKey();
                    return true;
            }

            if (tempCatch.Length >= 3 && tempCatch.Substring(0, 3).Equals("moo") &&
                (tempCatch.Substring(tempCatch.Length - 3, 3).Equals("oo.") ||
                tempCatch.Substring(tempCatch.Length - 3, 3).Equals("oo!") ||
                tempCatch.Substring(tempCatch.Length - 2, 2).Equals("oo")))
            {
                for (int i = 1; i < tempCatch.Length - 1; i++)
                {
                    if (tempCatch[i] != 'o')
                    {
                        Console.WriteLine("That is not how a cow sounds. You lie.");
                        Console.ReadKey();
                        return true;
                    }
                }
                Console.WriteLine("\nYes, that is a cow.");
                Console.ReadKey();
                return true;
            }


            else if (!(tempCatch.Equals("no") || tempCatch.Equals("n") ||
                tempCatch.Equals("nein") || tempCatch.Equals("iie") ||
                tempCatch.Equals("bu yao") || tempCatch.Equals("buyao") ||
                tempCatch.Equals("m yiu") || tempCatch.Equals("ng yiu") ||
                tempCatch.Equals("ngyiu") || tempCatch.Equals("myiu") ||
                tempCatch.Equals("ng jiu") || tempCatch.Equals("m jiu") ||
                tempCatch.Equals("ngjiu") || tempCatch.Equals("mjiu")))
            {
                Console.WriteLine("\nEither you wrote something I can't read, or you were being silly.\nPlease form an acceptable response.\n");
                Console.ReadKey();
            }
            return true;
        }
    }
}
