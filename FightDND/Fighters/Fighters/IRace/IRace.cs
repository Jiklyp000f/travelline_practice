namespace Fighters.Models.Races;

public interface IRace
{
    int Armor { get; }
    int Damage { get; }
    int Health { get; }
    int Evasion { get; }
    int Initiative { get;  }
    string Name { get; }
}

