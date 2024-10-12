namespace Fire_Emblem_Common.Effects;

public class PenaltyNeutralizationEffectt:Effectt
{
    private readonly List<string> _statsTypes;

    public PenaltyNeutralizationEffectt(List<String> statsTypes)
        : base("Neutralization", 1)
    {
        _statsTypes = statsTypes;
    }

    public override void ApplyEffect(Unit unit)
    {
        foreach (string stat in _statsTypes)
        {
            if (stat == "Atk")
            {
                unit.Atk.PenaltyNeutralized = true;
            }
            else if (stat == "Def")
            {
                unit.Def.PenaltyNeutralized = true;
            }
            else if (stat == "Spd")
            {
                unit.Spd.PenaltyNeutralized = true;
            }
            else
            {
                unit.Res.PenaltyNeutralized = true;
            }
        }
    }
}