using Fighters.Models.Races;

public class Elf : IRace
{
    int IRace.Armor => 5;
    int IRace.Damage => 12;
    int IRace.Health => 100;
    int IRace.Evasion => 7 ;
    string IRace.Name { get; } = "Эльф";

}