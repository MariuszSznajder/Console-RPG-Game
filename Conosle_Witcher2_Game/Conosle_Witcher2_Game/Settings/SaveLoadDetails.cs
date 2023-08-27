using Conosle_Witcher2_Game.GameMenu;
using Conosle_Witcher2_Game.Models.MonsterData;
using Conosle_Witcher2_Game.Models.PlayerData;
using Conosle_Witcher2_Game.Models.WeaponData;
using Conosle_Witcher2_Game.State;
using System.Xml.Serialization;

namespace Conosle_Witcher2_Game.Settings
{
    public class SaveLoadDetails
    {
        private static readonly string path = Directory.GetCurrentDirectory() + "\\gameData.xml";
        private static RandomMonsterGenerator randomMonsterGenerator = new RandomMonsterGenerator();
        private static RandomWeaponGenerator randomWeaponGenerator = new RandomWeaponGenerator();
        public static Player concretePlayer = new Player();


        public int PlayerMaximumHitPoints { get; set; }
        public int PlayerCurrentPoints { get; set; }
        public int PlayerCurrentDamage { get; set; }
        public int PlayerMaximumDamage { get; set; }
        public string _PlayerName { get; set; }

        public int MonsterMaximumHitPoints { get; set; }
        public int MonsterCurrentPoints { get; set; }
        public int MonsterCurrentDamage { get; set; }
        public string _MonsterName { get; set; }

        public int MonsterMaximumDamage { get; set; }

        public int PlayerMaximumShots { get; set; }
        public int PlayerOneShotDamage { get; set; }
        public string PlayerWeaponName { get; set; }

        public int MonsterMaximumShots { get; set; }
        public int MonsterOneShotDamage { get; set; }
        public string MonsterWeaponName { get; set; }
        public int Level { get; set; }

        public static void SaveStateToFile(SaveLoadDetails state)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(SaveLoadDetails));
            using (TextWriter writeFileStream = new StreamWriter(path))
            {
                serializer.Serialize(writeFileStream, state);
            }
        }

        public static SaveLoadDetails LoadStateFromFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SaveLoadDetails));
            if (!File.Exists(path))
            {
                Console.WriteLine("You do not have saved settings. Starting new game.");
                Task.Delay(1000).Wait();
                Console.Clear();

                BattleState.player = BattleState.CreatePlayer();
                concretePlayer.PlayerName = Menu.GetPlayerName();
                Console.Clear();
                BattleState.player.PlayerName = concretePlayer.PlayerName;
                BattleState.monster = randomMonsterGenerator.GenerateMonster();
                BattleState.playerWeapon = randomWeaponGenerator.GenerateWeapon();
                BattleState.monsterWeapon = randomWeaponGenerator.GenerateWeapon();

                BattleState.Start();

            }
            else
            {
                using (FileStream readFileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return (SaveLoadDetails)serializer.Deserialize(readFileStream);
                }
            }
            return null;
        }
    }
}
