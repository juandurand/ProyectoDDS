namespace Fire_Emblem_Common.Effects;
public class WrathEffectt:Effectt
{

    public WrathEffectt()
        : base(1) {}
    public override void ApplyEffect(Unit unit)
    {
        int bonus = Math.Min(Math.Max(unit.HealthStatus.HpBaseValue - unit.HealthStatus.ActualHpValue, 0), 30);
        unit.Spd.Bonus += bonus;
        unit.Atk.Bonus += bonus;
    }
}