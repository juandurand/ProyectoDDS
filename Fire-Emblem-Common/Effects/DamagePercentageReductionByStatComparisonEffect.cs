using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Helpers;

namespace Fire_Emblem_Common.Effects;

public class DamagePercentageReductionByStatComparisonEffect:Effect
{
    private readonly double _max;
    private readonly StatType _skillOwnerStat;
    private readonly StatType _rivalStat;
    private readonly int _multiplier;
    private readonly AttackType _attackType;

    public DamagePercentageReductionByStatComparisonEffect(double max, StatType skillOwnerStat, StatType rivalStat,
        int multiplier, AttackType attackType = AttackType.None) :base(EffectsApplyOrder.SecondOrder)
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
        reductionFactor = unit.ActualOpponent.DamageEffects.ReductionOfPercentageReduction * reductionFactor;

        switch (_attackType)
        {
            case AttackType.None:
                unit.DamageEffects.PercentageReduction *= (1 - reductionFactor);
                break;
            case AttackType.FirstAttack:
                unit.DamageEffects.FirstAttackPercentageReduction *= (1 - reductionFactor);
                break;
            case AttackType.FollowUp:
                unit.DamageEffects.FollowUpPercentageReduction *= (1 - reductionFactor);
                break;
        }
    }

    private double GetReductionFactor(Unit unit)
    {
        int statDifference = UnitHelper.GetTotalStat(unit, _skillOwnerStat, AttackType.None) - 
                             UnitHelper.GetTotalStat(unit.ActualOpponent, _rivalStat, AttackType.None);
        double oneHundred = 100.0;
        
        double reductionFactor = (statDifference * _multiplier) / oneHundred;
        return Math.Min(reductionFactor, _max);
    }
}