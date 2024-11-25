using Fire_Emblem_Common.Helpers;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class BewitchingTomeEffect : Effect
{
    public BewitchingTomeEffect()
        : base(EffectsApplyOrder.ThirdOrder) { }

    public override void ApplyEffect(Unit unit)
    {
        int hpLoss = GetHpLoss(unit.ActualOpponent);
        
        unit.HealthStatus.PenaltyBeforeRound += hpLoss;
        unit.HealthStatus.ActualHpValue = Math.Max(unit.HealthStatus.ActualHpValue - hpLoss, 1);
    }
    
    private int GetHpLoss(Unit unit)
    {
        double multiplier = GetMultiplier(unit);
        
        return Convert.ToInt32(Math.Floor(UnitHelper.GetTotalStat(unit.ActualOpponent,
                                                        StatType.Atk, AttackType.None) * multiplier));
    }
    
    private double GetMultiplier(Unit unit)
    {
        double multiplier = 0.2;
        
        if (IsBewitchingTomeConditionSatisfied(unit))
        {
            multiplier = 0.4;
        }
        
        return multiplier;
    }
    
    private bool IsBewitchingTomeConditionSatisfied(Unit unit)
    {
        double wtb = WeaponTriangle.GetWtb(unit.Weapon, unit.ActualOpponent.Weapon);
        double advantageValue = 1.2;

        return wtb == advantageValue || UnitHelper.GetTotalStat(unit, StatType.Spd, AttackType.None) >
            UnitHelper.GetTotalStat(unit.ActualOpponent, StatType.Spd, AttackType.None);
    }
}