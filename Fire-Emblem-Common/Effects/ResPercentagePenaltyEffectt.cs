namespace Fire_Emblem_Common.Effects;

public class ResPercentagePenaltyEffectt:Effectt
{
    private readonly double _percentage;
    private readonly AttackType _attackType;

    public ResPercentagePenaltyEffectt(double percentage, AttackType attackType = AttackType.None)
        : base(1)
    {
        _percentage = percentage;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        if (_attackType == AttackType.None)
        {
            unit.Res.Penalty += Convert.ToInt32(Math.Floor(_percentage * unit.Res.BaseValue));
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.Res.FirstAttackPenalty += Convert.ToInt32(Math.Floor(_percentage * unit.Res.BaseValue));
        }
        else if (_attackType == AttackType.FollowUp)
        {
            unit.Res.FollowUpPenalty += Convert.ToInt32(Math.Floor(_percentage * unit.Res.BaseValue));
        }
    }
}