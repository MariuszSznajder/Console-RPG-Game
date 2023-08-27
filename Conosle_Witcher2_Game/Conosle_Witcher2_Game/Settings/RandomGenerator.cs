namespace Conosle_Witcher2_Game.Settings
{
    internal class RandomGenerator
    {
        private static Random random = new Random();
        public static int RandomNumberGenerator(int max)
        {
            return random.Next(max);
        }
    }
}
