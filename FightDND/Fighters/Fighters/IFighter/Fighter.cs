 
using Fighters;
using Fighters.Models.Armors;
using Fighters.Models.Fighters;
using Fighters.Models.Races;
using Fighters.Models.Weapons;

public class Fighter : IFighter
{
    public int Initiative { get; }
    public int MaxHealth => Race.Health + Classing.Health + Armor.Health;
    public int Evasion => Race.Evasion + Armor.Evasion + Classing.Evasion;
    public int Crit => Classing.Crit + Weapon.Crit; // криты
    public double MaxDamage => GameMaster.BattleRage + Race.Damage + Classing.Damage + Weapon.Damage;
    public double MinDamage => 0.5 * ( Race.Damage + Classing.Damage + Weapon.Damage );
    public int CurrentHealth { get; private set; }
    public string Name { get; }
    public string FullName => $"{Name} - {Race.Name} {Classing.Name}";
    public IRace Race { get; }
    public IClasses Classing { get; }
    public IWeapon Weapon { get; }
    public IArmor Armor { get; }
    private Random random;

    public Fighter( string name, IRace race, IWeapon weapon, IArmor armor, IClasses classes )
    {
        Name = name;
        Race = race;
        Weapon = weapon;
        Armor = armor;
        Classing = classes;
        CurrentHealth = MaxHealth;
        random = new Random();
        Initiative = CalculateInitiative();
    }
    private int CalculateInitiative()
    {
        // Значение инициативы базируется на значении расы и случайном числе от 1 до 10
        int raceInitiative = Race.Initiative;
        int randomInitiative = random.Next( 1, 11 ); // Случайное число от 1 до 10
        return raceInitiative + randomInitiative;
    }
    public int RandomizeDamage()
    {

        double minRange = MinDamage * 0.8; // Урон может быть ниже MinDamage на 20%
        double maxRange = MaxDamage * 1.1; // Урон может быть выше MaxDamage на 10%

        int minDamageInt = ( int )minRange;
        int maxDamageInt = ( int )maxRange;

        int damage = random.Next( minDamageInt, maxDamageInt + 1 );
        if ( random.Next( 1, 101 ) <= Crit )
        {
            damage *= 2;
            Console.WriteLine( $"Критический удар! Урон удвоен." );
        }

        return damage;
    }

    public int CalculateDamage()
    {
        return RandomizeDamage();
    }

    public int CalculateProtect()
    {
        return Race.Armor + Classing.Armor + Armor.Armor;
    }

    public void TakeDamage( int damage )
    {
        CurrentHealth -= damage;
        if ( CurrentHealth < 0 )
        {
            CurrentHealth = 0;
        }
    }
}


