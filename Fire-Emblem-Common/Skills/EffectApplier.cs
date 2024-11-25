using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Effects;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Models;

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
    
        switch (typeOfUnit)
        {
            case UnitRole.Unit:
                effect.ApplyEffect(roundInfo.SkillOwner);
                break;

            case UnitRole.Rival:
                effect.ApplyEffect(roundInfo.SkillOwner.ActualOpponent);
                break;

            case UnitRole.Both:
                effect.ApplyEffect(roundInfo.SkillOwner);
                effect.ApplyEffect(roundInfo.SkillOwner.ActualOpponent);
                break;
        }
    }
}
