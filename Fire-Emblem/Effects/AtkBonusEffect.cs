using Fire_Emblem_Common;
namespace Fire_Emblem.Effects;

public class AtkBonusEffect:Effect
{
    private readonly int _atkBonus;

    public AtkBonusEffect(int atkBonus)
    {
        _atkBonus = atkBonus;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.AtkBonus += _atkBonus;
    }
}