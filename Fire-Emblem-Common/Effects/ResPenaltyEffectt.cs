namespace Fire_Emblem_Common.Effects;

public class ResPenaltyEffectt:Effectt
{
    private readonly int _resPenalty;

    public ResPenaltyEffectt(int resPenalty)
        : base(1)
    {
        _resPenalty = resPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Res.Penalty += _resPenalty;
    }
}