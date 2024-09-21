using Fire_Emblem_Common;
namespace Fire_Emblem.Effects;

public class DefPenaltyEffect:Effect
{
    private readonly int _defPenalty;

    public DefPenaltyEffect(int defPenalty)
    {
        _defPenalty = defPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.DefPenalty += _defPenalty;
    }
}