
using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters;

public interface IFighter
{
    public int MaxHealth { get; }
    public int CurrentHealth { get; }
    public int Evasion { get; }
    public int Initiative { get; }
    public int Crit { get; }
    public string Name { get; }
    public string FullName { get; }

    public IWeapon Weapon { get; }
    public IRace Race { get; }
    public IClasses Classing { get; }
    public IArmor Armor { get; }


    public void TakeDamage( int damage );
    public int CalculateDamage();
    public int CalculateProtect();
}


