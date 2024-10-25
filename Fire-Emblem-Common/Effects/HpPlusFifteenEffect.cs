using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.Effects;

public class HpPlusFifteenEffect:Effect
{
    private bool _isEffectUsed;

    public HpPlusFifteenEffect()
        : base(EffectsApplyOrder.FirstOrder)
    {
        _isEffectUsed = false;
    }
    
    public override void ApplyEffect(Unit unit)
    {
        if (!_isEffectUsed)
        {
            _isEffectUsed = true;
            HealthStatusManager.ApplyHpPlus15(unit.HealthStatus);
        }
    }
}