using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Models;

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
            switch (stat)
            {
                case StatType.Atk:
                    unit.Atk.PenaltyNeutralized = true;
                    break;
                case StatType.Def:
                    unit.Def.PenaltyNeutralized = true;
                    break;
                case StatType.Spd:
                    unit.Spd.PenaltyNeutralized = true;
                    break;
                case StatType.Res:
                    unit.Res.PenaltyNeutralized = true;
                    break;
            }
        }
    }
}