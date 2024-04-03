namespace Fighters.Models.Races
{
    public interface IRace
    {
        int Armor { get; }
        int Damage { get; }
        int Health { get; }
        string Name { get; }
    }
}

