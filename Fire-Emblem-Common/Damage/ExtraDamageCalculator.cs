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
    
    public ExtraDamageCalculator(UnitRole analizedUnit, StatType analizedStat, StatType analizedStat2, double percentage)
    {
        _analizedUnit = analizedUnit;
        _analizedStat = analizedStat;
        _analizedStat2 = analizedStat2;
        _percentage = percentage;
    }
    
    public int GetExtraDamage(Unit unit)
    {
        int extraDamage = 0;
        
        if (_analizedUnit == UnitRole.Unit)
        {
            extraDamage = unit.HealthStatus.HpBaseValue - unit.HealthStatus.ActualHpValue;
        }
        else if (_analizedUnit == UnitRole.Rival)
        {
            extraDamage = UnitManager.GetTotalStat(unit.ActualOpponent, _analizedStat, AttackType.None);
        }
        else if (_analizedUnit == UnitRole.Both)
        {
            extraDamage = UnitManager.GetTotalStat(unit, _analizedStat, AttackType.None) - 
                          UnitManager.GetTotalStat(unit.ActualOpponent, _analizedStat2, AttackType.None);
        }
        
        return Convert.ToInt32(Math.Floor(extraDamage * _percentage));
    }
}