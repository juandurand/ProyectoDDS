using Fire_Emblem_Common;
namespace Fire_Emblem.Effects;

public class AtkPenaltyEffect:Effect
{
    private readonly int _atkPenalty;

    public AtkPenaltyEffect(int atkPenalty)
    {
        _atkPenalty = atkPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.AtkPenalty += _atkPenalty;
    }
}