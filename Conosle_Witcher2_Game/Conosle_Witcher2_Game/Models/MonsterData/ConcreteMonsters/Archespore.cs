namespace Conosle_Witcher2_Game.Models.MonsterData.ConcreteMonsters
{
    internal class Archespore : IMonster
    {
        public Monster CreateMonster()
        {
            return new Monster
            {
                MonsterName = "Archespore",
                MaximumHitPoints = 15,
                CurrentHitPoints = 10,
            };

        }

    }
}
