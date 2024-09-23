namespace Fire_Emblem_Common.Effects;

public class BonusNeutralizationEffectt:Effectt
{
    private readonly List<string> _statsTypes;

    public BonusNeutralizationEffectt(List<String> statsTypes)
        : base("Neutralization")
    {
        _statsTypes = statsTypes;
    }

    public override void ApplyEffect(Unit unit)
    {
        foreach (string stat in _statsTypes)
        {
            if (stat == "Atk")
            {
                unit.AtkBonusNeutralization = true;
            }
            else if (stat == "Def")
            {
                unit.DefBonusNeutralization = true;
            }
            else if (stat == "Spd")
            {
                unit.SpdBonusNeutralization = true;
            }
            else
            {
                unit.ResBonusNeutralization = true;
            }
        }
    }
}