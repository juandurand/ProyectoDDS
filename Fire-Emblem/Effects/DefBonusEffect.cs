using Fire_Emblem_Common;
namespace Fire_Emblem.Effects;

public class DefBonusEffect:Effect
{
    private readonly int _defBonus;

    public DefBonusEffect(int defBonus)
    {
        _defBonus = defBonus;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.DefBonus += _defBonus;
    }
}