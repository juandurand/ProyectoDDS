using Fire_Emblem_Common;

namespace Fire_Emblem.Effects;

public class BonusNeutralizationEffect:Effect
{
    private readonly List<string> _statsTypes;

    public BonusNeutralizationEffect(List<String> statsTypes)
    {
        _statsTypes = statsTypes;
    }

    public override void ApplyEffect(Unit unit)
    {
        foreach (string stat in _statsTypes)
        {
            if (stat == "Atk")
            {
                unit.AtkBonus = 0;
            }
            else if (stat == "Def")
            {
                unit.DefBonus = 0;
            }
            else if (stat == "Spd")
            {
                unit.SpdBonus = 0;
            }
            else
            {
                unit.ResBonus = 0;
            }
        }
    }
}