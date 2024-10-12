namespace Fire_Emblem_Common.Effects;

public class ComparisonPercentageReductionEffectt:Effectt
{
    private readonly double _max;
    private readonly string _skillOwnerStat;
    private readonly string _rivalStat;
    private readonly int _multiplier;

    public ComparisonPercentageReductionEffectt(double max, string skillOwnerStat, string rivalStat, int multiplier)
        :base("Percentage Reduction", 2)
    {
        _max = max;
        _skillOwnerStat = skillOwnerStat;
        _rivalStat = rivalStat;
        _multiplier = multiplier;
    }

    public override void ApplyEffect(Unit unit)
    {
        int statDifference = unit.GetTotalStat(_skillOwnerStat, "") - unit.ActualOpponent.GetTotalStat(_rivalStat, "");
        double reductionFactor = (statDifference * _multiplier) / 100.0;
        reductionFactor = Math.Min(reductionFactor, _max);
        unit.Damage.PercentageReduction *= (1 - reductionFactor);
    }
}