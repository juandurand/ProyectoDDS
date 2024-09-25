using Fire_Emblem_Common;
namespace Fire_Emblem;

public static class RoundManager
{
    public static void ApplySkills(Dictionary<string, Unit> roundInfo)
    {
        ApplySkillsPerUnit(roundInfo["Attacker"], roundInfo["Defender"], roundInfo);
        ApplySkillsPerUnit(roundInfo["Defender"], roundInfo["Attacker"], roundInfo);
    }

    private static void ApplySkillsPerUnit(Unit skillOwner, Unit rival, Dictionary<string, Unit> roundInfo)
    {
        roundInfo["SkillOwner"] = skillOwner;
        roundInfo["Rival"] = rival;

        foreach (Skill skill in skillOwner.Skills)
        {
            skill.Apply(roundInfo);
        }
    }

    public static void RoundEnded(Dictionary<string, Unit> roundInfo)
    {
        ResetSkills(roundInfo);
        SetLastOpponent(roundInfo);
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
}
