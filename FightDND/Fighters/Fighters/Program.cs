using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using System.Diagnostics;

namespace Fighters
{
    public class Program 
    {
        public static void Main()
        {
            List<IFighter> fighters = new List<IFighter>();

            // Запрашиваем количество бойцов
            Console.WriteLine("Введите количество бойцов: ");
            int numFighters;
            while (!int.TryParse(Console.ReadLine(), out numFighters) || numFighters < 2)
            {
                Console.WriteLine("Пожалуйста, введите корректное число (минимум 2): ");
            }

            // Создаем бойцов
            for (int i = 0; i < numFighters; i++)
            {
                Console.WriteLine($"\nСоздание бойца {i + 1}:");
                fighters.Add(CreateFighter());
            }

            // Отображаем информацию о бойцах
            Console.WriteLine("\nБойцы:");
            foreach (var fighter in fighters)
            {
                Console.WriteLine($"{fighter.FullName}");
            }


            // Начинаем бой
            var master = new GameMaster();
            var winner = master.PlayAndGetWinner(fighters[0], fighters[1]);

            Console.WriteLine($"\nПобедитель: {winner.Name}");
        }

        public static IFighter CreateFighter()
        {
            Console.WriteLine("Введите данные бойца:");

            string name = GetFighterName();
            IRace race = GetRace();
            IWeapon weapon = GetWeapon();
            IArmor armor = GetArmor();
            IClasses classes = GetClasses();

            return new Fighter(name, race, weapon, armor, classes);
        }

        public static string GetFighterName()
        {
            Console.WriteLine("Введите имя бойца: ");

            string fighterName = Console.ReadLine();
            if (string.IsNullOrEmpty(fighterName))
            {
                Console.WriteLine("Некорректное имя, попробуйте снова: ");
                return GetFighterName();
            }

            return fighterName;
        }

        public static IArmor GetArmor()
        {
            Console.WriteLine("Выберите броню (латы, кожа, кольчуга, ткань): ");

            string armor = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(armor))
            {
                Console.WriteLine("Некорректный выбор брони, попробуйте снова: ");
                return GetArmor();
            }
            return GetArmorByType(armor);
        }

        public static IArmor GetArmorByType(string armorType)
        {
            switch (armorType)
            {
                case "латы":
                    return new Patches();
                case "кожа":
                    return new LeatherArmor();
                case "кольчуга":
                    return new ChainArmor();
                case "ткань":
                    return new FabricArmor();
                default:
                    return new NoArmor();
            }
        }

        public static IRace GetRace()
        {
            Console.WriteLine("Выберите расу (человек, эльф, орк): ");

            string race = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(race))
            {
                Console.WriteLine("Некорректный выбор расы, попробуйте снова: ");
                return GetRace();
            }
            return GetRaceByType(race);
        }

        public static IRace GetRaceByType(string raceType)
        {
            switch (raceType)
            {
                case "человек":
                    return new Human();
                case "эльф":
                    return new Elf();
                case "орк":
                    return new Orc();
                default:
                    return new Human();
            }
        }

        public static IWeapon GetWeapon()
        {
            Console.WriteLine("Выберите оружие (нож, меч): ");

            string weapon = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(weapon))
            {
                Console.WriteLine("Некорректный выбор оружия, попробуйте снова: ");
                return GetWeapon();
            }
            return GetWeaponByType(weapon);
        }

        public static IWeapon GetWeaponByType(string weaponType)
        {
            switch (weaponType)
            {
                case "нож":
                    return new Knife();
                case "меч":
                    return new Sword();
                default:
                    return new NoWeapon();
            }
        }

        public static IClasses GetClasses()
        {
            Console.WriteLine("Выберите класс (разбойник, воин): ");

            string classes = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(classes))
            {
                Console.WriteLine("Некорректный выбор класса, попробуйте снова: ");
                return GetClasses();
            }
            return GetClassByType(classes);
        }

        public static IClasses GetClassByType(string classType)
        {
            switch (classType)
            {
                case "разбойник":
                    return new Rogue();
                case "воин":
                    return new Warrior();
                default:
                    return new NoClasses();
            }
        }
    }

    public class GameMaster
    {
        public static int BattleRage;
        public IFighter PlayAndGetWinner(IFighter firstFighter, IFighter secondFighter)
        {
            int round = 1;
            Console.WriteLine("Нажмите Enter для начала боя");
            while (true)
            {
                Console.ReadLine();
                BattleRage = round - (round / 2);
                Console.WriteLine($"Раунд {round++}.\n" +
                    $"Ярость бойцов увеличивает их урон на {BattleRage}");
                

                // First fights second
                if (FightAndCheckIfOpponentDead(firstFighter, secondFighter))
                {
                    return firstFighter;
                }

                // Second fights first
                if (FightAndCheckIfOpponentDead(secondFighter, firstFighter))
                {
                    return secondFighter;
                }

                Console.WriteLine("\nНажмите Enter для перехода в следующий раунд\n");
            }

            throw new UnreachableException();
        }

        private bool FightAndCheckIfOpponentDead(IFighter roundOwner, IFighter opponent)
        {
          
            int evasionChance = opponent.Evasion + EvaidRandom();
            if (evasionChance > 100) 
            {
                evasionChance = 100;
            }
            int damage = roundOwner.CalculateDamage() - opponent.CalculateProtect();
            if (damage < 1) damage = 1;
            if (evasionChance >= 100)
            {
                Console.WriteLine(
                $"Боец {opponent.Name} уклоняется от атаки!\n" +
                $"Количество жизней: {opponent.CurrentHealth}");
                return false; 
            }

            opponent.TakeDamage(damage + BattleRage);

            Console.WriteLine(
                $"Боец {opponent.Name} получает {damage + BattleRage} урона. \n" +
                $"Количество жизней: {opponent.CurrentHealth}");

            return opponent.CurrentHealth < 1;
        }
        public int EvaidRandom()
        {
            Random random = new Random();
            int Evasion = random.Next(0, 101);
            return Evasion;
        }
    }
}
