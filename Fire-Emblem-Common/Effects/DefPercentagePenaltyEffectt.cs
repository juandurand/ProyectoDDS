namespace Fire_Emblem_Common.Effects;

public class DefPercentagePenaltyEffectt:Effectt
{
    private readonly double _percentage;
    private readonly string _attackType;

    public DefPercentagePenaltyEffectt(double percentage, string attackType = "All")
        : base("Penalty", 1)
    {
        _percentage = percentage;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        if (_attackType == "All")
        {
            unit.Def.Penalty += Convert.ToInt32(Math.Floor(_percentage * unit.Def.BaseValue));
        }
        else if (_attackType == "First Attack")
        {
            unit.Def.FirstAttackPenalty += Convert.ToInt32(Math.Floor(_percentage * unit.Def.BaseValue));
        }
        else
        {
            unit.Def.FollowUpPenalty += Convert.ToInt32(Math.Floor(_percentage * unit.Def.BaseValue));
        }
    }
}