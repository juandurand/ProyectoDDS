using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class StatBonusFromPercentageOfOtherStatEffect:Effect
{
    private readonly EnumList<StatType> _benefitedStatTypes;
    private readonly StatType _bonusOriginStatType;
    private readonly double _percentage;

    public StatBonusFromPercentageOfOtherStatEffect(EnumList<StatType> benefitedStatTypes, StatType bonusOriginStatType, double percentage)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _benefitedStatTypes = benefitedStatTypes;
        _bonusOriginStatType = bonusOriginStatType;
        _percentage = percentage;
    }

    public override void ApplyEffect(Unit unit)
    {
        int bonusBeforePercentage = GetBonusBeforePercentage(unit);
        int bonusValue = Convert.ToInt32(Math.Floor(bonusBeforePercentage * _percentage));

        foreach (StatType stat in _benefitedStatTypes)
        {
            switch (stat)
            {
                case StatType.Atk:
                    unit.Atk.Bonus += bonusValue;
                    break;
                case StatType.Def:
                    unit.Def.Bonus += bonusValue;
                    break;
                case StatType.Spd:
                    unit.Spd.Bonus += bonusValue;
                    break;
                case StatType.Res:
                    unit.Res.Bonus += bonusValue;
                    break;
            }
        }
    }

    private int GetBonusBeforePercentage(Unit unit)
    {
        return _bonusOriginStatType switch
        {
            StatType.Atk => unit.Atk.BaseValue,
            StatType.Def => unit.Def.BaseValue,
            StatType.Spd => unit.Spd.BaseValue,
            StatType.Res => unit.Res.BaseValue,
            _ => unit.HealthStatus.HpBaseValue
        };
    }
}