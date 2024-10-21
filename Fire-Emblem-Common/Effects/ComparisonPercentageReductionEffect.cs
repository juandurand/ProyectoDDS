using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.Effects;

public class ComparisonPercentageReductionEffect:Effect
{
    private readonly double _max;
    private readonly StatType _skillOwnerStat;
    private readonly StatType _rivalStat;
    private readonly int _multiplier;

    public ComparisonPercentageReductionEffect(double max, StatType skillOwnerStat, StatType rivalStat, int multiplier)
        :base(EffectsApplyOrder.SecondOrder)
    {
        _max = max;
        _skillOwnerStat = skillOwnerStat;
        _rivalStat = rivalStat;
        _multiplier = multiplier;
    }

    public override void ApplyEffect(Unit unit)
    {
        double reductionFactor = GetReductionFactor(unit);
        unit.DamageEffects.PercentageReduction *= (1 - reductionFactor);
    }

    private double GetReductionFactor(Unit unit)
    {
        int statDifference = UnitController.GetTotalStat(unit, _skillOwnerStat, AttackType.None) - UnitController.GetTotalStat(unit.ActualOpponent, _rivalStat, AttackType.None);
        double reductionFactor = (statDifference * _multiplier) / 100.0;
        return Math.Min(reductionFactor, _max);
    }
}