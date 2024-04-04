namespace Fighters.Models.Armors;

public class FabricArmor : IArmor
{
    public int Armor => 5;
    public int Health { get; } = 10;
}