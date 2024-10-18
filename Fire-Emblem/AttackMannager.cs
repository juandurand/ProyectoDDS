using Fire_Emblem_View;
using Fire_Emblem_Common;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;

namespace Fire_Emblem;

public class AttackManager
{
    private readonly View _view;

    public AttackManager(View view)
    {
        _view = view;
    }
    
    public bool SimulateAttack(Unit attackerUnit, Unit defenderUnit, AttackType attackType)
    {
        int damage = CalculateDamage(attackerUnit, defenderUnit, attackType);
        ApplyDamage(attackerUnit, defenderUnit, damage);
        return !HealthStatusController.IsUnitAlive(defenderUnit.HealthStatus);
    }
    
    private int CalculateDamage(Unit attackerUnit, Unit defenderUnit, AttackType attackType)
    {
        return DamageCalculator.GetDamage(attackerUnit, defenderUnit, attackType);
    }

    private void ApplyDamage(Unit attackerUnit, Unit defenderUnit, int damage)
    {
        HealthStatusController.DealDamage(defenderUnit.HealthStatus, damage);
        _view.ReportAttack(attackerUnit, defenderUnit, damage);
    }

    public void SimulateFollowUp(Unit attackerUnit, Unit defenderUnit)
    {
        if (CanFollowUp(attackerUnit, defenderUnit))
        {
            SimulateAttack(attackerUnit, defenderUnit, AttackType.FollowUp);
        }
        else if (CanFollowUp(defenderUnit, attackerUnit))
        {
            SimulateAttack(defenderUnit, attackerUnit, AttackType.FollowUp);
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
