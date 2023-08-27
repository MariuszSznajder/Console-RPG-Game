namespace Conosle_Witcher2_Game.Models.PlayerData
{
    internal class ConcretePlayer : IPlayer
    {
        public Player CreatePlayer()
        {
            return new Player()
            {
                MaximumHitPoints = 20,
                CurrentHitPoints = 10,
            };
        }
    }
}
