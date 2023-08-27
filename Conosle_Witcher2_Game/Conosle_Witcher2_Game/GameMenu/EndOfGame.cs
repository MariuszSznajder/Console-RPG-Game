using Conosle_Witcher2_Game.State;
using Figgle;

namespace Conosle_Witcher2_Game.GameMenu
{
    internal class EndOfGame
    {
        private static bool keepPlaying = true;
        public static bool UserDecision()
        {
            Console.WriteLine("Are you sure you want to quit? (Y/N)");
            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key == ConsoleKey.Y)
            {
                if (key.Key == ConsoleKey.Y)
                {
                    Console.WriteLine("Do you want to save your current achievements (Y/N)?");
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Y)
                    {
                        Console.WriteLine("Saving game...");
                        Thread.Sleep(500);
                        BattleState.SavingSettings();
                        Thread.Sleep(1000);
                        Menu.PressEnter();
                        Environment.Exit(0);
                    }
                    if (key.Key == ConsoleKey.N)
                    {
                        Thread.Sleep(1000);
                        Menu.PressEnter();
                        Environment.Exit(0);
                    }
                }
            }
            while (key.Key == ConsoleKey.N)
            {
                keepPlaying = true;
                break;
            };
            return false;
        }

        public static void Winner(int playerWins, int monsterWins, string player, string monster)
        {
            Console.Write(FiggleFonts.Standard.Render($"Final Score: {player}: {playerWins} : {monster}: {monsterWins} "));
            Task.Delay(5000).Wait();
            Console.Clear();


            Console.ForegroundColor = ConsoleColor.Yellow;
            if (playerWins == monsterWins)
            {
                Settings.TextPosition.SetWriteLineTextPosition($"We have a draw! try you luck again!");
                Menu.PressEnter();
            }
            if (playerWins != monsterWins)
            {
                if (playerWins > monsterWins)
                {
                    Console.Write(FiggleFonts.Standard.Render($"Trophy goes to: {player}"));
                    Task.Delay(5000).Wait();
                    Console.Clear();
                    Settings.TextPosition.SetWriteLineTextPosition($"   {player}");
                    Trophy();
                    Menu.PressEnter();
                }
                else
                {
                    Console.Write(FiggleFonts.Standard.Render($"Trophy goes to: {monster}"));
                    Thread.Sleep(5000);
                    Console.Clear();
                    Settings.TextPosition.SetWriteLineTextPosition($"   {monster}");
                    Trophy();
                    Menu.PressEnter();
                }
            }
            Console.ResetColor();
        }

        public static void Trophy()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Settings.TextPosition.SetWriteLineTextPosition("     ____________");
            Settings.TextPosition.SetWriteLineTextPosition("     |          |");
            Settings.TextPosition.SetWriteLineTextPosition(@"    /|          |\");
            Settings.TextPosition.SetWriteLineTextPosition("    | |  TROPHY  | |");
            Settings.TextPosition.SetWriteLineTextPosition(@"    \|          |/");
            Settings.TextPosition.SetWriteLineTextPosition("     |          |");
            Settings.TextPosition.SetWriteLineTextPosition("     |__________|");
            Settings.TextPosition.SetWriteLineTextPosition(@"     \      /");
            Settings.TextPosition.SetWriteLineTextPosition(@"     \____/");
            Console.ResetColor();
        }
    }
}
