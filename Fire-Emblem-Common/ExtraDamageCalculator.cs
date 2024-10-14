namespace Fire_Emblem_Common;

public class ExtraDamageCalculator
{
    private readonly string _analizedUnit;
    private readonly string _analizedStat;
    private readonly string _analizedStat2;
    private readonly double _percentage;
    
    public ExtraDamageCalculator(string analizedUnit, string analizedStat, string analizedStat2, double percentage)
        
    {
        _analizedUnit = analizedUnit;
        _analizedStat = analizedStat;
        _analizedStat2 = analizedStat2;
        _percentage = percentage;
    }
    
    public int GetExtraDamage(Unit unit)
    {
        int extraDamage;
        if (_analizedUnit == "Unit")
        {
            extraDamage = unit.HealthStatus.HpBaseValue - unit.HealthStatus.ActualHpValue;
        }
        else if (_analizedUnit == "Rival")
        {
            extraDamage = unit.ActualOpponent.GetTotalStat(_analizedStat, "");
        }
        else
        {
            extraDamage = unit.GetTotalStat(_analizedStat, "") - unit.ActualOpponent.GetTotalStat(_analizedStat2, "");
        }
        
        return Convert.ToInt32(Math.Floor(extraDamage * _percentage));
    }
}