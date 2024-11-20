using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.Damage;

public class ExtraDamageCalculator
{
    private readonly UnitRole _analizedUnit;
    private readonly StatType _firstAnalizedStat;
    private readonly StatType _secondAnalizedStat;
    private readonly double _percentage;
    private readonly int _max;
    
    public ExtraDamageCalculator(UnitRole analizedUnit, StatType firstAnalizedStat, StatType secondAnalizedStat, double percentage, int max)
    {
        _analizedUnit = analizedUnit;
        _firstAnalizedStat = firstAnalizedStat;
        _secondAnalizedStat = secondAnalizedStat;
        _percentage = percentage;
        _max = max;
    }
    
    public int GetExtraDamage(Unit unit)
    {
        int extraDamage = 0;
        
        if (_analizedUnit == UnitRole.Unit)
        {
            extraDamage = GetExtraDamageForUnit(unit);
        }
        else if (_analizedUnit == UnitRole.Rival)
        {
            extraDamage = GetExtraDamageForRival(unit);
        }
        else if (_analizedUnit == UnitRole.Both)
        {
            extraDamage = Math.Max(GetExtraDamageForBoth(unit), 0);
        }
        
        extraDamage = Convert.ToInt32(Math.Floor(extraDamage * _percentage));
        return Math.Min(extraDamage, _max);
    }


    private int GetExtraDamageForUnit(Unit unit)
    {
        if (_firstAnalizedStat == StatType.Hp)
        {
            return unit.HealthStatus.HpBaseValue - unit.HealthStatus.ActualHpValue;
        }
        return UnitManager.GetTotalStat(unit, _firstAnalizedStat, AttackType.None);
    }
    
    private int GetExtraDamageForRival(Unit unit)
    {
        return UnitManager.GetTotalStat(unit.ActualOpponent, _firstAnalizedStat, AttackType.None);
    }
    
    private int GetExtraDamageForBoth(Unit unit)
    {
        return UnitManager.GetTotalStat(unit, _firstAnalizedStat, AttackType.None) - 
               UnitManager.GetTotalStat(unit.ActualOpponent, _secondAnalizedStat, AttackType.None);
    }
}