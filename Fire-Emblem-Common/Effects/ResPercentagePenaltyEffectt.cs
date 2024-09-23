namespace Fire_Emblem_Common.Effects;

public class ResPercentagePenaltyEffectt:Effectt
{
    private readonly double _percentage;

    public ResPercentagePenaltyEffectt(double percentage)
        : base("Penalty")
    {
        _percentage = percentage;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.ResFirstAttackPenalty += Convert.ToInt32(Math.Floor(_percentage * unit.Res));
    }
}