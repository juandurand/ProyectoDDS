namespace Fire_Emblem_Common.Effects;
public abstract class Effectt
{
    public string EffectType { get; }
    public int ApplyOrder { get; }
    protected Effectt(string effectType, int applyOrder)
    {
        EffectType = effectType;
        ApplyOrder = applyOrder;
    }
    public abstract void ApplyEffect(Unit unit);
}