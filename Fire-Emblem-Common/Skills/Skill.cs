using Fire_Emblem_Common.ConditionEvaluators;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Skills;
public class Skill : ISkill
{
    private readonly ConditionEvaluator _conditionEvaluator;
    private readonly EffectApplier _effectApplier;
    public string Name { get; }

    public Skill(ConditionEvaluator conditionEvaluator, EffectApplier effectApplier, string name)
    {
        _conditionEvaluator = conditionEvaluator;
        _effectApplier = effectApplier;
        Name = name;
    }

    public void Apply(RoundInfo roundInfo, EffectsApplyOrder applyOrder)
    {
        if (_conditionEvaluator.AreConditionsSatisfied(roundInfo))
        {
            _effectApplier.ApplyEffects(roundInfo, applyOrder);
        }
    }
}