namespace Fire_Emblem_Common.Effects;

public class SpdBonusEffectt:Effectt
{
    private readonly int _spdBonus;

    public SpdBonusEffectt(int spdBonus)
        : base("Bonus")
    {
        _spdBonus = spdBonus;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.SpdBonus += _spdBonus;
    }
}