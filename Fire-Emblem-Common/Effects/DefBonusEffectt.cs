namespace Fire_Emblem_Common.Effects;

public class DefBonusEffectt:Effectt
{
    private readonly int _defBonus;

    public DefBonusEffectt(int defBonus)
        : base("Bonus")
    {
        _defBonus = defBonus;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Def.Bonus += _defBonus;
    }
}