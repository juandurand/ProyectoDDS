using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem_Common.TeamLoading;

public class TeamValidator
{
    public bool IsPlayerValid(StringList playerLines)
    {
        PlayerUnitsInfo playerUnitsInfo = new PlayerUnitsInfo();
        
        if (!IsTeamSizeValid(playerLines.Count)) 
        {
            return false;
        }

        foreach (string line in playerLines)
        {
            var unitInfo = ParseUnit(line);
            if (IsUnitInvalid(unitInfo, playerUnitsInfo)) 
            {
                return false;
            }
            playerUnitsInfo.AddUnitInfo(unitInfo);
        }

        return true;
    }
    
    private bool IsTeamSizeValid(int playerCount)
    {
        int maxPlayerCount = 3;
        int minPlayerCount = 1;
        return (playerCount >= minPlayerCount) && (playerCount <= maxPlayerCount);
    }
    
    private UnitInfo ParseUnit(string line)
    {
        UnitInfo unitInfo = new UnitInfo();
        
        int indexOfParenthesis = line.IndexOf('(');
        
        if (indexOfParenthesis == -1)
        {
            return GetNoSkillsUnitInfo(unitInfo, line);
        }

        string name = ExtractName(line, indexOfParenthesis);
        string skillsString = ExtractSkillsString(line, indexOfParenthesis);
        StringList skillsList = ParseSkills(skillsString);
        
        unitInfo.SetUnitInfo(name, skillsList);
        return unitInfo;
    }
    
    private bool IsUnitInvalid(UnitInfo unitInfo, PlayerUnitsInfo playerUnitsInfo)
    {
        return playerUnitsInfo.IsDuplicateUnit(unitInfo.GetUnitName()) || !AreSkillsValid(unitInfo.GetUnitSkills());
    }
    
    private UnitInfo GetNoSkillsUnitInfo(UnitInfo unitInfo, string name)
    {
        unitInfo.SetUnitInfo(name.Trim(), new StringList());
        return unitInfo;
    }

    private string ExtractName(string line, int index)
    {
        line = line.Substring(0, index);
        return line.Trim();
    }

    private string ExtractSkillsString(string line, int indexOfFirstParenthesis)
    {
        int indexOfSecondParenthesis = line.IndexOf(')', indexOfFirstParenthesis);
        
        if (indexOfSecondParenthesis == -1) { return string.Empty; }

        line = line.Substring(indexOfFirstParenthesis + 1,
            indexOfSecondParenthesis - indexOfFirstParenthesis - 1);
        
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
            skillsList.AddString(skill);
        }

        return skillsList;
    }
    
    private bool AreSkillsValid(StringList skillsInfo)
    {
        int maxSkillsCount = 2;
        return skillsInfo.Count <= maxSkillsCount && (skillsInfo.Count < maxSkillsCount || 
                                                      skillsInfo.GetString(0) != skillsInfo.GetString(1));
    }
    
    public PlayerUnitsInfo GetPlayerInfo(StringList playerLines)
    {
        PlayerUnitsInfo playerUnitsInfo = new PlayerUnitsInfo();

        foreach (string line in playerLines)
        {
            var unitInfo = ParseUnit(line);
            playerUnitsInfo.AddUnitInfo(unitInfo);
        }

        return playerUnitsInfo;
    }
}