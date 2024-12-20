using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Helpers;

namespace Fire_Emblem_Common.Effects;

public class DamageReductionBySpecificEffect : Effect
{
    private readonly double _percentage;
    private readonly StatType _skillOwnerStatType;
    private readonly StatType _rivalStatType;
    private readonly int _max;
    private readonly int _min;
    
    public DamageReductionBySpecificEffect(double percentage, StatType skillOwnerStatType,
                                           StatType rivalStatType, int max, int min)
        : base(EffectsApplyOrder.SecondOrder)
    {
        _percentage = percentage;
        _skillOwnerStatType = skillOwnerStatType;
        _rivalStatType = rivalStatType;
        _max = max;
        _min = min;
    }
    
    public override void ApplyEffect(Unit unit)
    {
        int damagePenalty = GetDamagePenalty(unit);
        
        unit.DamageEffects.Penalty += damagePenalty;
    }
    
    private int GetDamagePenalty(Unit unit)
    {
        int damagePenalty = UnitHelper.GetTotalStat(unit, _skillOwnerStatType, AttackType.None) - 
                            UnitHelper.GetTotalStat(unit.ActualOpponent, _rivalStatType, AttackType.None);
        
        damagePenalty = Math.Max(damagePenalty, _min);
        damagePenalty = Convert.ToInt32(Math.Floor(damagePenalty * _percentage));
        return Math.Min(damagePenalty, _max);
    }
}