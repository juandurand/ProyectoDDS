using Fire_Emblem_Common.Conditions;
using Fire_Emblem_Common.Effects;
namespace Fire_Emblem_Common;

public class Skill
{
    private readonly List<Effectt> _effects;
    private readonly List<Condition> _conditions;
    private readonly string _conditionsConnector;
    private readonly string _typeOfUnit;
    private readonly string _unitOwnerName;

    public Skill(List<Effectt> effects, List<Condition> conditions, string conditionsConnector, string typeOfUnit, string unitOwnerName)
    {
        _effects = effects;
        _conditions = conditions;
        _conditionsConnector = conditionsConnector;
        _typeOfUnit = typeOfUnit;
        _unitOwnerName = unitOwnerName;
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
            else if (_conditions[0].IsConditionSatisfied(roundInfo, _unitOwnerName))
            {
                ApplyEffects(roundInfo, effectType);
            }
        }
    }

    private void ApplyEffects(Dictionary<string, object> roundInfo, string effectType)
    {
        Unit unit = roundInfo["Unit"] as Unit;
        Unit rival = roundInfo["Rival"] as Unit;

        if (unit.PersonalizedName != _unitOwnerName)
        {
            unit = roundInfo["Rival"] as Unit;
            rival = roundInfo["Unit"] as Unit;
        }

        if (effectType != "Neutralization")
        {
            foreach (Effectt effect in _effects.Where(effect => effect.EffectType != "Neutralization"))
            {
                ApplyEffectToAppropriateUnit(effect, unit, rival);
            }
        }
        else
        {
            foreach (Effectt effect in _effects.Where(effect => effect.EffectType == "Neutralization"))
            {
                ApplyEffectToAppropriateUnit(effect, unit, rival);
            }
        }
    }

    private void ApplyEffectToAppropriateUnit(Effectt effect, Unit unit, Unit rival)
    {
        if (_typeOfUnit == "Unit")
        {
            effect.ApplyEffect(unit);
        }
        else if (_typeOfUnit == "Rival")
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
            if (condition.IsConditionSatisfied(roundInfo, _unitOwnerName))
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
            if (!condition.IsConditionSatisfied(roundInfo, _unitOwnerName))
            {
                return false;
            }
        }
        return true;
    }
}