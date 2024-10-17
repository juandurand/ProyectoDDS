namespace Fire_Emblem_Common;

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
            extraDamage = UnitController.GetTotalStat(unit.ActualOpponent, _analizedStat, AttackType.None);
        }
        else if (_analizedUnit == UnitRole.Both)
        {
            extraDamage = UnitController.GetTotalStat(unit, _analizedStat, AttackType.None) - UnitController.GetTotalStat(unit.ActualOpponent, _analizedStat2, AttackType.None);
        }
        
        return Convert.ToInt32(Math.Floor(extraDamage * _percentage));
    }
}