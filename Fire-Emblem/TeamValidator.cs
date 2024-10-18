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
            var (name, skills) = ParseUnit(line);
            if (playerUnitsInfo.IsDuplicateUnit(name) || !AreSkillsValid(skills)) 
            {
                return false;
            }
            playerUnitsInfo.Add(Tuple.Create(name, skills));
        }

        return true;
    }
    
    private bool IsTeamSizeValid(int playerCount)
    {
        return playerCount >= 1 && playerCount <= 3;
    }
    
    private (string name, StringList skills) ParseUnit(string line)
    {
        int index1 = line.IndexOf('(');
        
        if (index1 == -1) 
        {
            return (line.Trim(), new StringList());
        }

        string name = ExtractName(line, index1);
        
        string skillsString = ExtractSkillsString(line, index1);
        
        StringList skillsList = ParseSkills(skillsString);

        return (name, skillsList);
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