 namespace Fighters.Models.Weapons;


public class NoWeapon : IWeapon
{
    public int Damage { get; } = 1;
    public int Crit { get; } = 1;
}
