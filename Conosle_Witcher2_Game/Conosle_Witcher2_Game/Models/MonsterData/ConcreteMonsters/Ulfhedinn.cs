namespace Conosle_Witcher2_Game.Models.MonsterData
{
    internal class Ulfhedinn : IMonster
    {
        public Monster CreateMonster()
        {
            return new Monster
            {
                MonsterName = "Ulfhedinn",
                MaximumHitPoints = 23,
                CurrentHitPoints = 10,
            };
        }
    }
}
