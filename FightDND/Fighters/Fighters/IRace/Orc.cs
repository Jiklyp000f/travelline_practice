﻿using Fighters.Models.Races;

public class Orc : IRace
{
    int IRace.Armor => 3;
    int IRace.Damage => 15;
    int IRace.Health => 100;
    int IRace.Evasion => 3;
    string IRace.Name { get; } = "Орк"; 
}
