namespace Conosle_Witcher2_Game.Models.MonsterData
{
    internal class Lubberkin : IMonster
    {
        public Monster CreateMonster()
        {
            return new Monster
            {
                MonsterName = "Lubberkin",
                MaximumHitPoints = 20,
                CurrentHitPoints = 10,
            };
        }
    }
}
