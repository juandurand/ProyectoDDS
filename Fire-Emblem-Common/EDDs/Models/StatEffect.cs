namespace Fire_Emblem_Common.EDDs.Models;

public class StatEffect
{
    public string EffectType { get; }
    public string SpecificAttack { get; }
    public Func<Stat, int> ValueSelector { get; }

    public StatEffect(string effectType, string specificAttack, Func<Stat, int> valueSelector)
    {
        EffectType = effectType;
        SpecificAttack = specificAttack;
        ValueSelector = valueSelector;
    }
}