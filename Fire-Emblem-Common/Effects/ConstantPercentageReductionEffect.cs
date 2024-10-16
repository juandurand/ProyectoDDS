namespace Fire_Emblem_Common.Effects;

public class ConstantPercentageReductionEffectt:Effectt
{
    private readonly double _reduction;
    private readonly AttackType _attackType;

    public ConstantPercentageReductionEffectt(double reduction, AttackType attackType = AttackType.None)
        :base("Percentage Reduction", 2)
    {
        _reduction = reduction;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        if (_attackType == AttackType.None)
        {
            unit.Damage.PercentageReduction *= (1 - _reduction);
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.Damage.FirstAttackPercentageReduction *= (1 - _reduction);
        }
        else if (_attackType == AttackType.FollowUp)
        {
            unit.Damage.FollowUpPercentageReduction *= (1 - _reduction);
        }
    }
}