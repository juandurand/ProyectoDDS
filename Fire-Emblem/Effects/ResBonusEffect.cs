using Fire_Emblem_Common;
namespace Fire_Emblem.Effects;

public class ResBonusEffect:Effect
{
    private readonly int _resBonus;

    public ResBonusEffect(int resBonus)
    {
        _resBonus = resBonus;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.ResBonus += _resBonus;
    }
}