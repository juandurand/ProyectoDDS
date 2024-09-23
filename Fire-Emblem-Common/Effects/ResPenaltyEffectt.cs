namespace Fire_Emblem_Common.Effects;

public class ResPenaltyEffectt:Effectt
{
    private readonly int _resPenalty;

    public ResPenaltyEffectt(int resPenalty)
        : base("Penalty")
    {
        _resPenalty = resPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.ResPenalty += _resPenalty;
    }
}