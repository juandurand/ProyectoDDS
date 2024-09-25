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
            SetLastOpponent(attackerUnit, defenderUnit);
            return;
        }
        if (SimulateAttack(defenderUnit, attackerUnit, "First Attack"))
        {
            ResetSkills(attackerUnit, defenderUnit);
            SetLastOpponent(attackerUnit, defenderUnit);
            return;
        }
        SimulateFollowUp(attackerUnit, defenderUnit);
        SetLastOpponent(attackerUnit, defenderUnit);
        ResetSkills(attackerUnit, defenderUnit);
    }

    private void ApplySkills(Unit attackerUnit, Unit defenderUnit)
    {
        Dictionary<string, object> roundInfo = new Dictionary<string, object>();
        roundInfo["Starter"] = attackerUnit;

        foreach (Skill skill in attackerUnit.Skills)
        {
            roundInfo["SkillOwner"] = attackerUnit;
            roundInfo["Rival"] = defenderUnit;
            skill.Apply(roundInfo, "AnyButNeutralization");
        }
        foreach (Skill skill in defenderUnit.Skills)
        {
            roundInfo["SkillOwner"] = defenderUnit;
            roundInfo["Rival"] = attackerUnit;
            skill.Apply(roundInfo, "AnyButNeutralization");
        }
        foreach (Skill skill in attackerUnit.Skills)
        {
            roundInfo["SkillOwner"] = attackerUnit;
            roundInfo["Rival"] = defenderUnit;
            skill.Apply(roundInfo, "Neutralization");
        }
        foreach (Skill skill in defenderUnit.Skills)
        {
            roundInfo["SkillOwner"] = defenderUnit;
            roundInfo["Rival"] = attackerUnit;
            skill.Apply(roundInfo, "Neutralization");
        }
    }

    private void ResetSkills(Unit attackerUnit, Unit defenderUnit)
    {
        attackerUnit.ResetEffects();
        defenderUnit.ResetEffects();
    }
    
    private bool SimulateAttack(Unit attackerUnit, Unit defenderUnit, string attackType)
    {
        int damage = Damage.GetDamage(attackerUnit, defenderUnit, attackType);
        defenderUnit.Hp.DealDamage(damage);
        _view.ReportAttack(attackerUnit, defenderUnit, damage);
        return !defenderUnit.Hp.IsUnitAlive();
    }

    private void SimulateFollowUp(Unit attackerUnit, Unit defenderUnit)
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

    private bool CanFollowUp(Unit attackerUnit, Unit defenderUnit)
    {
        int followUpSpeedThreshold = 4;
        return attackerUnit.GetTotalSpd() - defenderUnit.GetTotalSpd() > followUpSpeedThreshold;
    }
    
    private static void SetLastOpponent(Unit attackerUnit, Unit defenderUnit)
    {
        attackerUnit.LastOpponent = defenderUnit;
        defenderUnit.LastOpponent = attackerUnit;
    }

}