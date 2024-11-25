using Fire_Emblem_Common.ConditionEvaluators;
using Fire_Emblem_Common.Skills;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.PersonalizedInterfaces;

public class SkillComponentList 
{
    private readonly List<SkillComponent> _components;

    public SkillComponentList()
    {
        _components = new List<SkillComponent>();
    }
    
    public void AddSkillComponent(ConditionEvaluator conditionEvaluator, EffectApplier effectApplier)
    {
        _components.Add(new SkillComponent(conditionEvaluator, effectApplier));
    }

    public SkillComponent GetSkillComponent(int index)
    {
        return _components[index];
    }

    public int Count => _components.Count;
}
