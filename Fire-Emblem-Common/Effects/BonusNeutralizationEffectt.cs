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
                unit.Atk.BonusNeutralized = true;
            }
            else if (stat == "Def")
            {
                unit.Def.BonusNeutralized = true;
            }
            else if (stat == "Spd")
            {
                unit.Spd.BonusNeutralized = true;
            }
            else
            {
                unit.Res.BonusNeutralized = true;
            }
        }
    }
}