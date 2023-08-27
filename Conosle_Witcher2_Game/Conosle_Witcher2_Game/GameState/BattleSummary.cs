using Figgle;

namespace Conosle_Witcher2_Game.GameState
{
    internal class BattleSummary
    {
        public static void EndOfBattle(string summary, int timer)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(FiggleFonts.Standard.Render(summary));
            for (int i = 0; i < timer; i++)
            {
                Thread.Sleep(300);
            }
            Console.ResetColor();
            Console.Clear();
        }

        public static void DisplayMessage(string message, int timer)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(message);
            for (int i = 0; i < timer; i++)
            {
                Thread.Sleep(300);
            }
            Console.ResetColor();
            Console.Clear();
        }
    }
}
