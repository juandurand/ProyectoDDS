using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.Helpers;

public class UnitHelper
{
    public static int GetBaseValue(Unit unit, StatType stat)
    {
        return stat switch
        {
            StatType.Atk => unit.Atk.BaseValue,
            StatType.Spd => unit.Spd.BaseValue,
            StatType.Def => unit.Def.BaseValue,
            StatType.Res => unit.Res.BaseValue,
            _ => unit.HealthStatus.ActualHpValue
        };
    }
    
    public static int GetTotalStat(Unit unit, StatType stat, AttackType attackType)
    {
        return stat switch
        {
            StatType.Atk => StatHelper.GetTotalStat(unit.Atk, attackType),
            StatType.Spd => StatHelper.GetTotalStat(unit.Spd, attackType),
            StatType.Def => StatHelper.GetTotalStat(unit.Def, attackType),
            StatType.Res => StatHelper.GetTotalStat(unit.Res, attackType),
            _ => unit.HealthStatus.ActualHpValue
        };
    }
}