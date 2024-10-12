namespace Fire_Emblem_Common.Effects;

public class ResBonusEffectt:Effectt
{
    private readonly int _resBonus;

    public ResBonusEffectt(int resBonus)
        : base("Bonus", 1)
    {
        _resBonus = resBonus;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Res.Bonus += _resBonus;
    }
}