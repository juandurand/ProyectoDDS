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
        int damage = DamageCalculator.GetDamage(attackerUnit, defenderUnit, attackType);
        defenderUnit.HealthStatus.DealDamage(damage);
        
        _view.ReportAttack(attackerUnit, defenderUnit, damage);
        return !defenderUnit.HealthStatus.IsUnitAlive();
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
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }
    }

    private static bool CanFollowUp(Unit attackerUnit, Unit defenderUnit)
    {
        int followUpSpeedThreshold = 4;
        return attackerUnit.GetTotalStat("Spd", "") - defenderUnit.GetTotalStat("Spd", "") > followUpSpeedThreshold;
    }
}
