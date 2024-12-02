using Fire_Emblem_View;
using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Helpers;
using Fire_Emblem.Managers;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;

namespace Fire_Emblem;

public class AttackController
{
    private readonly IViewManager _view;

    public AttackController(IViewManager view)
    {
        _view = view;
    }
    
    public void SimulateAttack(DamageInfo damageInfo, AttackType attackType = AttackType.FirstAttack)
    {
        if (IsUnitUnableToCounterAttack(damageInfo.Attacker))
        {
            return;
        }
        int damage = DamageCalculator.GetDamage(damageInfo);
        
        UnitManager.SetAttacked(damageInfo.Attacker);
        HealthStatusManager.ApplyPercentageOfDamageBonusAfterAttack(damageInfo.Attacker.HealthStatus, damage);
        ApplyDamage(damageInfo, damage, attackType);
        _view.UpdateUnitsStatsDuringBattle(damageInfo.Attacker, damageInfo.Defender, attackType);
    }
    
    private bool IsUnitUnableToCounterAttack(Unit unit)
    {
        return unit.CounterAttackDenial && !unit.DenialOfCounterAttackDenial;
    }

    private void ApplyDamage(DamageInfo damageInfo, int damage, AttackType attackType)
    {
        HealthStatusManager.DealDamage(damageInfo.Defender.HealthStatus, damage);
        _view.ReportAttack(damageInfo, damage, attackType);
    }

    public void SimulateFollowUp(DamageInfo damageInfo)
    {
        if (CanFollowUp(damageInfo.Attacker, damageInfo.Defender))
        {
            SimulateAttack(damageInfo, AttackType.FollowUp);
        }
    }

    private static bool CanFollowUp(Unit attackerUnit, Unit defenderUnit)
    {
        return FollowUpEffectsManager.GetFollowUpEffects(attackerUnit.FollowUpEffects) switch
        {
            FollowUpEffectsResult.Guaranteed => true,
            FollowUpEffectsResult.Denied => false,
            _ => CanFollowUpBasedOnSpd(attackerUnit, defenderUnit)
        };
    }
    
    private static bool CanFollowUpBasedOnSpd(Unit attackerUnit, Unit defenderUnit)
    {
        int followUpSpeedThreshold = 4;
        int actualSpeedDifference = UnitHelper.GetTotalStat(attackerUnit, StatType.Spd, AttackType.None) -
                                    UnitHelper.GetTotalStat(defenderUnit, StatType.Spd, AttackType.None);
        
        return actualSpeedDifference > followUpSpeedThreshold;
    }

    public void ReportNoFollowUp(DamageInfo damageInfo)
    {
        if (IsUnitUnableToCounterAttack(damageInfo.Defender))
        {
            ReportSpecialNoFollowUp(damageInfo);
        }
        else
        {
            ReportNormalNoFollowUp(damageInfo);
        }
    }

    private void ReportSpecialNoFollowUp(DamageInfo damageInfo)
    {
        if (!CanFollowUp(damageInfo.Attacker, damageInfo.Defender))
        {
            _view.ReportSpecialNoFollowUp(damageInfo);
        }
    }
    
    private void ReportNormalNoFollowUp(DamageInfo damageInfo)
    {
        if (!CanFollowUp(damageInfo.Attacker, damageInfo.Defender) &&
            !CanFollowUp(damageInfo.Defender, damageInfo.Attacker))
        {
            _view.ReportNormalNoFollowUp();
        }
    }
}
