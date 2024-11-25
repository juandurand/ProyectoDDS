using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;
using Fire_Emblem_Common.Helpers;

namespace Fire_Emblem_Common.Effects;

public class HpBaseValuePlusConstantEffect:Effect
{
    private bool _isEffectUsed;
    private readonly int _bonusValue;

    public HpBaseValuePlusConstantEffect(int bonusValue)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _isEffectUsed = false;
        _bonusValue = bonusValue;
    }
    
    public override void ApplyEffect(Unit unit)
    {
        if (!_isEffectUsed)
        {
            _isEffectUsed = true;
            HealthStatusHelper.ApplyHpBaseValueBonus(unit.HealthStatus, _bonusValue);
        }
    }
}