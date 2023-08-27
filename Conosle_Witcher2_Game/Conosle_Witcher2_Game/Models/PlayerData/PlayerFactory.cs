namespace Conosle_Witcher2_Game.Models.PlayerData
{
    internal class PlayerFactory : IPlayer
    {
        private static PlayerFactory _instance;
        private readonly IPlayer _player;

        public PlayerFactory(IPlayer player)
        {
            _player = player;
        }

        public static PlayerFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerFactory(new ConcretePlayer());
                }
                return _instance;
            }
        }

        public Player CreatePlayer()
        {
            return _player.CreatePlayer();
        }
    }
}
