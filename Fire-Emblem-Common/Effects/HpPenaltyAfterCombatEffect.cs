using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class HpPenaltyAfterCombatEffect:Effect
{
    private readonly int _hpPenaltyAfterCombat;

    public HpPenaltyAfterCombatEffect(int hpPenaltyAfterCombat)
        : base(EffectsApplyOrder.ThirdOrder)
    {
        _hpPenaltyAfterCombat = hpPenaltyAfterCombat;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.HealthStatus.PenaltyAfterCombat += _hpPenaltyAfterCombat;
    }
}