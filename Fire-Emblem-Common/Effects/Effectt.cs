namespace Fire_Emblem_Common.Effects;
public abstract class Effectt
{
    public string EffectType { get; }
    protected Effectt(string effectType)
    {
        EffectType = effectType;
    }
    public abstract void ApplyEffect(Unit unit);
}