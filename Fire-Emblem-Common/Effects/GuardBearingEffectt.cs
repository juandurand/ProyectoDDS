namespace Fire_Emblem_Common.Effects;

public class GuardBearingEffectt:Effectt
{
    private readonly AttackType _attackType;

    public GuardBearingEffectt(AttackType attackType = AttackType.None)
        : base(1)
    {
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        double reductionFactor = GetReductionFactor(unit);
        
        if (_attackType == AttackType.None)
        {
            unit.DamageEffects.PercentageReduction *= (1 - reductionFactor);
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.DamageEffects.FirstAttackPercentageReduction *= (1 - reductionFactor);
        }
        else if (_attackType == AttackType.FollowUp)
        {
            unit.DamageEffects.FollowUpPercentageReduction *= (1 - reductionFactor);
        }
    }

    private double GetReductionFactor(Unit unit)
    {
        if (unit.FirstAttack == 1 || unit.FirstDefense == 1)
        {
            return 0.6;
        }

        return 0.3;
    }
}