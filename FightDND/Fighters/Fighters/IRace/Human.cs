using Fighters.Models.Races;

public class Human : IRace
{
    int IRace.Armor => 7;
    int IRace.Damage => 10;
    int IRace.Health => 100;
    int IRace.Evasion { get; } 
    string IRace.Name { get; } = "Человек";
}
