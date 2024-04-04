namespace Fighters.Models.Armors;

public class LeatherArmor : IArmor
{
    public int Armor => 10;
    public int Health { get; } = 10;

}