using Fire_Emblem_Common;

namespace Fire_Emblem.Effects;

public class PenaltyNeutralizationEffect:Effect
{
    private readonly List<string> _statsTypes;

    public PenaltyNeutralizationEffect(List<String> statsTypes)
    {
        _statsTypes = statsTypes;
    }

    public override void ApplyEffect(Unit unit)
    {
        foreach (string stat in _statsTypes)
        {
            if (stat == "Atk")
            {
                unit.AtkPenalty = 0;
            }
            else if (stat == "Def")
            {
                unit.DefPenalty = 0;
            }
            else if (stat == "Spd")
            {
                unit.SpdPenalty = 0;
            }
            else
            {
                unit.ResPenalty = 0;
            }
        }
    }
}