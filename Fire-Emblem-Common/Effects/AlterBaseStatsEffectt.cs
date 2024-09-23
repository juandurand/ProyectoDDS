namespace Fire_Emblem_Common.Effects;
public class AlterBaseStatsEffectt:Effectt
{
    public AlterBaseStatsEffectt()
        : base("Alter Base Stats"){}
    public override void ApplyEffect(Unit unit)
    {
        unit.Hp += 15;
        unit.ActualHp = unit.Hp;
    }
}