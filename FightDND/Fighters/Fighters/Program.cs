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
           
            var firstFighter = new Fighter(GetFighterName(), GetRace(), GetWeapon());
            var secondFighter = new Fighter(GetFighterName(), GetRace(), GetWeapon());

            var master = new GameMaster();
            var winner = master.PlayAndGetWinner(firstFighter, secondFighter);

            Console.WriteLine($"Выигрывает  {winner.Name}");
        }
        public static string GetFighterName()
        {
            Console.WriteLine("Введите имя бойца: ");

            string? fighterName = Console.ReadLine();

            if (string.IsNullOrEmpty(fighterName))
            {
                Console.WriteLine("Неверное имя бойца, введите заного: ");

                GetFighterName();
            }

            return fighterName;
        }

        public static IRace GetRace()
        {
            Console.WriteLine("Введите расу: ");

            string? race = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(race))
            {
                Console.WriteLine("Неверный выбор расы, введите заного");

                GetRace();
            }
            return EnterRace(race);
        }
        private static IRace EnterRace(string Race)
        {
            switch (Race)
            {
                case "human":
                    return new Human();
                case "orc":
                    return new Orc();
                case "elf":
                    return new Elf(); 
                default:
                    return new Human();
            }

        }

        public static IWeapon GetWeapon()
        {
            Console.WriteLine("Выберите оружие: ");
            string? weapon = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(weapon))
            {
                Console.WriteLine("Неверный выбор оружия введите заного: ");
                GetWeapon();
            }
            return EnterWeapon(weapon);
        }

        private static IWeapon EnterWeapon(string Weapon)
        {
            switch (Weapon) 
            {
                case "knife":
                    return new Knife();
                case "noweapon":
                    return new NoWeapon();
                case "sword":
                    return new Sword();
                default:
                    return new NoWeapon();
            }

        }
    }

    public class GameMaster
    {
        public IFighter PlayAndGetWinner(IFighter firstFighter, IFighter secondFighter)
        {
            int round = 1;
            while (true)
            {
                Console.WriteLine($"Раунд {round++}.");

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

                Console.WriteLine();
            }

            throw new UnreachableException();
        }

        private bool FightAndCheckIfOpponentDead(IFighter roundOwner, IFighter opponent)
        {
            int damage = roundOwner.CalculateDamage();
            opponent.TakeDamage(damage);

            Console.WriteLine(
                $"Боец {opponent.Name} получает {damage} урона. " +
                $"Количество жизней: {opponent.CurrentHealth}");

            return opponent.CurrentHealth < 1;
        }
    }
}
