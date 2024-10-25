using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Effects;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Skills;

public class EffectApplier
{
    private readonly EffectByUnitType _effects;

    public EffectApplier(EffectByUnitType effects)
    {
        _effects = effects;
    }

    public void ApplyEffects(RoundInfo roundInfo, EffectsApplyOrder applyOrder)
    {
        var allEffects = _effects.GetAllEffects();

        foreach (var effect in allEffects)
        {
            if (effect.ApplyOrder == applyOrder)
            {
                ApplyEffectToAppropiateUnit(effect, roundInfo);
            }
        }
    }

    private void ApplyEffectToAppropiateUnit(Effect effect, RoundInfo roundInfo)
    {
        UnitRole typeOfUnit = _effects.GetUnitRoleForEffect(effect);
        
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
