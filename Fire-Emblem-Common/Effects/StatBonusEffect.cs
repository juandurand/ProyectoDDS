using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Helpers;

namespace Fire_Emblem_Common.Effects;

public class StatBonusEffect:Effect
{
    private readonly int _bonusValue;
    private readonly AttackType _attackType;
    private readonly StatType _statType;

    public StatBonusEffect(int bonusValue, StatType statType, AttackType attackType = AttackType.None)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _bonusValue = bonusValue;
        _attackType = attackType;
        _statType = statType;
    }

    public override void ApplyEffect(Unit unit)
    {
        switch (_statType)
        {
            case StatType.Atk:
                StatHelper.ApplyBonus(unit.Atk, _bonusValue, _attackType);
                break;
            case StatType.Def:
                StatHelper.ApplyBonus(unit.Def, _bonusValue, _attackType);
                break;
            case StatType.Res:
                StatHelper.ApplyBonus(unit.Res, _bonusValue, _attackType);
                break;
            case StatType.Spd:
                StatHelper.ApplyBonus(unit.Spd, _bonusValue, _attackType);
                break;
        }
    }
}