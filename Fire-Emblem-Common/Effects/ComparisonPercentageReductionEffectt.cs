namespace Fire_Emblem_Common.Effects;

public class ComparisonPercentageReductionEffectt:Effectt
{
    private readonly double _max;
    private readonly StatType _skillOwnerStat;
    private readonly StatType _rivalStat;
    private readonly int _multiplier;

    public ComparisonPercentageReductionEffectt(double max, StatType skillOwnerStat, StatType rivalStat, int multiplier)
        :base("Percentage Reduction", 2)
    {
        _max = max;
        _skillOwnerStat = skillOwnerStat;
        _rivalStat = rivalStat;
        _multiplier = multiplier;
    }

    public override void ApplyEffect(Unit unit)
    {
        int statDifference = unit.GetTotalStat(_skillOwnerStat, AttackType.None) - unit.ActualOpponent.GetTotalStat(_rivalStat, AttackType.None);
        double reductionFactor = (statDifference * _multiplier) / 100.0;
        reductionFactor = Math.Min(reductionFactor, _max);
        unit.Damage.PercentageReduction *= (1 - reductionFactor);
    }
}