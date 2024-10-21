using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.Effects;

public class ResBonusEffect:Effect
{
    private readonly int _resBonus;

    public ResBonusEffect(int resBonus)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _resBonus = resBonus;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Res.Bonus += _resBonus;
    }
}