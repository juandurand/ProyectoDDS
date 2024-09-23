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