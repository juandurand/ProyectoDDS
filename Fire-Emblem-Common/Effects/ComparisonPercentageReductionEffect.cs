using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.Effects;

public class ComparisonPercentageReductionEffect:Effect
{
    private readonly double _max;
    private readonly StatType _skillOwnerStat;
    private readonly StatType _rivalStat;
    private readonly int _multiplier;
    private readonly AttackType _attackType;

    public ComparisonPercentageReductionEffect(double max, StatType skillOwnerStat, StatType rivalStat, int multiplier,
        AttackType attackType = AttackType.None) :base(EffectsApplyOrder.SecondOrder)
    {
        _max = max;
        _skillOwnerStat = skillOwnerStat;
        _rivalStat = rivalStat;
        _multiplier = multiplier;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        double reductionFactor = GetReductionFactor(unit);
        if (_attackType == AttackType.None)
        {
            unit.DamageEffects.PercentageReduction *= (1 - reductionFactor);
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.DamageEffects.FirstAttackPercentageReduction *= (1 - reductionFactor);
        }
        else if (_attackType == AttackType.FollowUp)
        {
            unit.DamageEffects.FollowUpPercentageReduction *= (1 - reductionFactor);
        }
    }

    private double GetReductionFactor(Unit unit)
    {
        int statDifference = UnitManager.GetTotalStat(unit, _skillOwnerStat, AttackType.None) - 
                             UnitManager.GetTotalStat(unit.ActualOpponent, _rivalStat, AttackType.None);
        double reductionFactor = (statDifference * _multiplier) / 100.0;
        return Math.Min(reductionFactor, _max);
    }
}