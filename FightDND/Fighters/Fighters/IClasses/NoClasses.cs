namespace Fighters;

public class NoClasses : IClasses
{
    public int Armor { get; } = 0;
    public int Damage { get; } = 0;
    public int Health { get; } = 0;
    public int Evasion {  get; } = 10;
    public int Crit { get; } = 10;
    public string Name { get; } = "Без класса";
}
