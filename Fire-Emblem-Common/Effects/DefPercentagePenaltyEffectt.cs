namespace Fire_Emblem_Common.Effects;

public class DefPercentagePenaltyEffectt:Effectt
{
    private readonly double _percentage;
    private readonly AttackType _attackType;

    public DefPercentagePenaltyEffectt(double percentage, AttackType attackType = AttackType.None)
        : base("Penalty", 1)
    {
        _percentage = percentage;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        if (_attackType == AttackType.None)
        {
            unit.Def.Penalty += Convert.ToInt32(Math.Floor(_percentage * unit.Def.BaseValue));
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.Def.FirstAttackPenalty += Convert.ToInt32(Math.Floor(_percentage * unit.Def.BaseValue));
        }
        else if (_attackType == AttackType.FollowUp)
        {
            unit.Def.FollowUpPenalty += Convert.ToInt32(Math.Floor(_percentage * unit.Def.BaseValue));
        }
    }
}