using Fire_Emblem_Common.ConditionEvaluators;
using Fire_Emblem_Common.Skills;

namespace Fire_Emblem_Common.Models;

public class SkillComponent
{
    public readonly ConditionEvaluator ConditionEvaluator;
    public readonly EffectApplier EffectApplier;
    
    public SkillComponent(ConditionEvaluator conditionEvaluator, EffectApplier effectApplier)
    {
        ConditionEvaluator = conditionEvaluator;
        EffectApplier = effectApplier;
    }
}