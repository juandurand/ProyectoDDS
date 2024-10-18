using Fire_Emblem_Common;
using Fire_Emblem_Common.Skills;

namespace Fire_Emblem;

public static class RoundManager
{
    public static void RoundStarted(RoundInfo roundInfo)
    {
        SetAttacker(roundInfo);
        SetActualOpponent(roundInfo);
        SetFirstAttackDefense(roundInfo);
    }

    private static void SetAttacker(RoundInfo roundInfo)
    {
        roundInfo.Attacker.Attacking = true;
        roundInfo.Defender.Attacking = false;
    }

    private static void SetActualOpponent(RoundInfo roundInfo)
    {
        roundInfo.Attacker.ActualOpponent = roundInfo.Defender;
        roundInfo.Defender.ActualOpponent = roundInfo.Attacker;
    }
    
    private static void SetFirstAttackDefense(RoundInfo roundInfo)
    {
        UnitController.SetFirstAttack(roundInfo.Attacker);
        UnitController.SetFirstDefense(roundInfo.Defender);
    }
    
    public static void ApplyAllSkills(RoundInfo roundInfo)
    {
        for (int applyOrder = 1; applyOrder < 4; applyOrder++)
        {
            roundInfo.SetCurrentSkillOwnerAndRival(roundInfo.Defender, roundInfo.Attacker);
            ApplySkills(roundInfo, applyOrder);

            roundInfo.SetCurrentSkillOwnerAndRival(roundInfo.Attacker, roundInfo.Defender);
            ApplySkills(roundInfo, applyOrder);
        }
    }

    private static void ApplySkills(RoundInfo roundInfo, int applyOrder)
    {
        foreach (Skill skill in roundInfo.SkillOwner.Skills)
        {
            skill.Apply(roundInfo, applyOrder);
        }
    }
    
    public static void RoundEnded(RoundInfo roundInfo)
    {
        ResetSkills(roundInfo);
        SetLastOpponent(roundInfo);
        SetFirstAttackDefense(roundInfo);
    }
    
    private static void ResetSkills(RoundInfo roundInfo)
    {
        UnitController.ResetEffects(roundInfo.Attacker);
        UnitController.ResetEffects(roundInfo.Defender);
    }

    private static void SetLastOpponent(RoundInfo roundInfo)
    {
        roundInfo.Attacker.LastOpponent = roundInfo.Defender;
        roundInfo.Defender.LastOpponent = roundInfo.Attacker;
    }
}
