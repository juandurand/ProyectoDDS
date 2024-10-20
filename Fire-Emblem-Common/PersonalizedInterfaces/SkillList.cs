using Fire_Emblem_Common.Skills;
using System.Collections;

namespace Fire_Emblem_Common.PersonalizedInterfaces;

public class SkillList : IEnumerable<Skill>
{
    private readonly List<Skill> _skills = new List<Skill>();

    public void Add(Skill skill) => _skills.Add(skill);
    
    public IEnumerator<Skill> GetEnumerator()
    {
        return _skills.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}