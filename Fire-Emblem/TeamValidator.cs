using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem;

public class TeamValidator
{
    public bool IsPlayerValid(StringList playerLines, out PlayerUnitsInfo playerUnitsInfo)
    {
        playerUnitsInfo = new PlayerUnitsInfo();
        
        if (!IsTeamSizeValid(playerLines.Count)) 
        {
            return false;
        }

        foreach (string line in playerLines)
        {
            var unitInfo = ParseUnit(line);
            if (playerUnitsInfo.IsDuplicateUnit(unitInfo.GetUnitName()) || !AreSkillsValid(unitInfo.GetUnitSkills())) 
            {
                return false;
            }
            playerUnitsInfo.Add(unitInfo);
        }

        return true;
    }
    
    private bool IsTeamSizeValid(int playerCount)
    {
        return playerCount >= 1 && playerCount <= 3;
    }
    
    private UnitInfo ParseUnit(string line)
    {
        UnitInfo unitInfo = new UnitInfo();
        
        int index1 = line.IndexOf('(');
        
        if (index1 == -1) 
        {
            unitInfo.SetUnitInfo(line.Trim(), new StringList());
            return unitInfo;
        }

        string name = ExtractName(line, index1);
        
        string skillsString = ExtractSkillsString(line, index1);
        StringList skillsList = ParseSkills(skillsString);
        
        unitInfo.SetUnitInfo(name, skillsList);
        return unitInfo;
    }

    private string ExtractName(string line, int index1)
    {
        line = line.Substring(0, index1);
        return line.Trim();
    }

    private string ExtractSkillsString(string line, int index1)
    {
        int index2 = line.IndexOf(')', index1);
        
        if (index2 == -1) { return string.Empty; }

        line = line.Substring(index1 + 1, index2 - index1 - 1);
        
        return line.Trim();
    }

    private StringList ParseSkills(string skillsString)
    {
        var splitSkills = SplitSkills(skillsString);
        
        var trimmedSkills = TrimSkills(splitSkills);
        
        StringList skillsList = ConvertToList(trimmedSkills);

        return skillsList;
    }

    private IEnumerable<string> SplitSkills(string skillsString)
    {
        return skillsString.Split(',');
    }

    private IEnumerable<string> TrimSkills(IEnumerable<string> skills)
    {
        foreach (var skill in skills)
        {
            yield return skill.Trim();
        }
    }

    private StringList ConvertToList(IEnumerable<string> skills)
    {
        StringList skillsList = new StringList();
        
        foreach (var skill in skills)
        {
            skillsList.Add(skill);
        }

        return skillsList;
    }
    
    private bool AreSkillsValid(StringList skillsInfo)
    {
        return skillsInfo.Count <= 2 && (skillsInfo.Count < 2 || skillsInfo.Get(0) != skillsInfo.Get(1));
    }
}