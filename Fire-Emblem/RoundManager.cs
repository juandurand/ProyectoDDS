using Fire_Emblem_Common;
namespace Fire_Emblem;

public static class RoundManager
{
    public static void ApplyAllSkills(Dictionary<string, Unit> roundInfo)
    {
        for (int applyOrder = 1; applyOrder < 4; applyOrder++)
        {
            ApplySkillsPerUnit(roundInfo["Defender"], roundInfo["Attacker"], roundInfo, applyOrder);
            ApplySkillsPerUnit(roundInfo["Attacker"], roundInfo["Defender"], roundInfo, applyOrder);
        }
    }

    private static void ApplySkillsPerUnit(Unit skillOwner, Unit rival, Dictionary<string, Unit> roundInfo, int applyOrder)
    {
        roundInfo["SkillOwner"] = skillOwner;
        roundInfo["Rival"] = rival;

        foreach (Skill skill in skillOwner.Skills)
        {
            skill.Apply(roundInfo, applyOrder);
            
        }
    }

    public static void RoundStarted(Dictionary<string, Unit> roundInfo)
    {
        SetActualOpponent(roundInfo);
        SetAttacker(roundInfo);
        SetFirstAttackDefense(roundInfo);
    }

    private static void SetAttacker(Dictionary<string, Unit> roundInfo)
    {
        roundInfo["Attacker"].Attacking = true;
        roundInfo["Defender"].Attacking = false;
    }

    private static void SetActualOpponent(Dictionary<string, Unit> roundInfo)
    {
        roundInfo["Attacker"].ActualOpponent = roundInfo["Defender"];
        roundInfo["Defender"].ActualOpponent = roundInfo["Attacker"];
    }
    
    public static void RoundEnded(Dictionary<string, Unit> roundInfo)
    {
        ResetSkills(roundInfo);
        SetLastOpponent(roundInfo);
        SetFirstAttackDefense(roundInfo);
    }
    
    private static void ResetSkills(Dictionary<string, Unit> roundInfo)
    {
        roundInfo["Attacker"].ResetEffects();
        roundInfo["Defender"].ResetEffects();
    }

    private static void SetLastOpponent(Dictionary<string, Unit> roundInfo)
    {
        roundInfo["Attacker"].LastOpponent = roundInfo["Defender"];
        roundInfo["Defender"].LastOpponent = roundInfo["Attacker"];
    }
    
    private static void SetFirstAttackDefense(Dictionary<string, Unit> roundInfo)
    {
        roundInfo["Attacker"].SetFirstAttack();
        roundInfo["Defender"].SetFirstDefense();
    }
}
