namespace Fire_Emblem_Common.Models;

public interface MyUnit(Unit unit)
{
    string Name { get; }
    string Weapon { get; }
    int Hp { get; }
    int Atk { get; }
    int Def { get; }
    int Spd { get; }
    int Res { get; }
    string[] Skills { get; }
}