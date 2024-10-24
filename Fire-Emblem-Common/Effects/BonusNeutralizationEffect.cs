using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.EDDs.Models;

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