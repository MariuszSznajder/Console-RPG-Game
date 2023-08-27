namespace Conosle_Witcher2_Game.Models.MonsterData
{
    internal class Succubus : IMonster
    {
        public Monster CreateMonster()
        {
            return new Monster
            {
                MonsterName = "Succubus",
                MaximumHitPoints = 18,
                CurrentHitPoints = 10,
            };
        }
    }
}
