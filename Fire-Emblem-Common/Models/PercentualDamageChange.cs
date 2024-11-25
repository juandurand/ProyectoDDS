namespace Fire_Emblem_Common.Models;

public class PercentualDamageChange
{
    public double PercentageValue { get; }
    public string SpecificAttack { get; }
    public string EffectType { get; }

    public PercentualDamageChange(double percentageValue, string specificAttack, string effectType)
    {
        PercentageValue = percentageValue;
        SpecificAttack = specificAttack;
        EffectType = effectType;
    }
}