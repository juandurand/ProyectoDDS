using Fire_Emblem_Common.Skills;
using System.Collections;

namespace Fire_Emblem_Common.PersonalizedInterfaces;

public class SkillList : IEnumerable<ISkill>
{
    private readonly List<ISkill> _skills = new List<ISkill>();

    public void Add(ISkill skill) => _skills.Add(skill);
    
    public IEnumerator<ISkill> GetEnumerator()
    {
        return _skills.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}