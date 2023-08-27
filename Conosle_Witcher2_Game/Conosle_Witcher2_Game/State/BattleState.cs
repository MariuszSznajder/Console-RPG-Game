using Conosle_Witcher2_Game.GameMenu;
using Conosle_Witcher2_Game.GameState;
using Conosle_Witcher2_Game.Models.MonsterData;
using Conosle_Witcher2_Game.Models.PlayerData;
using Conosle_Witcher2_Game.Models.WeaponData;
using Conosle_Witcher2_Game.Settings;

namespace Conosle_Witcher2_Game.State
{
    public class BattleState : IState
    {
        private static readonly RPGController context = new RPGController();
        private static ConcretePlayer concretePlayer = new ConcretePlayer();

        public static Player? player;
        public static Monster? monster;
        public static Weapon? playerWeapon;
        public static Weapon? monsterWeapon;
        private static RandomMonsterGenerator randomMonsterGenerator;
        private static RandomWeaponGenerator randomWeaponGenerator;
        private static Level level = new Level();
        private static BattleStatistics statistics = new BattleStatistics();

        public BattleState(RPGController context)
        {
            randomMonsterGenerator = new RandomMonsterGenerator();
            randomWeaponGenerator = new RandomWeaponGenerator();
            player = CreatePlayer();
            monster = randomMonsterGenerator.GenerateMonster();
            playerWeapon = randomWeaponGenerator.GenerateWeapon();
            monsterWeapon = randomWeaponGenerator.GenerateWeapon();

        }

        public static void Start()
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            do
            {
                if (level.CurrentLevel <= level.FinalLevel)
                {
                    DisplayCurrentState();
                    key = Console.ReadKey();
                    Console.WriteLine();
                    DoAction(key.Key, context);
                }
                else
                {
                    break;
                }

            } while (key.Key != ConsoleKey.Q);
            Task.Delay(1000);
            Console.Clear();
            EndOfGame.Winner(statistics.playerWins, statistics.monsterWins, player.PlayerName, monster.MonsterName);
        }

        public static Player CreatePlayer()
        {
            PlayerFactory playerFactory = new PlayerFactory(new ConcretePlayer());
            return playerFactory.CreatePlayer();
        }

        public int Explore()
        {
            Console.WriteLine("You'd love to, but see, there's this big ugly monster in front of you!");
            return 0;
        }


        public int Battle(int maxRan)
        {

            Console.Write("You try to slay the monster.. ");

            Thread.Sleep(1000);

            maxRan = 7;

            int run = RandomGenerator.RandomNumberGenerator(maxRan);

            if (level.CurrentLevel <= level.FinalLevel)
            {
                if (run.Equals(1) || run.Equals(3) || run.Equals(5))
                {
                    Console.WriteLine($"He get shot! {player.PlayerName} get HP! {monster.MonsterName} lose HP!");
                    player.CurrentHitPoints += playerWeapon.OneShotDamage;
                    monster.CurrentHitPoints -= playerWeapon.OneShotDamage;
                    playerWeapon.MaximumShots -= 1;

                    BattleLogic();
                }
                else
                {
                    Console.WriteLine("but fail.");
                    playerWeapon.MaximumShots -= 1;
                }
                if (run.Equals(6) || run.Equals(7))
                {
                    playerWeapon.MaximumShots += BonusShots.ExtraShots();
                    BonusShots.DisplayBonusShots(2, player.PlayerName);
                }
                if (run.Equals(0))
                {
                    monsterWeapon.MaximumShots += BonusShots.ExtraShots();
                    BonusShots.DisplayBonusShots(2, monster.MonsterName);
                }
                if (run.Equals(2) || run.Equals(4))
                {
                    Console.WriteLine($"The monster counterattacks! {monster.MonsterName} get HP! {player.PlayerName} lose HP!");

                    player.CurrentHitPoints -= 1;
                    monsterWeapon.MaximumShots -= 1;
                    monster.CurrentHitPoints += 1;
                    monsterWeapon.MaximumShots -= 1;
                    BattleLogic();

                }
                if (level.CurrentLevel > level.FinalLevel)
                {
                    Console.Clear();
                    EndOfGame.Winner(statistics.playerWins, statistics.monsterWins, player.PlayerName, monster.MonsterName);
                }
            }
            return 0;
        }

