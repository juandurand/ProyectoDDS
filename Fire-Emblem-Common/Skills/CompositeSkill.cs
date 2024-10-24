using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.ConditionEvaluators;
using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem_Common.Skills;

public class CompositeSkill : ISkill
{
    private readonly SkillComponentList _skillsComponents;

    public CompositeSkill(SkillComponentList skillsComponents)
    {
        _skillsComponents = skillsComponents;
    }
    
    public void AddComponent(ConditionEvaluator conditionEvaluator, EffectApplier effectApplier)
    {
        _skillsComponents.Add(conditionEvaluator, effectApplier);
    }
    
    public void Apply(RoundInfo roundInfo, EffectsApplyOrder applyOrder)
    {
        for (int i = 0; i < _skillsComponents.Count; i++)
        {
            var (conditionEvaluator, effectApplier) = _skillsComponents.Get(i);
            if (conditionEvaluator.AreConditionsSatisfied(roundInfo))
            {
                effectApplier.ApplyEffects(roundInfo, applyOrder);
            }
        }
    }
}
