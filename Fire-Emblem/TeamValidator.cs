namespace Fire_Emblem;

public class TeamValidator
{
    public bool IsPlayerValid(List<string> player, out List<Tuple<string, List<string>>> units)
    {
        units = new List<Tuple<string, List<string>>>();
        
        if (!IsTeamSizeValid(player.Count)) 
        {
            return false;
        }

        foreach (string line in player)
        {
            var (name, skills) = ParseUnit(line);
            if (IsDuplicateUnit(units, name) || !AreSkillsValid(skills)) 
            {
                return false;
            }
            units.Add(Tuple.Create(name, skills));
        }

        return true;
    }
    
    private bool IsTeamSizeValid(int playerCount)
    {
        return playerCount >= 1 && playerCount <= 3;
    }
    
    private bool IsDuplicateUnit(List<Tuple<string, List<string>>> units, string name)
    {
        return units.Any(unit => unit.Item1 == name);
    }
    
    private (string name, List<string> skills) ParseUnit(string line)
    {
        int index1 = line.IndexOf('(');
        if (index1 == -1) 
        {
            return (line.Trim(), new List<string>());
        }

        string name = ExtractName(line, index1);
        string skillsString = ExtractSkillsString(line, index1);
        List<string> skillsList = ParseSkills(skillsString);

        return (name, skillsList);
    }

    private string ExtractName(string line, int index1)
    {
        return line.Substring(0, index1).Trim();
    }

    private string ExtractSkillsString(string line, int index1)
    {
        int index2 = line.IndexOf(')', index1);
        if (index2 == -1) { return string.Empty; }

        return line.Substring(index1 + 1, index2 - index1 - 1).Trim();
    }

    private List<string> ParseSkills(string skillsString)
    {
        var splitSkills = SplitSkills(skillsString);
        
        var trimmedSkills = TrimSkills(splitSkills);
        
        var skillsList = ConvertToList(trimmedSkills);

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

    private List<string> ConvertToList(IEnumerable<string> skills)
    {
        return skills.ToList();
    }

    
    private bool AreSkillsValid(List<string> skillsInfo)
    {
        return skillsInfo.Count <= 2 && (skillsInfo.Count < 2 || skillsInfo[0] != skillsInfo[1]);
    }
    
}