namespace Conosle_Witcher2_Game.Models.MonsterData
{
    internal class RandomMonsterGenerator
    {
        public Monster GenerateMonster()
        {
            MonsterFactory monsterFactory = new MonsterFactory();
            IMonster monster = monsterFactory.CreateMonster();
            Monster createdMonster = monster.CreateMonster();
            return createdMonster;
        }
    }
}
