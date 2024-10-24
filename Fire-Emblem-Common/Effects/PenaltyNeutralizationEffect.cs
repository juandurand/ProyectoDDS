using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class PenaltyNeutralizationEffect:Effect
{
    private readonly EnumList<StatType> _statsTypes;

    public PenaltyNeutralizationEffect(EnumList<StatType> statsTypes)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _statsTypes = statsTypes;
    }

    public override void ApplyEffect(Unit unit)
    {
        foreach (StatType stat in _statsTypes)
        {
            if (stat == StatType.Atk)
            {
                unit.Atk.PenaltyNeutralized = true;
            }
            else if (stat == StatType.Def)
            {
                unit.Def.PenaltyNeutralized = true;
            }
            else if (stat == StatType.Spd)
            {
                unit.Spd.PenaltyNeutralized = true;
            }
            else if (stat == StatType.Res)
            {
                unit.Res.PenaltyNeutralized = true;
            }
        }
    }
}