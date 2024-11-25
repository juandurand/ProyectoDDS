namespace Fire_Emblem_Common.Models;

public class DamageChange
{
    public int DamageValue { get; }
    public string SpecificAttack { get; }
    public string EffectType { get; }

    public DamageChange(int damageValue, string specificAttack, string effectType)
    {
        DamageValue = damageValue;
        SpecificAttack = specificAttack;
        EffectType = effectType;
    }
}