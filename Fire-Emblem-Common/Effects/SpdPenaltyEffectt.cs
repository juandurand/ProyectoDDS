namespace Fire_Emblem_Common.Effects;

public class SpdPenaltyEffectt:Effectt
{
    private readonly int _spdPenalty;

    public SpdPenaltyEffectt(int spdPenalty)
        : base("Bonus", 1)
    {
        _spdPenalty = spdPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Spd.Penalty += _spdPenalty;
    }
}