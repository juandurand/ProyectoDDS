namespace Fire_Emblem_Common.Effects;

public class DefPercentagePenaltyEffectt:Effectt
{
    private readonly double _percentage;

    public DefPercentagePenaltyEffectt(double percentage)
        : base("Penalty")
    {
        _percentage = percentage;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Def.FirstAttackPenalty += Convert.ToInt32(Math.Floor(_percentage * unit.Def.BaseValue));
    }
}