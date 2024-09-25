using Fire_Emblem_Common.Conditions;
using Fire_Emblem_Common.Effects;
namespace Fire_Emblem_Common;

public class Skill
{
    private readonly Dictionary<string, List<Effectt>> _effects;
    private readonly List<Condition> _conditions;
    private readonly string _conditionsConnector;

    public Skill(Dictionary<string, List<Effectt>> effects, List<Condition> conditions, string conditionsConnector)
    {
        _effects = effects;
        _conditions = conditions;
        _conditionsConnector = conditionsConnector;
    }

    public void Apply(Dictionary<string, object> roundInfo, string effectType)
    {
        if (_conditionsConnector == "Or")
        {
            if (OrCondition(roundInfo))
            {
                ApplyEffects(roundInfo, effectType);
            }
        }
        else if (_conditionsConnector == "And")
        {
            if (AndCondition(roundInfo))
            {
                ApplyEffects(roundInfo, effectType);
            }
        }
        else
        {
            if (_conditions.Count < 1)
            {
                ApplyEffects(roundInfo, effectType);
            }
            else if (_conditions[0].IsConditionSatisfied(roundInfo))
            {
                ApplyEffects(roundInfo, effectType);
            }
        }
    }

    private void ApplyEffects(Dictionary<string, object> roundInfo, string effectType)
    {
        Unit unit = roundInfo["SkillOwner"] as Unit;
        Unit rival = roundInfo["Rival"] as Unit;

        if (effectType != "Neutralization")
        {
            foreach (var effectList in _effects.Values)
            {
                foreach (Effectt effect in effectList.Where(effect => effect.EffectType != "Neutralization"))
                {
                    ApplyEffectToAppropriateUnit(effect, unit, rival);
                }
            }
        }
        else
        {
            foreach (var effectList in _effects.Values)
            {
                foreach (Effectt effect in effectList.Where(effect => effect.EffectType == "Neutralization"))
                {
                    ApplyEffectToAppropriateUnit(effect, unit, rival);
                }
            }
        }
    }

    private void ApplyEffectToAppropriateUnit(Effectt effect, Unit unit, Unit rival)
    {
        string typeOfUnit = _effects.FirstOrDefault(kvp => kvp.Value.Contains(effect)).Key;
        if (typeOfUnit == "Unit")
        {
            effect.ApplyEffect(unit);
        }
        else if (typeOfUnit == "Rival")
        {
            effect.ApplyEffect(rival);
        }
        else
        {
            effect.ApplyEffect(unit);
            effect.ApplyEffect(rival);
        }
    }

    private bool OrCondition(Dictionary<string, object> roundInfo)
    {
        foreach (Condition condition in _conditions)
        {
            if (condition.IsConditionSatisfied(roundInfo))
            {
                return true;
            }
        }
        return false;
    }
    
    private bool AndCondition(Dictionary<string, object> roundInfo)
    {
        foreach (Condition condition in _conditions)
        {
            if (!condition.IsConditionSatisfied(roundInfo))
            {
                return false;
            }
        }
        return true;
    }
}