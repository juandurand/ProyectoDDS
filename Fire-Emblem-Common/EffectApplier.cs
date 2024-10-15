using Fire_Emblem_Common.Effects;
namespace Fire_Emblem_Common;

public class EffectApplier
{
    private readonly Dictionary<string, List<Effectt>> _effects;

    public EffectApplier(Dictionary<string, List<Effectt>> effects)
    {
        _effects = effects;
    }

    public void ApplyEffects(RoundInfo roundInfo, int applyOrder)
    {
        Unit unit = roundInfo.SkillOwner;
        Unit rival = roundInfo.Rival;

        var allEffects = _effects.Values.SelectMany(list => list);

        foreach (var effect in allEffects)
        {
            if (effect.ApplyOrder == applyOrder)
            {
                ApplyEffectToAppropiateUnit(effect, unit, rival);
            }
        }
    }

    private void ApplyEffectToAppropiateUnit(Effectt effect, Unit unit, Unit rival)
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
}
