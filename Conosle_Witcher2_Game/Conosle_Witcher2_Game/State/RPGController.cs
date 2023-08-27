namespace Conosle_Witcher2_Game.State
{
    public class RPGController
    {
        private IState exploreState;
        private IState battleState;
        private IState state;
        private int level = 1;


        public RPGController()
        {
            exploreState = new State.ExploreState(this);
            battleState = new State.BattleState(this);

            state = exploreState;
        }

        public int Explore()
        {
            return state.Explore();
        }

        public int Battle(int level)
        {
            return state.Battle(level);
        }

        public void SetState(IState state)
        {
            this.state = state;
        }

        public void SetLevel(int level)
        {
            this.level = level;
        }

        public int GetLevel()
        {
            return level;
        }

        public IState GetExploreState()
        {
            return exploreState;
        }

        public IState GetBattleState()
        {
            return battleState;
        }
    }
}
