using Fire_Emblem_View;
using Fire_Emblem_Common;
namespace Fire_Emblem;

public class AttackManager
{
    private readonly View _view;

    public AttackManager(View view)
    {
        _view = view;
    }

    // Si el defensor muere, retorna True para que no se sigan atacando en esa ronda
    public bool SimulateAttack(Unit attackerUnit, Unit defenderUnit, string attackType)
    {
        int damage = CalculateDamage(attackerUnit, defenderUnit, attackType);
        ApplyDamage(attackerUnit, defenderUnit, damage);
        return !defenderUnit.HealthStatus.IsUnitAlive();
    }
    
    private int CalculateDamage(Unit attackerUnit, Unit defenderUnit, string attackType)
    {
        return DamageCalculator.GetDamage(attackerUnit, defenderUnit, attackType);
    }

    private void ApplyDamage(Unit attackerUnit, Unit defenderUnit, int damage)
    {
        defenderUnit.HealthStatus.DealDamage(damage);
        _view.ReportAttack(attackerUnit, defenderUnit, damage);
    }

    public void SimulateFollowUp(Unit attackerUnit, Unit defenderUnit)
    {
        if (CanFollowUp(attackerUnit, defenderUnit))
        {
            SimulateAttack(attackerUnit, defenderUnit, "Follow-Up");
        }
        else if (CanFollowUp(defenderUnit, attackerUnit))
        {
            SimulateAttack(defenderUnit, attackerUnit, "Follow-Up");
        }
        else
        {
            _view.AnnounceNoFollowUp();
        }
    }

    private static bool CanFollowUp(Unit attackerUnit, Unit defenderUnit)
    {
        int followUpSpeedThreshold = 4;
        return attackerUnit.GetTotalStat("Spd", "") - defenderUnit.GetTotalStat("Spd", "") > followUpSpeedThreshold;
    }
}
