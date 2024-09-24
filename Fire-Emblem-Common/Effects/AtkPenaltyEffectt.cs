namespace Fire_Emblem_Common.Effects;
public class AtkPenaltyEffectt:Effectt
{
    private readonly int _atkPenalty;

    public AtkPenaltyEffectt(int atkPenalty)
        : base("Penalty")
    {
        _atkPenalty = atkPenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Atk.Penalty += _atkPenalty;
    }
}