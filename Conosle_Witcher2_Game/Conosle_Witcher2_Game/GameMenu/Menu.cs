using Conosle_Witcher2_Game.Models.PlayerData;
using Conosle_Witcher2_Game.State;
using Figgle;

namespace Conosle_Witcher2_Game.GameMenu
{

    public class Menu
    {
        private static ConsoleKeyInfo consoleKey;
        public static Player concretePlayer = new Player();

        public static void Run()
        {
            LoadingApp(10);
            WelcomeBoard();
            AppMenu();
        }

        public static void LoadingApp(int timer)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Loading");
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(300);
            }
            Console.ResetColor();
            Console.Clear();
        }
        public static void WelcomeBoard()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(FiggleFonts.Standard.Render("-*- Witcher 2 -*-"));
            Console.ResetColor();
            Thread.Sleep(2000);
            Console.Clear();
        }

        public static void AppMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Settings.TextPosition.SetWriteLineTextPosition("Pleaese choose following option:");
            Console.ResetColor();
            Settings.TextPosition.SetWriteLineTextPosition("1. New game.");
            Settings.TextPosition.SetWriteLineTextPosition("2. Load game.");

            consoleKey = Console.ReadKey();

            while (true)
            {
                if (consoleKey.Key == ConsoleKey.D1 || consoleKey.Key == ConsoleKey.D2)
                {
                    break;
                }
                else
                {
                    Settings.TextPosition.SetWriteLineTextPosition("Please choose correct operation:");
                    consoleKey = Console.ReadKey();
                }
            }

            if (consoleKey.Key.Equals(ConsoleKey.D1))
            {
                Console.Clear();
                concretePlayer.PlayerName = GetPlayerName();
                BattleState.player.PlayerName = concretePlayer.PlayerName;
                Console.Clear();
                BattleState.Start();
            }
            if (consoleKey.Key.Equals(ConsoleKey.D2))
            {
                Console.Clear();
                LoadingApp(10);
                Thread.Sleep(1000);
                Console.Clear();
                BattleState.LoadSettings();
                BattleState.Start();
            }
        }

        public static void PressEnter()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Press enter to exit...");
            Console.ResetColor();
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static string GetPlayerName()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Settings.TextPosition.SetWriteLineTextPosition("Please provide player name: ");
            string playerName = Settings.TextPosition.SetReadLineTextPosition();
            while (playerName.Length.Equals(0))
            {
                Settings.TextPosition.SetWriteLineTextPosition("Please provide player name: ");
                playerName = Settings.TextPosition.SetReadLineTextPosition();
            }
            Console.ResetColor();
            return playerName;
        }
    }
}
