using Fire_Emblem_Common;
using Fire_Emblem_View;
namespace Fire_Emblem;

public class Round
{
    private readonly View _view;
    public Round(View view)
    {
        _view = view;
    }
    
    public void SimulateRound(Unit attackerUnit, Unit defenderUnit)
    {
        if (SimulateAttack(attackerUnit, defenderUnit))
        {
            return;
        }
        if (SimulateAttack(defenderUnit, attackerUnit))
        {
            return;
        }
        SimulateFollowUp(attackerUnit, defenderUnit);
    }
    
    private bool SimulateAttack(Unit attackerUnit, Unit defenderUnit)
    {
        int damage = Damage.GetDamage(attackerUnit, defenderUnit);
        defenderUnit.DealDamage(damage);
        _view.ReportAttack(attackerUnit, defenderUnit, damage);
        return !defenderUnit.IsUnitAlive();
    }

    private void SimulateFollowUp(Unit attackerUnit, Unit defenderUnit)
    {
        if (CanFollowUp(attackerUnit, defenderUnit))
        {
            SimulateAttack(attackerUnit, defenderUnit);
        }
        else if (CanFollowUp(defenderUnit, attackerUnit))
        {
            SimulateAttack(defenderUnit, attackerUnit);
        }
        else
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }
    }

    private bool CanFollowUp(Unit fasterUnit, Unit slowerUnit)
    {
        int followUpSpeedThreshold = 4;
        return fasterUnit.Spd - slowerUnit.Spd > followUpSpeedThreshold;
    }

}