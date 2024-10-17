using Fire_Emblem_Common.Effects;
namespace Fire_Emblem_Common;

public class EffectApplier
{
    private readonly Dictionary<UnitRole, List<Effectt>> _effects;

    public EffectApplier(Dictionary<UnitRole, List<Effectt>> effects)
    {
        _effects = effects;
    }

    public void ApplyEffects(RoundInfo roundInfo, int applyOrder)
    {
        var allEffects = _effects.Values.SelectMany(list => list);

        foreach (var effect in allEffects)
        {
            if (effect.ApplyOrder == applyOrder)
            {
                ApplyEffectToAppropiateUnit(effect, roundInfo);
            }
        }
    }

    private void ApplyEffectToAppropiateUnit(Effectt effect, RoundInfo roundInfo)
    {
        UnitRole typeOfUnit = _effects.FirstOrDefault(kvp => kvp.Value.Contains(effect)).Key;
        if (typeOfUnit == UnitRole.Unit)
        {
            effect.ApplyEffect(roundInfo.SkillOwner);
        }
        else if (typeOfUnit == UnitRole.Rival)
        {
            effect.ApplyEffect(roundInfo.Rival);
        }
        else if (typeOfUnit == UnitRole.Both)
        {
            effect.ApplyEffect(roundInfo.SkillOwner);
            effect.ApplyEffect(roundInfo.Rival);
        }
    }
}
