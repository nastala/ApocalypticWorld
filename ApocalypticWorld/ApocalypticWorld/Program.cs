using ApocalypticWorld.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApocalypticWorld
{
    class Program
    {
        private static List<LivingThings> _enemies = new List<LivingThings>();
        private static List<LivingThings> _enemiesOnTheRoute = new List<LivingThings>();
        private static Hero _currentHero = new Hero(HasDied, HeroReachedTheTarget);
        private static Hero _initialHero = new Hero(HasDied, HeroReachedTheTarget);
        private static string _initialMessage = $"type {Helper.C_L_RESET_ALL_HEALTHS} to reset Hero's and the Enemies' healths \n" +
            $"type {Helper.C_L_CLEAR_CONSOLE} to clear console \n" +
            $"type {Helper.C_L_RESET} to start all over \n" +
            $"type {Helper.C_L_HELP} to trigger this message";

        static void Main(string[] args)
        {
            Reset();
            GatherInputs();

            /*
            Hero hero = new Hero(HasDied, HeroReachedTheTarget)
            {
                TargetDistance = 7500,
                Health = 1139,
                AttackPower = 9,
                Name = "Hero"
            };

            Enemy ZombieDog = new Enemy(HasDied)
            {
                Health = 75,
                AttackPower = 10,
                Name = "Zombie Dog"
            };

            Enemy Mutant = new Enemy(HasDied)
            {
                Health = 400,
                AttackPower = 8,
                Name = "Mutant"
            };

            Enemy Zombie = new Enemy(HasDied)
            {
                Health = 300,
                AttackPower = 7,
                Name = "Zombie"
            };

            LivingThings zombie1 = Zombie.ShallowCopy();
            zombie1.Position = 1687;

            LivingThings mutant1 = Mutant.ShallowCopy();
            mutant1.Position = 274;

            LivingThings zombieDog1 = ZombieDog.ShallowCopy();
            zombieDog1.Position = 486;

            LivingThings zombieDog2 = ZombieDog.ShallowCopy();
            zombieDog2.Position = 1897;

            LivingThings mutant2 = Mutant.ShallowCopy();
            mutant2.Position = 5332;

            AddNewEnemyToTheList(zombie1);
            AddNewEnemyToTheList(mutant1);
            AddNewEnemyToTheList(zombieDog1);
            AddNewEnemyToTheList(zombieDog2);
            AddNewEnemyToTheList(mutant2);
            */

            /*
            Hero hero = new Hero(HasDied, HeroReachedTheTarget) 
            { 
                TargetDistance = 5000,
                Health = 1000,
                AttackPower = 10
            };

            Enemy Bug = new Enemy(HasDied)
            {
                Health = 50,
                AttackPower = 2
            };

            Enemy Lion = new Enemy(HasDied)
            {
                Health = 100,
                AttackPower = 15
            };

            Enemy Zombie = new Enemy(HasDied)
            { 
                Health = 300,
                AttackPower = 7
            };

            LivingThings bug1 = Bug.ShallowCopy();
            bug1.Position = 276;
            LivingThings bug2 = Bug.ShallowCopy();
            bug2.Position = 489;

            LivingThings lion1 = Lion.ShallowCopy();
            lion1.Position = 1527;

            LivingThings lion2 = Lion.ShallowCopy();
            lion2.Position = 2865;

            LivingThings zombie1 = Zombie.ShallowCopy();
            zombie1.Position = 3523;

            LivingThings zombie2 = Zombie.ShallowCopy();
            zombie2.Position = 1681;

            AddNewEnemyToTheList(bug1);
            AddNewEnemyToTheList(bug2);
            AddNewEnemyToTheList(lion1);
            AddNewEnemyToTheList(lion2);
            AddNewEnemyToTheList(zombie1);
            AddNewEnemyToTheList(zombie2);
            

            Console.WriteLine($"Hero started journey with {hero.Health} HP!");
            for (int i = 0; i < _enemies.Count && hero.IsAlive && hero.IsReached == false; i++)
            {
                LivingThings enemy = _enemies[i];
                hero.Move(enemy.Position);
                hero.Hit(hero, enemy);
                if (hero.IsAlive == false)
                    break;
                //Console.WriteLine($"Hero defeated {_enemies[i].Name} with {hero.Health} remaining");
            }

            if (hero.IsAlive)
                Console.WriteLine("Hero Survived!");

            Console.ReadKey();
            */
        }

        private static void GatherInputs()
        {
            while (true)
            {
                string[] input = SplitInput();
                if (input.Length < 1)
                    continue;

                switch (input)
                {
                    case string[] a when a.Contains(Helper.C_L_RESOURCES):
                        GatherHerosTargetDistance(input);
                        break;
                    case string[] a when (a.Contains(Helper.C_L_HERO) && input.Contains(Helper.C_L_HEALTH)):
                        GatherHerosHealth(input);
                        break;
                    case string[] a when (input.Contains(Helper.C_L_HERO) && input.Contains(Helper.C_L_ATTACK)):
                        GatherHerosAttackPower(input);
                        break;
                    case string[] a when (input.Contains(Helper.C_L_ENEMY)):
                        GatherEnemiesName(input);
                        break;
                    case string[] a when input.Contains(Helper.C_L_HEALTH):
                        GatherEnemiesHealth(input);
                        break;
                    case string[] a when input.Contains(Helper.C_L_ATTACK):
                        GatherEnemiesAttackPower(input);
                        break;
                    case string[] a when (input.Contains(Helper.C_L_THERE) && input.Contains(Helper.C_L_POSITION)):
                        GatherEnemiesPosition(input);
                        break;
                    case string[] a when input[0].ToLower().Equals(Helper.C_L_START):
                        StartExploring();
                        break;
                    case string[] a when input[0].ToLower().Equals(Helper.C_L_RESET_ALL_HEALTHS):
                        ResetAllHealths();
                        break;
                    case string[] a when input[0].ToLower().Equals(Helper.C_L_CLEAR_CONSOLE):
                        ClearConsole();
                        break;
                    case string[] a when input[0].ToLower().Equals(Helper.C_L_RESET):
                        Reset();
                        break;
                    case string[] a when input[0].ToLower().Equals(Helper.C_L_HELP):
                        Console.WriteLine(_initialMessage);
                        break;
                    default:
                        Console.WriteLine(Helper.EM_NO_OPERATION);
                        break;
                }
            }
        }

        private static void Reset()
        {
            Console.Clear();
            Console.WriteLine(_initialMessage);
            Console.WriteLine(Helper.M_START_EXPLORING);
            _enemies = new List<LivingThings>();
            _enemiesOnTheRoute = new List<LivingThings>();
            _currentHero = new Hero(HasDied, HeroReachedTheTarget);
            _initialHero = new Hero(HasDied, HeroReachedTheTarget);
    }

        private static void ClearConsole()
        {
            Console.Clear();
        }

        private static void ResetAllHealths()
        {
            _currentHero.Health = _initialHero.Health;

            for (int i = 0; i < _enemiesOnTheRoute.Count; i++)
            {
                _enemiesOnTheRoute[i].Health = FindEnemy(_enemiesOnTheRoute[i].Name).Health;
            }
        }

        private static void StartExploring()
        {
            _currentHero = _initialHero.ShallowCopy();

            if (_currentHero == null || _enemiesOnTheRoute.Count < 1)
            {
                Console.WriteLine(Helper.EM_MISSING_VALUES);
                return;
            }

            if (CheckAllEntries() == false)
            {
                return;
            }

            Console.WriteLine($"Hero started journey with {_currentHero.Health} HP!");
            for (int i = 0; i < _enemiesOnTheRoute.Count && _currentHero.IsAlive && _currentHero.IsReached == false; i++)
            {
                LivingThings enemy = _enemiesOnTheRoute[i];
                _currentHero.Move(enemy.Position);
                _currentHero.Hit(_currentHero, enemy);
                if (_currentHero.IsAlive == false)
                    break;
            }

            if (_currentHero.IsAlive)
                Console.WriteLine("Hero Survived!");

            Console.ReadKey();
        }

        private static bool CheckAllEntries()
        {
            return CheckHero() && CheckEnemies();
        }

        private static bool CheckEnemies()
        {
            bool checker = true;

            if (_enemies.Count < 1)
            {
                checker = false;
            }

            for (int i = 0; i < _enemies.Count; i++)
            {
                if (CheckEnemy(_enemies[i]) == false)
                    checker = false;
            }

            return checker;
        }

        private static bool CheckEnemy(LivingThings livingThing)
        {
            return CheckLivingThing(livingThing);
        }

        private static bool CheckHero()
        {
            CheckLivingThing(_initialHero);

            if (_initialHero.TargetDistance == 0)
            {
                Console.WriteLine($"{_initialHero.Name} has no resources value.");
                return false;
            }

            return true;
        }

        private static bool CheckLivingThing(LivingThings livingThing)
        {
            bool checker = true;
            if (livingThing == null)
            {
                checker = false;
            }

            if (livingThing.Health == 0)
            {
                Console.WriteLine($"{livingThing.Name} has no health value.");
                checker = false;
            }

            return checker;
        }

        private static void GatherEnemiesPosition(string[] input)
        {
            int enemyIndex = FindEnemyIndex(input[Helper.I_ENEMY_NAME_VALUE_ODD]);
            if (enemyIndex == -1)
            {
                Helper.EnemyNotFoundException();
                return;
            }

            try
            {
                Enemy enemy = CopyEnemy(enemyIndex);
                if (enemy == null)
                    return;

                if (input.Contains(Helper.C_L_ARE))
                {
                    enemy.Position = Convert.ToInt32(input[Helper.I_HERO_NAME_POSITION_VALUE_EVEN]);
                    AddNewEnemyToTheEnemiesOnTheRouteTwice(enemy);
                    
                }
                else
                {
                    enemy.Position = Convert.ToInt32(input[Helper.I_HERO_NAME_POSITION_VALUE_ODD]);
                    AddNewEnemyToTheEnemiesOnTheRoute(enemy);
                }
            }
            catch (FormatException)
            {
                Helper.IntFormatException();
            }
        }

        private static void AddNewEnemyToTheEnemiesOnTheRouteTwice(Enemy enemy)
        {
            AddNewEnemyToTheEnemiesOnTheRoute(enemy);
            AddNewEnemyToTheEnemiesOnTheRoute(enemy);
        }

        private static void AddNewEnemyToTheEnemiesOnTheRoute(Enemy enemy)
        {
            _enemiesOnTheRoute.Add(enemy);
            _enemiesOnTheRoute = RearrangeTheListByPosition(_enemiesOnTheRoute);
        }

        private static Enemy CopyEnemy(int enemyIndex)
        {
            if (_enemies[enemyIndex] is Enemy == false)
                return null;
            else
                return (_enemies[enemyIndex] as Enemy).ShallowCopy();
        }

        private static void GatherEnemiesAttackPower(string[] input)
        {
            int enemyIndex = FindEnemyIndex(input[Helper.I_HERO_NAME_VALUE]);
            if (enemyIndex == -1)
            {
                Helper.EnemyNotFoundException();
                return;
            }

            try
            {
                _enemies[enemyIndex].AttackPower = Convert.ToInt32(input[Helper.I_HERO_ATTACK_POWER_VALUE]);
            }
            catch (FormatException)
            {
                Helper.IntFormatException();
            }
        }

        private static void GatherEnemiesHealth(string[] input)
        {
            int enemyIndex = FindEnemyIndex(input[Helper.I_HERO_NAME_VALUE]);
            if (enemyIndex == -1)
            {
                Helper.EnemyNotFoundException();
                return;
            }

            try
            {
                _enemies[enemyIndex].Health = Convert.ToInt32(input[Helper.I_HERO_HEALTH_VALUE]);
            }
            catch (FormatException)
            {
                Console.WriteLine(Helper.EM_INT_FORMAT_EXCEPTION);
            }
        }

        private static void GatherEnemiesName(string[] input)
        {
            AddNewEnemyWithNameToTheList(input);
        }

        private static LivingThings FindEnemy(string enemyName)
        {
            int index = FindEnemyIndex(enemyName);
            if (index != -1)
                return _enemies[index];
            else
            {
                Helper.EnemyNotFoundException();
                return null;
            }
        }

        private static int FindEnemyIndex(string enemyName)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].Name.ToLower().Equals(enemyName.ToLower()))
                {
                    return i;
                }
            }

            return -1;
        }

        private static void AddNewEnemyWithNameToTheList(string[] input)
        {
            LivingThings enemy = new Enemy(HasDied) 
            {
                Name = input[Helper.I_HERO_NAME_VALUE]
            };

            if (IsNewEnemyOdd(enemy))
                _enemies.Add(enemy);
        }

        private static bool IsNewEnemyOdd(LivingThings enemy)
        {
            return _enemies.Where(e => e.Name.ToLower().Equals(enemy.Name.ToLower())).Count() == 0;
        }

        private static void GatherHerosInputs()
        {
            _currentHero.Name = "Hero";
        }

        private static void GatherHerosAttackPower(string[] input)
        {
            if (input.Length < 1 || _initialHero == null)
                return;

            try
            {
                if (!input[Helper.I_HERO_ATTACK_POWER_TEXT].ToLower().Equals(Helper.C_L_ATTACK))
                    return;

                _initialHero.AttackPower = Convert.ToInt32(input[Helper.I_HERO_ATTACK_POWER_VALUE]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(Helper.EM_INDEX_OUT_OF_RANGE_EXCEPTION);
            }
        }

        private static void GatherHerosHealth(string[] input)
        {
            if (input.Length < 1 || _initialHero == null)
                return;

            try
            {
                if (!input[Helper.I_HERO_HEALTH_TEXT].ToLower().Equals(Helper.C_L_HEALTH))
                    return;

                _initialHero.Health = Convert.ToInt32(input[Helper.I_HERO_RESOURCES_VALUE]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(Helper.EM_INDEX_OUT_OF_RANGE_EXCEPTION);
            }
        }

        private static void GatherHerosTargetDistance(string[] input)
        {
            if (input.Length < 1 || _initialHero == null)
                return;

            if (!input[Helper.I_HERO_RESOURCES_TEXT].ToLower().Equals(Helper.C_L_RESOURCES))
                return;

            try
            {
                _initialHero.TargetDistance = Convert.ToInt32(input[Helper.I_HERO_RESOURCES_VALUE]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(Helper.EM_INDEX_OUT_OF_RANGE_EXCEPTION);
            }
        }

        private static string[] SplitInput()
        {
            return Console.ReadLine().ToLower().Split(Helper.SO_INPUTS);
        }

        private static void AddNewEnemyToTheList(LivingThings enemy)
        {
            _enemiesOnTheRoute.Add(enemy);
            _enemiesOnTheRoute = RearrangeTheListByPosition(_enemiesOnTheRoute);
        }

        private static List<LivingThings> RearrangeTheListByPosition(List<LivingThings> livingThings)
        {
            if (livingThings.Count < 1)
                return null;

            return livingThings.OrderBy(e => e.Position).ToList();
        }

        private static void HasDied(LivingThings livingThing)
        {
            if (livingThing is Hero == false)
                return;

            Console.WriteLine($"Hero Died! Last seen at position {livingThing.Position}.");
        }

        private static void HeroReachedTheTarget(Hero hero)
        {
            Console.WriteLine("HeroReachTheTarget!");
        }
    }
}
