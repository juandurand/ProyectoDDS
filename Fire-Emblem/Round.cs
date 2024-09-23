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
        ApplySkills(attackerUnit, defenderUnit);
        _view.AnnounceSkills(attackerUnit);
        _view.AnnounceSkills(defenderUnit);
        if (SimulateAttack(attackerUnit, defenderUnit, "First Attack"))
        {
            ResetSkills(attackerUnit, defenderUnit);
            return;
        }
        if (SimulateAttack(defenderUnit, attackerUnit, "Counter Attack"))
        {
            ResetSkills(attackerUnit, defenderUnit);
            return;
        }
        SimulateFollowUp(attackerUnit, defenderUnit);
        ResetSkills(attackerUnit, defenderUnit);
    }

    private void ApplySkills(Unit attackerUnit, Unit defenderUnit)
    {
        Dictionary<string, object> roundInfo = new Dictionary<string, object>();
        roundInfo["Unit"] = attackerUnit;
        roundInfo["Rival"] = defenderUnit;

        foreach (Skill skill in attackerUnit.Skills)
        {
            skill.Apply(roundInfo, "AnyButNeutralization");
        }
        foreach (Skill skill in defenderUnit.Skills)
        {
            skill.Apply(roundInfo, "AnyButNeutralization");
        }
        foreach (Skill skill in attackerUnit.Skills)
        {
            skill.Apply(roundInfo, "Neutralization");
        }
        foreach (Skill skill in defenderUnit.Skills)
        {
            skill.Apply(roundInfo, "Neutralization");
        }
    }

    private void ResetSkills(Unit attackerUnit, Unit defenderUnit)
    {
        attackerUnit.ResetBonus();
        attackerUnit.ResetPenalty();
        defenderUnit.ResetBonus();
        defenderUnit.ResetPenalty();
    }
    
    private bool SimulateAttack(Unit attackerUnit, Unit defenderUnit, string attackType)
    {
        int damage = Damage.GetDamage(attackerUnit, defenderUnit, attackType);
        defenderUnit.DealDamage(damage);
        _view.ReportAttack(attackerUnit, defenderUnit, damage);
        return !defenderUnit.IsUnitAlive();
    }

    private void SimulateFollowUp(Unit attackerUnit, Unit defenderUnit)
    {
        if (CanFollowUp(attackerUnit, defenderUnit))
        {
            SimulateAttack(attackerUnit, defenderUnit, "Follow Up");
        }
        else if (CanFollowUp(defenderUnit, attackerUnit))
        {
            SimulateAttack(defenderUnit, attackerUnit, "Follow Up");
        }
        else
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }
    }

    private bool CanFollowUp(Unit attackerUnit, Unit defenderUnit)
    {
        int followUpSpeedThreshold = 4;
        return attackerUnit.GetTotalSpd() - defenderUnit.GetTotalSpd() > followUpSpeedThreshold;
    }

}