using Fire_Emblem_GUI;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Helpers;

namespace Fire_Emblem_Common.Models;

public class MyUnit(Unit unit, AttackType attackType) : IUnit
{
    public string Name { get; } = unit.Name;
    public string Weapon { get; } = unit.Weapon.ToString();
    public int Hp { get; } = unit.HealthStatus.ActualHpValue;
    public int Atk { get; } = StatHelper.GetTotalStat(unit.Atk, attackType);
    public int Def { get; } = StatHelper.GetTotalStat(unit.Def, attackType);
    public int Spd { get; } = StatHelper.GetTotalStat(unit.Spd, attackType);
    public int Res { get; } = StatHelper.GetTotalStat(unit.Res, attackType);
    public string[] Skills { get; } = unit.Skills.GetSkillNames();
}