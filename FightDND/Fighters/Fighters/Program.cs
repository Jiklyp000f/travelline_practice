﻿using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;
using System.Diagnostics;
using System.Net.Security;

namespace Fighters
{
    public class Program
    {
        public static void Main()
        {

            var firstFighter = new Fighter(GetFighterName(), GetRace(), GetWeapon(), GetArmor(), GetClasses());
            Console.WriteLine($"\nПервый боец: {firstFighter.FullName}\n");
            var secondFighter = new Fighter(GetFighterName(), GetRace(), GetWeapon(), GetArmor(), GetClasses());
            Console.WriteLine($"\nВторой боец: {secondFighter.FullName}\n");

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
        public static IArmor GetArmor()
        {
            Console.WriteLine("Введите броню(латы, кожа, кольчуга, ткань): ");

            string? armor = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(armor))
            {
                Console.WriteLine("Неверный выбор брони, введите заного");

                GetRace();
            }
            return GetArmor(armor);
        }
        
        private static IArmor GetArmor(string Armor)
        {
            switch (Armor)
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
            Console.WriteLine("Введите расу(человек, эльф, орк): ");

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
                case "человек":
                    return new Human();
                case "орк":
                    return new Orc();
                case "эльф":
                    return new Elf(); 
                default:
                    return new Human();
            }

        }

        public static IClasses GetClasses()
        {
            Console.WriteLine("Введите класс(разбойник, воин): ");

            string? classes = Console.ReadLine().ToLower();
            if (string.IsNullOrEmpty(classes))
            {
                Console.WriteLine("Неверный выбор класса, введите заного");

                GetClasses();
            }
            return EnterClasses(classes);
        }

        private static IClasses EnterClasses(string Classes)
        {
            switch (Classes)
            {
                case "разбойник":
                    return new Rogue();
                case "воин":
                    return new Warrior();
                default:
                    return new NoClasses();
            }

        }

        public static IWeapon GetWeapon()
        {
            Console.WriteLine("Выберите оружие(нож, меч): ");
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
                case "нож":
                    return new Knife();
                case "noweapon":
                    return new NoWeapon();
                case "меч":
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
