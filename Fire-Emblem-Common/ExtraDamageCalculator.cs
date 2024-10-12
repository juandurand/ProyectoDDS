namespace Fire_Emblem_Common;

public class ExtraDamageCalculator
{
    private readonly string _analizedUnit;
    private readonly string _analizedStat;
    private readonly double _percentage;
    
    public ExtraDamageCalculator(string analizedUnit, string analizedStat, double percentage)
        
    {
        _analizedUnit = analizedUnit;
        _analizedStat = analizedStat;
        _percentage = percentage;
    }
    
    public int GetExtraDamage(Unit unit)
    {
        int extraDamage;
        if (_analizedUnit == "Unit")
        {
            extraDamage = unit.Hp.HpBaseValue - unit.Hp.ActualHpValue;
        }
        else
        {
            extraDamage = unit.ActualOpponent.GetTotalStat(_analizedStat, "");
        }
        
        return Convert.ToInt32(Math.Floor(extraDamage * _percentage));
    }
}