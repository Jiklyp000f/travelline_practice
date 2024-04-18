 using Fighters.Models.Weapons;

public class Sword : IWeapon
{
    public int Damage { get; } = 10;
    public int Crit { get; } = 10;
}