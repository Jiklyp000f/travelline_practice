
using Fighters;
using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

public class Fighter : IFighter
{

    public int MaxHealth => Race.Health + Classing.Health + Armor.Health;
    public int Evaid => Race.Evasion;
    public int CurrentHealth { get; private set; }
    public string Name { get; }
    public string FullName => $"{Name} - {Race.Name} {Classing.Name}";
    public IRace Race { get; }
    public IClasses Classing { get; }
    public IWeapon Weapon { get; }
    public IArmor Armor { get; }

    public Fighter(string name, IRace race, IWeapon weapon, IArmor armor, IClasses classes)
    {
        Name = name;
        Race = race;
        Weapon = weapon;
        Armor = armor;
        Classing = classes;
        CurrentHealth = MaxHealth;
    }

    public int CalculateDamage()
    {
        return Race.Damage + Classing.Damage + Weapon.Damage;
    }

    public int CalculateProtect()
    {
        return Race.Armor + Classing.Armor + Armor.Armor;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth < 0)
        { 
            CurrentHealth = 0;
        }
    }
}


