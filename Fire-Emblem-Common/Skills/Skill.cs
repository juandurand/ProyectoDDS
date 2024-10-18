using Fire_Emblem_Common.ConditionEvaluators;

namespace Fire_Emblem_Common.Skills;
public class Skill
{
    private readonly ConditionEvaluator _conditionEvaluator;
    private readonly EffectApplier _effectApplier;

    public Skill(ConditionEvaluator conditionEvaluator, EffectApplier effectApplier)
    {
        _conditionEvaluator = conditionEvaluator;
        _effectApplier = effectApplier;
    }

    public void Apply(RoundInfo roundInfo, int applyOrder)
    {
        if (_conditionEvaluator.AreConditionsSatisfied(roundInfo))
        {
            _effectApplier.ApplyEffects(roundInfo, applyOrder);
        }
    }
}