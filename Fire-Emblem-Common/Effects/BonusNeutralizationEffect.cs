using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class BonusNeutralizationEffect:Effect
{
    private readonly EnumList<StatType> _statsTypes;

    public BonusNeutralizationEffect(EnumList<StatType> statsTypes)
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
                    unit.Atk.BonusNeutralized = true;
                    break;
                case StatType.Def:
                    unit.Def.BonusNeutralized = true;
                    break;
                case StatType.Spd:
                    unit.Spd.BonusNeutralized = true;
                    break;
                case StatType.Res:
                    unit.Res.BonusNeutralized = true;
                    break;
            }
        }
    }
}