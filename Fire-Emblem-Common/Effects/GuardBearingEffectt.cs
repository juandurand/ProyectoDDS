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
        double reductionFactor = 0.3;
        
        if (unit.FirstAttack == 1 || unit.FirstDefense == 1)
        {
            reductionFactor = 0.6;
        }
        
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
}