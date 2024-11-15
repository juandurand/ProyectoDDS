using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.Effects;

public class BonusFromPercentageOfOtherStatEffect:Effect
{
    private readonly EnumList<StatType> _benefitedStatTypes;
    private readonly StatType _bonusOriginStatType;
    private readonly double _percentage;

    public BonusFromPercentageOfOtherStatEffect(EnumList<StatType> benefitedStatTypes, StatType bonusOriginStatType, double percentage)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _benefitedStatTypes = benefitedStatTypes;
        _bonusOriginStatType = bonusOriginStatType;
        _percentage = percentage;
    }

    public override void ApplyEffect(Unit unit)
    {
        int bonusBeforePercentage = GetBonusBeforePercentage(unit);
        foreach (StatType stat in _benefitedStatTypes)
        {
            if (stat == StatType.Atk)
            {
                unit.Atk.Bonus += Convert.ToInt32(Math.Floor(bonusBeforePercentage * _percentage));
            }
            else if (stat == StatType.Def)
            {
                unit.Def.Bonus += Convert.ToInt32(Math.Floor(bonusBeforePercentage * _percentage));
            }
            else if (stat == StatType.Spd)
            {
                unit.Spd.Bonus += Convert.ToInt32(Math.Floor(bonusBeforePercentage * _percentage));
            }
            else if (stat == StatType.Res)
            {
                unit.Res.Bonus += Convert.ToInt32(Math.Floor(bonusBeforePercentage * _percentage));
            }
        }
    }
    
    private int GetBonusBeforePercentage(Unit unit)
    {
        if (_bonusOriginStatType == StatType.Atk)
        {
            return unit.Atk.BaseValue;
        }
        if (_bonusOriginStatType == StatType.Def)
        {
            return unit.Def.BaseValue;
        }
        if (_bonusOriginStatType == StatType.Spd)
        {
            return unit.Spd.BaseValue;
        }
        if (_bonusOriginStatType == StatType.Res)
        {
            return unit.Res.BaseValue;
        }
        return unit.HealthStatus.HpBaseValue;
    }
}