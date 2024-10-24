using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class SpdBonusEffect:Effect
{
    private readonly int _spdBonus;

    public SpdBonusEffect(int spdBonus)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _spdBonus = spdBonus;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Spd.Bonus += _spdBonus;
    }
}