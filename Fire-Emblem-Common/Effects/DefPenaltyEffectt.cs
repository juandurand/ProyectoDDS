namespace Fire_Emblem_Common.Effects;

public class DefPenaltyEffectt:Effectt
{
    private readonly int _defPenalty;

    public DefPenaltyEffectt(int defPenalty)
        : base(1)
    {
        _defPenalty = defPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Def.Penalty += _defPenalty;
    }
}