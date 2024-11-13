using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class HpBonusAfterCombatEffect:Effect
{
    private readonly int _hpBonusAfterCombat;

    public HpBonusAfterCombatEffect(int hpBonusAfterCombat)
        : base(EffectsApplyOrder.ThirdOrder)
    {
        _hpBonusAfterCombat = hpBonusAfterCombat;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.HealthStatus.BonusAfterCombat += _hpBonusAfterCombat;
    }
}