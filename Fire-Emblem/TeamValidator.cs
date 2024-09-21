namespace Fire_Emblem;

public class TeamValidator
{
    public bool IsPlayerValid(List<string> player, out List<Tuple<string, List<string>>> units)
    {
        units = new List<Tuple<string, List<string>>>();
        
        if (player.Count < 1 || player.Count > 3) { return false;}
        
        foreach (string line in player)
        {
            var (name, skills) = ParseUnit(line);
            if (units.Any(unit => unit.Item1 == name) || !AreSkillsValid(skills)) return false;
            units.Add(Tuple.Create(name, skills));
        }
        
        return true;
    }
    
    private (string name, List<string> skills) ParseUnit(string line)
    {
        int index1 = line.IndexOf('(');
        if (index1 == -1) {return (line.Trim(), new List<string>());}

        string name = line.Substring(0, index1).Trim();
        int index2 = line.IndexOf(')');
        string skillsString = line.Substring(index1 + 1, index2 - index1 - 1).Trim();
        var skillsList = skillsString.Split(',').Select(skill => skill.Trim()).ToList();
        return (name, skillsList);
    }
    
    private bool AreSkillsValid(List<string> skillsInfo)
    {
        return skillsInfo.Count <= 2 && (skillsInfo.Count < 2 || skillsInfo[0] != skillsInfo[1]);
    }
    
}