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
                unit.AtkPenaltyNeutralization = true;
            }
            else if (stat == "Def")
            {
                unit.DefPenaltyNeutralization = true;
            }
            else if (stat == "Spd")
            {
                unit.SpdPenaltyNeutralization = true;
            }
            else
            {
                unit.ResPenaltyNeutralization = true;
            }
        }
    }
}