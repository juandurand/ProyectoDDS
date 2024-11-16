using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.Damage;

public class ExtraDamageCalculator
{
    private readonly UnitRole _analizedUnit;
    private readonly StatType _analizedStat;
    private readonly StatType _analizedStat2;
    private readonly double _percentage;
    private readonly int _max;
    
    public ExtraDamageCalculator(UnitRole analizedUnit, StatType analizedStat, StatType analizedStat2, double percentage, int max)
    {
        _analizedUnit = analizedUnit;
        _analizedStat = analizedStat;
        _analizedStat2 = analizedStat2;
        _percentage = percentage;
        _max = max;
    }
    
    public int GetExtraDamage(Unit unit)
    {
        int extraDamage = 0;
        
        if (_analizedUnit == UnitRole.Unit)
        {
            if (_analizedStat == StatType.Hp)
            {
                extraDamage = unit.HealthStatus.HpBaseValue - unit.HealthStatus.ActualHpValue;
            }
            else
            {
                extraDamage = UnitManager.GetTotalStat(unit, _analizedStat, AttackType.None);
            }
        }
        else if (_analizedUnit == UnitRole.Rival)
        {
            extraDamage = UnitManager.GetTotalStat(unit.ActualOpponent, _analizedStat, AttackType.None);
        }
        else if (_analizedUnit == UnitRole.Both)
        {
            extraDamage = UnitManager.GetTotalStat(unit, _analizedStat, AttackType.None) - 
                          UnitManager.GetTotalStat(unit.ActualOpponent, _analizedStat2, AttackType.None);
            extraDamage = Math.Max(extraDamage, 0);
        }
        
        extraDamage = Convert.ToInt32(Math.Floor(extraDamage * _percentage));
        return Math.Min(extraDamage, _max);
    }
}