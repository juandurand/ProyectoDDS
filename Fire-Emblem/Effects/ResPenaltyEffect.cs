using Fire_Emblem_Common;
namespace Fire_Emblem.Effects;

public class ResPenaltyEffect:Effect
{
    private readonly int _resPenalty;

    public ResPenaltyEffect(int resPenalty)
    {
        _resPenalty = resPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.ResPenalty += _resPenalty;
    }
}