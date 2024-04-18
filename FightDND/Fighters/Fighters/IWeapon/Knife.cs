namespace Fighters.Models.Weapons;

public class Knife : IWeapon
{
    public int Damage { get; } = 5;
    public int Crit { get; } = 15; 
}
