using Conosle_Witcher2_Game.Settings;

namespace Conosle_Witcher2_Game.State
{
    public class ExploreState : IState
    {
        private RPGController context;

        public ExploreState(RPGController context)
        {
            this.context = context;
        }

        #region IState Members

        public int Explore()
        {
            Console.WriteLine("You look around for something to kill.");

            int ran = RandomGenerator.RandomNumberGenerator(5);
            if (ran == 0 || ran == 3)
            {
                Console.WriteLine("A monster approaches! Prepare for battle!");
                context.SetState(context.GetBattleState());
            }
            return 0;
        }

        public int Battle(int level)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Keep searching for monster!");
            Console.ResetColor();
            return 0;
        }

        #endregion
    }
}
