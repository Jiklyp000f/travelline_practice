namespace Fighters.Models.Armors;

public class FabricArmor : IArmor //ткань
{
    public int Armor => 5;
    public int Evasion => 15;
    public int Health { get; } = 10;
}