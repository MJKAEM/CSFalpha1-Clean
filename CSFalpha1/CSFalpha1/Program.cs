#region Using Statements
using System;
using Microsoft.Xna.Framework.Content;
using ErrorDepartment;
#endregion

namespace CSFalpha1
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            byte exitCode = 0;
            using (Main game = new Main())
            {
                //try
                //{
                    game.Run();
                //}
                    /*
                #region Possible Exceptions in Gaming
                catch (NullReferenceException)
                {
                    exitCode = 2;
                    game.Exit();
                }
                catch (OutOfMemoryException)
                {
                    exitCode = 3;
                    game.Exit();
                }
                catch (ContentLoadException)
                {
                    exitCode = 5;
                    game.Exit();
                }
                #endregion
                #region Possible Exceptions in Debug
                catch (NotImplementedException)
                {
                    exitCode = 101;
                    game.Exit();
                }
                catch (IndexOutOfRangeException)
                {
                    exitCode = 102;
                    game.Exit();
                }
                catch (InvalidCastException)
                {
                    exitCode = 103;
                    game.Exit();
                }
                catch (StackOverflowException)
                {
                    exitCode = 104;
                    game.Exit();
                }
                #endregion
                catch
                {
                    exitCode = 255;
                    game.Exit();
                }
                */
            }
            switch (exitCode)
            {
                case 0:
                    return;
                case 2:
                    ConsolePrinter.RedPrint("The game exited with code 2: NullReferenceException.");
                    break;
                case 3:
                    ConsolePrinter.RedPrint("The game exited with code 3: OutOfMemoryException.");
                    ConsolePrinter.RedPrint("Either the game has laggy code or you need to get a better computer.\n(Very likely the former)");
                    break;
                case 5:
                    ConsolePrinter.RedPrint("The game exited with code 5: ContentLoadException.");
                    break;
                case 101:
                    ConsolePrinter.RedPrint("The game exited with code 101: NotImplementedException.");
                    break;
                case 102:
                    ConsolePrinter.RedPrint("The game exited with code 102: IndexOutOfRangeException.");
                    break;
                case 103:
                    ConsolePrinter.RedPrint("The game exited with code 103: InvalidCastException.");
                    break;
                case 104:
                    ConsolePrinter.RedPrint("The game exited with code 104: StackOverflowException.");
                    break;
                case 255:
                    ConsolePrinter.RedPrint("The game exited with code 255: Unknown Error Exception.");
                    break;
                default:
                    ConsolePrinter.RedPrint("The developers forgot about your exception. Send this:");
                    ConsolePrinter.RedPrint("Hey developer! You missed out on exit code: " + exitCode);
                    break;
            }
            Console.ReadKey();
        }
    }
#endif
}

