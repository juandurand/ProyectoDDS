using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.Effects;

public class StatBonusEffect:Effect
{
    private readonly int _bonus;
    private readonly AttackType _attackType;
    private readonly StatType _statType;

    public StatBonusEffect(int bonus, StatType statType, AttackType attackType = AttackType.None)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _bonus = bonus;
        _attackType = attackType;
        _statType = statType;
    }

    public override void ApplyEffect(Unit unit)
    {
        if (_statType == StatType.Atk)
        {
            StatManager.ApplyBonus(unit.Atk, _bonus, _attackType);
        }
        else if (_statType == StatType.Def)
        {
            StatManager.ApplyBonus(unit.Def, _bonus, _attackType);
        }
        else if (_statType == StatType.Res)
        {
            StatManager.ApplyBonus(unit.Res, _bonus, _attackType);
        }
        else if (_statType == StatType.Spd)
        {
            StatManager.ApplyBonus(unit.Spd, _bonus, _attackType);
        }
    }
}