namespace Fire_Emblem_Common.Effects;

public class ConstantPercentageReductionEffectt:Effectt
{
    private readonly double _reduction;
    private readonly string _attackType;

    public ConstantPercentageReductionEffectt(double reduction, string attackType = "All")
        :base("Percentage Reduction", 2)
    {
        _reduction = reduction;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        if (_attackType == "All")
        {
            unit.Damage.PercentageReduction *= (1 - _reduction);
        }
        else if (_attackType == "First Attack")
        {
            unit.Damage.FirstAttackPercentageReduction *= (1 - _reduction);
        }
        else
        {
            unit.Damage.FollowUpPercentageReduction *= (1 - _reduction);
        }
    }
}