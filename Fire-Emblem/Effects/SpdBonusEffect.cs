using Fire_Emblem_Common;
namespace Fire_Emblem.Effects;

public class SpdBonusEffect:Effect
{
    private readonly int _spdBonus;

    public SpdBonusEffect(int spdBonus)
    {
        _spdBonus = spdBonus;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.SpdBonus += _spdBonus;
    }
}