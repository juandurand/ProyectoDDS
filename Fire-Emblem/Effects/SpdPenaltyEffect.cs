using Fire_Emblem_Common;
namespace Fire_Emblem.Effects;

public class SpdPenaltyEffect:Effect
{
    private readonly int _spdPenalty;

    public SpdPenaltyEffect(int spdPenalty)
    {
        _spdPenalty = spdPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.SpdPenalty += _spdPenalty;
    }
}