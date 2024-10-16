namespace Fire_Emblem_Common.Effects;
public abstract class Effectt
{
    public int ApplyOrder { get; }
    protected Effectt(int applyOrder)
    {
        ApplyOrder = applyOrder;
    }
    public abstract void ApplyEffect(Unit unit);
}