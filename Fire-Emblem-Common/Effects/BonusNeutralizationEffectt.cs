namespace Fire_Emblem_Common.Effects;

public class BonusNeutralizationEffectt:Effectt
{
    private readonly List<StatType> _statsTypes;

    public BonusNeutralizationEffectt(List<StatType> statsTypes)
        : base(1)
    {
        _statsTypes = statsTypes;
    }

    public override void ApplyEffect(Unit unit)
    {
        foreach (StatType stat in _statsTypes)
        {
            if (stat == StatType.Atk)
            {
                unit.Atk.BonusNeutralized = true;
            }
            else if (stat ==  StatType.Def)
            {
                unit.Def.BonusNeutralized = true;
            }
            else if (stat ==  StatType.Spd)
            {
                unit.Spd.BonusNeutralized = true;
            }
            else if (stat == StatType.Res)
            {
                unit.Res.BonusNeutralized = true;
            }
        }
    }
}