namespace Fire_Emblem_Common;

public static class SpecialSkillMapper
{
    private static readonly Dictionary<SpecialSkill, string> _skillToStringMap = new Dictionary<SpecialSkill, string>
    {
        { SpecialSkill.Bushido, "Bushido" },
        { SpecialSkill.MoonTwinWing, "Moon-Twin Wing" },
        { SpecialSkill.DragonsWrath, "Dragon's Wrath" },
        { SpecialSkill.Prescience, "Prescience" },
        { SpecialSkill.ExtraChivalry, "Extra Chivalry" }
    };
    
    public static SpecialSkill? FromString(string skillName)
    {
        foreach (var kvp in _skillToStringMap)
        {
            if (kvp.Value == skillName)
            {
                return kvp.Key;
            }
        }
        return null;
    }
}

