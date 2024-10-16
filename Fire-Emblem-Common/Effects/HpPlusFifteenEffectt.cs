namespace Fire_Emblem_Common.Effects;
public class HpPlusFifteenEffectt:Effectt
{
    private bool _isEffectUsed;

    public HpPlusFifteenEffectt()
        : base(1)
    {
        _isEffectUsed = false;
        
    }
    public override void ApplyEffect(Unit unit)
    {
        if (!_isEffectUsed)
        {
            _isEffectUsed = true;
            HealthStatusController.ApplyHpPlus15(unit.HealthStatus);
        }
    }
}