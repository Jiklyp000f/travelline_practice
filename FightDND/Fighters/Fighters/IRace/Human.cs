using Fighters.Models.Races;

public class Human : IRace
{
    int IRace.Armor { get; } = 10;
    int IRace.Damage { get; } = 10;
    int IRace.Health { get; } = 100;
    string IRace.Name { get; } = "Человек";
}