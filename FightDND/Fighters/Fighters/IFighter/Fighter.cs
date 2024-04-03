
using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

public class Fighter : IFighter
{
    
    public int MaxHealth => Race.Health;
    public int CurrentHealth { get; private set; }

    public string Name { get; }

    public IRace Race { get; }
    public IWeapon Weapon { get;}
    public IArmor Armor { get;}

    public Fighter(string name, IRace race, IWeapon weapon, IArmor armor)
    {
        Name = name;
        Race = race;
        Weapon = weapon;
        Armor = armor;
        CurrentHealth = MaxHealth + Armor.Armor;
    }
    public int CalculateDamage()
    {
        return Race.Damage + Weapon.Damage;
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


