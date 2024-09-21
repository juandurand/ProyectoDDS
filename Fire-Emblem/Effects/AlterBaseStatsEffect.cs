using Fire_Emblem_Common;

namespace Fire_Emblem.Effects;

public class AlterBaseStatsEffect:Effect
{
    public override void ApplyEffect(Unit unit)
    {
        unit.Hp += 15;
        unit.ActualHp = unit.Hp;
    }
}