using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.Damage;

public class ExtraDamageCalculator
{
    private readonly UnitRole _analyzedUnit;
    private readonly StatType _firstAnalyzedStat;
    private readonly StatType _secondAnalyzedStat;
    private readonly double _percentage;
    private readonly int _max;
    
    public ExtraDamageCalculator(UnitRole analyzedUnit, StatType firstAnalyzedStat, StatType secondAnalyzedStat,
                                 double percentage, int max)
    {
        _analyzedUnit = analyzedUnit;
        _firstAnalyzedStat = firstAnalyzedStat;
        _secondAnalyzedStat = secondAnalyzedStat;
        _percentage = percentage;
        _max = max;
    }
    
    public int GetExtraDamage(Unit unit)
    {
        int extraDamage = _analyzedUnit switch
        {
            UnitRole.Unit => GetExtraDamageForUnit(unit),
            UnitRole.Rival => GetExtraDamageForRival(unit),
            UnitRole.Both => Math.Max(GetExtraDamageForBoth(unit), 0),
            _ => 0
        };

        extraDamage = Convert.ToInt32(Math.Floor(extraDamage * _percentage));
        return Math.Min(extraDamage, _max);
    }

    private int GetExtraDamageForUnit(Unit unit)
    {
        if (_firstAnalyzedStat == StatType.Hp)
        {
            return unit.HealthStatus.HpBaseValue - unit.HealthStatus.ActualHpValue;
        }
        return UnitManager.GetTotalStat(unit, _firstAnalyzedStat, AttackType.None);
    }
    
    private int GetExtraDamageForRival(Unit unit)
    {
        return UnitManager.GetTotalStat(unit.ActualOpponent, _firstAnalyzedStat, AttackType.None);
    }
    
    private int GetExtraDamageForBoth(Unit unit)
    {
        return UnitManager.GetTotalStat(unit, _firstAnalyzedStat, AttackType.None) - 
               UnitManager.GetTotalStat(unit.ActualOpponent, _secondAnalyzedStat, AttackType.None);
    }
}