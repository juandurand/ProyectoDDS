namespace Fire_Emblem_Common.Effects;

public class DefPenaltyEffectt:Effectt
{
    private readonly int _defPenalty;

    public DefPenaltyEffectt(int defPenalty)
        : base("Penalty")
    {
        _defPenalty = defPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.DefPenalty += _defPenalty;
    }
}