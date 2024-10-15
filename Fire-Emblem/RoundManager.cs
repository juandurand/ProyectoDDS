using Fire_Emblem_Common;
namespace Fire_Emblem;

public static class RoundManager
{
    public static void ApplyAllSkills(RoundInfo roundInfo)
    {
        for (int applyOrder = 1; applyOrder < 4; applyOrder++)
        {
            ApplySkillsPerUnit(roundInfo.Defender, roundInfo.Attacker, roundInfo, applyOrder);
            ApplySkillsPerUnit(roundInfo.Attacker, roundInfo.Defender, roundInfo, applyOrder);
        }
    }

    private static void ApplySkillsPerUnit(Unit skillOwner, Unit rival, RoundInfo roundInfo, int applyOrder)
    {
        roundInfo.SkillOwner = skillOwner;
        roundInfo.Rival = rival;

        foreach (Skill skill in skillOwner.Skills)
        {
            skill.Apply(roundInfo, applyOrder);
            
        }
    }

    public static void RoundStarted(RoundInfo roundInfo)
    {
        SetActualOpponent(roundInfo);
        SetAttacker(roundInfo);
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
    
    public static void RoundEnded(RoundInfo roundInfo)
    {
        ResetSkills(roundInfo);
        SetLastOpponent(roundInfo);
        SetFirstAttackDefense(roundInfo);
    }
    
    private static void ResetSkills(RoundInfo roundInfo)
    {
        roundInfo.Attacker.ResetEffects();
        roundInfo.Defender.ResetEffects();
    }

    private static void SetLastOpponent(RoundInfo roundInfo)
    {
        roundInfo.Attacker.LastOpponent = roundInfo.Defender;
        roundInfo.Defender.LastOpponent = roundInfo.Attacker;
    }
    
    private static void SetFirstAttackDefense(RoundInfo roundInfo)
    {
        roundInfo.Attacker.SetFirstAttack();
        roundInfo.Defender.SetFirstDefense();
    }
}
