using Fire_Emblem_View.PersonalizedViews;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;


namespace Fire_Emblem;

public class AttackController
{
    private readonly GeneralView _view;

    public AttackController(GeneralView view)
    {
        _view = view;
    }
    
    public bool SimulateAttack(DamageInfo damageInfo)
    {
        if (damageInfo.Attacker.CounterAttackDenial && !damageInfo.Attacker.DenialOfCounterAttackDenial) {
            return false;
        }
        UnitManager.SetAttacked(damageInfo.Attacker);
        int damage = CalculateDamage(damageInfo);
        HealthStatusManager.ApplyPercentageOfDamageBonusAfterAttack(damageInfo.Attacker.HealthStatus, damage);
        ApplyDamage(damageInfo, damage);
        return !HealthStatusManager.IsUnitAlive(damageInfo.Defender.HealthStatus);
    }
    
    private int CalculateDamage(DamageInfo damageInfo)
    {
        return DamageCalculator.GetDamage(damageInfo);
    }

    private void ApplyDamage(DamageInfo damageInfo, int damage)
    {
        HealthStatusManager.DealDamage(damageInfo.Defender.HealthStatus, damage);
        _view.ReportAttack(damageInfo.Attacker, damageInfo.Defender, damage);
    }

    public void SimulateFollowUp(DamageInfo damageInfo)
    {
        if (CanFollowUp(damageInfo.Attacker, damageInfo.Defender))
        {
            SimulateAttack(damageInfo);
        }
    }

    private static bool CanFollowUp(Unit attackerUnit, Unit defenderUnit)
    {
        int followUpSpeedThreshold = 4;
        int actualSpeedDifference = UnitManager.GetTotalStat(attackerUnit, StatType.Spd, AttackType.None) -
                                    UnitManager.GetTotalStat(defenderUnit, StatType.Spd, AttackType.None);
        return actualSpeedDifference > followUpSpeedThreshold;
    }

    public void ReportNoFollowUp(DamageInfo damageInfo)
    {
        if (damageInfo.Defender.CounterAttackDenial && !damageInfo.Defender.DenialOfCounterAttackDenial)
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
