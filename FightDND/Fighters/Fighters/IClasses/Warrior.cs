namespace Fighters
{
    public class Warrior : IClasses
    {
        public int Armor { get; } = 10;
        public int Damage { get; } = 8;
        public int Health { get; } = 30;
        public int Evasion => 10;
        public string Name { get; } = "Воин";

    }
}
