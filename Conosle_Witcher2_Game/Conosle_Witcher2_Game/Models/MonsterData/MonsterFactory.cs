using Conosle_Witcher2_Game.Models.MonsterData.ConcreteMonsters;

namespace Conosle_Witcher2_Game.Models.MonsterData
{
    internal class MonsterFactory
    {
        private readonly Random random;

        public MonsterFactory()
        {
            this.random = new Random();
        }
        public IMonster CreateMonster()
        {
            int monsterType = random.Next(1, 5);

            return monsterType switch
            {
                1 => new Archespore(),
                2 => new Lubberkin(),
                3 => new Succubus(),
                4 => new Ulfhedinn(),
            };
        }
    }
}
