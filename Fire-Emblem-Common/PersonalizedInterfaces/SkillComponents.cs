using Fire_Emblem_Common.ConditionEvaluators;
using Fire_Emblem_Common.Skills;

namespace Fire_Emblem_Common.PersonalizedInterfaces;

public class SkillComponentList 
{
    private readonly List<(ConditionEvaluator conditionEvaluator, EffectApplier effectApplier)> _components;

    public SkillComponentList()
    {
        _components = new List<(ConditionEvaluator, EffectApplier)>();
    }
    
    public void AddSkillComponent(ConditionEvaluator conditionEvaluator, EffectApplier effectApplier)
    {
        _components.Add((conditionEvaluator, effectApplier));
    }

    public (ConditionEvaluator conditionEvaluator, EffectApplier effectApplier) GetSkillComponent(int index)
    {
        return _components[index];
    }

    public int Count => _components.Count;
}
