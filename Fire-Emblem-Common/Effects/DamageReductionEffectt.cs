namespace Fire_Emblem_Common.Effects;

public class DamageReductionEffectt:Effectt
{
    private readonly int _damagePenalty;

    public DamageReductionEffectt(int damagePenalty)
        : base(2)
    {
        _damagePenalty = damagePenalty;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Damage.Penalty += _damagePenalty;
    }
}