namespace Fire_Emblem_Common.Effects;
public class AlterBaseStatsEffectt:Effectt
{
    private bool _isEffectUsed;

    public AlterBaseStatsEffectt(string effectType)
        : base(effectType)
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
                unit.Hp += 15;
                unit.ActualHp = unit.Hp;
            }
            
        }
        else if (EffectType == "Wrath")
        {
            int bonus = Math.Min(Math.Max(unit.Hp - unit.ActualHp, 0), 30);
            unit.SpdBonus += bonus;
            unit.AtkBonus += bonus;
        }
    }
}