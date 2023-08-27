using Figgle;

namespace Conosle_Witcher2_Game.Models.WeaponData
{
    internal class BonusShots
    {
        private static int bonusShots;
        public static int ExtraShots()
        {
            return bonusShots = 5;
        }

        public static void DisplayBonusShots(int timer, string name)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(FiggleFonts.Standard.Render($"{name} Get Bonus Shots!"));
            Console.ResetColor();
            Thread.Sleep(2000);
        }
    }
}
