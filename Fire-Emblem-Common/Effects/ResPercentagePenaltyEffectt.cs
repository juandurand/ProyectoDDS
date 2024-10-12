namespace Fire_Emblem_Common.Effects;

public class ResPercentagePenaltyEffectt:Effectt
{
    private readonly double _percentage;
    private readonly string _attackType;

    public ResPercentagePenaltyEffectt(double percentage, string attackType = "All")
        : base("Penalty", 1)
    {
        _percentage = percentage;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        if (_attackType == "All")
        {
            unit.Res.Penalty += Convert.ToInt32(Math.Floor(_percentage * unit.Res.BaseValue));
        }
        else if (_attackType == "First Attack")
        {
            unit.Res.FirstAttackPenalty += Convert.ToInt32(Math.Floor(_percentage * unit.Res.BaseValue));
        }
        else
        {
            unit.Res.FollowUpPenalty += Convert.ToInt32(Math.Floor(_percentage * unit.Res.BaseValue));
        }
    }
}