namespace Fire_Emblem_Common.Effects;

public class PenaltyNeutralizationEffectt:Effectt
{
    private readonly List<string> _statsTypes;

    public PenaltyNeutralizationEffectt(List<String> statsTypes)
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