        #region

        public static void DisplayCurrentState()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Level [" + level.CurrentLevel + "]; Player Wins: [" + statistics.playerWins + "]; Monster Wins[" + statistics.monsterWins + "];");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Current " + player.PlayerName + " " + "HP: " + player.CurrentHitPoints + "; Weapon: " + playerWeapon.WeaponName + "; Weapon Max Shots: " + playerWeapon.MaximumShots + " \n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Current " + monster.MonsterName + " " + "HP: " + monster.CurrentHitPoints + " Weapon: " + monsterWeapon.WeaponName + "; Weapon Max Shots: " + monsterWeapon.MaximumShots + "  ");
            Console.ResetColor();
            Console.WriteLine("Action [L,A,Q]: L = Look Around, A = Attack, Q = Quit\n");
        }

        private static void DoAction(ConsoleKey key, RPGController context)
        {

            int level = 1;

            if (key == ConsoleKey.L)
            {
                context.Explore();
            }
            else if (key == ConsoleKey.A)
            {
                context.Battle(level);
            }
            else if (key == ConsoleKey.Q)
            {
                if (!EndOfGame.UserDecision())
                {
                    Start();
                }
            }
            else if (key != ConsoleKey.L || key != ConsoleKey.A || key != ConsoleKey.Q)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter correct key!");
                Console.ResetColor();
            }

        }

        private static void BattleLogic()
        {
            if (player.CurrentHitPoints == player.MaximumHitPoints)
            {

                BattleSummary.DisplayMessage("You won the battle. You reached maximum HP!", 10);
                BattleSummary.EndOfBattle($"Winner is: {player.PlayerName}", 15);
                level.CurrentLevel++;
                statistics.playerWins++;
                if (level.CurrentLevel <= level.FinalLevel)
                {
                    BattleSummary.EndOfBattle($"Welcome to level {level.CurrentLevel}", 15);
                    ResetSettings();
                }
                else
                {
                    Task.Delay(1000);
                    Console.Clear();
                    Console.WriteLine("Game Over!");
                    Console.Clear();
                    EndOfGame.Winner(statistics.playerWins, statistics.monsterWins, player.PlayerName, monster.MonsterName);
                }

            }

            if (player.CurrentHitPoints <= 0 && monster.CurrentHitPoints > 0)
            {
                BattleSummary.DisplayMessage("You lost the battle. You lost all HP!", 10);
                BattleSummary.EndOfBattle(monster.MonsterName, 10);
                level.CurrentLevel++;
                statistics.monsterWins++;
                if (level.CurrentLevel <= level.FinalLevel)
                {
                    BattleSummary.EndOfBattle($"Welcome to level {level.CurrentLevel}", 15);
                    ResetSettings();
                }
                else
                {
                    Task.Delay(1000);
                    Console.Clear();
                    Console.WriteLine("Game Over!");
                    Console.Clear();
                    EndOfGame.Winner(statistics.playerWins, statistics.monsterWins, player.PlayerName, monster.MonsterName);
                }
            }

            if (monster.CurrentHitPoints <= 0 && player.CurrentHitPoints > 0)
            {
                BattleSummary.DisplayMessage("Monster lost the battle! Monster have no points!", 10);
                BattleSummary.EndOfBattle($"Winner is: {player.PlayerName}", 10);
                level.CurrentLevel++;
                statistics.playerWins++;
                if (level.CurrentLevel <= level.FinalLevel)
                {
                    BattleSummary.EndOfBattle($"Welcome to level {level.CurrentLevel}", 15);
                    ResetSettings();
                }
            }

            if (monsterWeapon.MaximumShots <= 0)
            {
                BattleSummary.DisplayMessage("Monster lost the battle! Monster have no weapon!", 10);
                BattleSummary.EndOfBattle($"Winner is: {player.PlayerName}", 15);
                level.CurrentLevel++;
                statistics.playerWins++;
                if (level.CurrentLevel <= level.FinalLevel)
                {
                    BattleSummary.EndOfBattle($"Welcome to level {level.CurrentLevel}", 15);
                    ResetSettings();
                }
            }

            if (monster.CurrentHitPoints == monster.MaximumHitPoints)
            {
                BattleSummary.DisplayMessage($"Monster won the battle. {monster.MonsterName} reached maximum HP", 10);
                BattleSummary.EndOfBattle($"Winner is: {monster.MonsterName}", 15);
                level.CurrentLevel++;
                statistics.monsterWins++;
                if (level.CurrentLevel <= level.FinalLevel)
                {
                    BattleSummary.EndOfBattle($"Welcome to level {level.CurrentLevel}", 15);
                    ResetSettings();
                }
            }

            if (monsterWeapon.MaximumShots <= 0)
            {
                BattleSummary.DisplayMessage("Monster lost the battle! Monster have no weapon!", 10);
                BattleSummary.EndOfBattle($"Winner is: {player.PlayerName}", 15);
                level.CurrentLevel++;
                statistics.playerWins++;
                if (level.CurrentLevel <= level.FinalLevel)
                {
                    BattleSummary.EndOfBattle($"Welcome to level {level.CurrentLevel}", 15);
                    ResetSettings();
                }
            }

            if (playerWeapon.MaximumShots <= 0)
            {
                BattleSummary.DisplayMessage("You lost the battle. You have no weapon!", 10);
                BattleSummary.EndOfBattle($" Winner is: {monster.MonsterName}", 15);
                level.CurrentLevel++;
                statistics.monsterWins++;
                if (level.CurrentLevel <= level.FinalLevel)
                {
                    BattleSummary.EndOfBattle($"Welcome to level {level.CurrentLevel}", 15);
                    ResetSettings();
                }
            }
        }

        public static void SavingSettings()
        {
            SaveLoadDetails gameState = new SaveLoadDetails
            {
                PlayerCurrentPoints = player.CurrentHitPoints,
                _PlayerName = player.PlayerName,

                MonsterCurrentPoints = monster.CurrentHitPoints,
                _MonsterName = monster.MonsterName,


                PlayerMaximumShots = playerWeapon.MaximumShots,
                PlayerOneShotDamage = playerWeapon.OneShotDamage,
                PlayerWeaponName = playerWeapon.WeaponName,

                MonsterMaximumShots = monsterWeapon.MaximumShots,
                MonsterOneShotDamage = monsterWeapon.OneShotDamage,
                MonsterWeaponName = monsterWeapon.WeaponName,

                Level = level.CurrentLevel,
            };

            SaveLoadDetails.SaveStateToFile(gameState);
        }

        public static void LoadSettings()
        {
            SaveLoadDetails loadedState = SaveLoadDetails.LoadStateFromFile();

            player.CurrentHitPoints = loadedState.PlayerCurrentPoints;
            player.PlayerName = loadedState._PlayerName;

            monster.CurrentHitPoints = loadedState.MonsterCurrentPoints;
            monster.MonsterName = loadedState._MonsterName;

            playerWeapon.MaximumShots = loadedState.PlayerMaximumShots;
            playerWeapon.OneShotDamage = loadedState.PlayerOneShotDamage;
            playerWeapon.WeaponName = loadedState.PlayerWeaponName;

            monsterWeapon.MaximumShots = loadedState.MonsterMaximumShots;
            monsterWeapon.OneShotDamage = loadedState.MonsterOneShotDamage;
            monsterWeapon.WeaponName = loadedState.MonsterWeaponName;

            level.CurrentLevel = loadedState.Level;
        }

        public static void ResetSettings()
        {
            player.CurrentHitPoints = concretePlayer.CreatePlayer().CurrentHitPoints;
            player.CurrentHitPoints = concretePlayer.CreatePlayer().CurrentHitPoints;

            playerWeapon.MaximumShots = randomWeaponGenerator.GenerateWeapon().MaximumShots;
            playerWeapon.WeaponName = randomWeaponGenerator.GenerateWeapon().WeaponName;

            monster.CurrentHitPoints = randomMonsterGenerator.GenerateMonster().CurrentHitPoints;
            monster.CurrentHitPoints = randomMonsterGenerator.GenerateMonster().CurrentHitPoints;
            monster.MonsterName = randomMonsterGenerator.GenerateMonster().MonsterName;

            monsterWeapon.WeaponName = randomWeaponGenerator.GenerateWeapon().WeaponName;
            monsterWeapon.MaximumShots = randomWeaponGenerator.GenerateWeapon().MaximumShots;

        }
    }
}
#endregion