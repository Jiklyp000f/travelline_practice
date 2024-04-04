namespace Fighters.Models.Armors;

public class ChainArmor : IArmor
{
    public int Armor => 12;
    public int Health { get; } = 10;
}
