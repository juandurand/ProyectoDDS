using Fire_Emblem_View;
using Fire_Emblem_Common;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;
using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem;

public class AttackManager
{
    private readonly View _view;

    public AttackManager(View view)
    {
        _view = view;
    }
    
    public bool SimulateAttack(DamageInfo damageInfo)
    {
        int damage = CalculateDamage(damageInfo);
        ApplyDamage(damageInfo, damage);
        return !HealthStatusController.IsUnitAlive(damageInfo.Defender.HealthStatus);
    }
    
    private int CalculateDamage(DamageInfo damageInfo)
    {
        return DamageCalculator.GetDamage(damageInfo);
    }

    private void ApplyDamage(DamageInfo damageInfo, int damage)
    {
        HealthStatusController.DealDamage(damageInfo.Defender.HealthStatus, damage);
        _view.ReportAttack(damageInfo.Attacker, damageInfo.Defender, damage);
    }

    public void SimulateFollowUp(DamageInfo damageInfo)
    {
        if (CanFollowUp(damageInfo.Attacker, damageInfo.Defender))
        {
            SimulateAttack(damageInfo);
        }
        else if (CanFollowUp(damageInfo.Defender, damageInfo.Attacker))
        {
            damageInfo.SwitchUnits();
            SimulateAttack(damageInfo);
        }
        else
        {
            _view.AnnounceNoFollowUp();
        }
    }

    private static bool CanFollowUp(Unit attackerUnit, Unit defenderUnit)
    {
        int followUpSpeedThreshold = 4;
        int actualSpeedDifference = UnitController.GetTotalStat(attackerUnit, StatType.Spd, AttackType.None) -
                                    UnitController.GetTotalStat(defenderUnit, StatType.Spd, AttackType.None);
        return actualSpeedDifference > followUpSpeedThreshold;
    }
}
