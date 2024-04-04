namespace Fighters.Models.Armors;

public class Patches : IArmor
{
    public int Armor => 20;

    public int Health { get; } = 10;
}
