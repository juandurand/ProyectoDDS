namespace Fire_Emblem_Common.Effects;
public class AlterBaseStatsEffectt:Effectt
{
    private bool _isEffectUsed;

    public AlterBaseStatsEffectt(string effectType)
        : base(effectType, 1)
    {
        _isEffectUsed = false;
        
    }
    public override void ApplyEffect(Unit unit)
    {
        if (EffectType == "HP +15")
        {
            if (!_isEffectUsed)
            {
                _isEffectUsed = true;
                unit.Hp.ApplyHpPlus15();
            }
            
        }
        else if (EffectType == "Wrath")
        {
            int bonus = Math.Min(Math.Max(unit.Hp.HpBaseValue - unit.Hp.ActualHpValue, 0), 30);
            unit.Spd.Bonus += bonus;
            unit.Atk.Bonus += bonus;
        }
    }
}