using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class HpPenaltyBeforeCombatEffect:Effect
{
    private readonly int _hpPenaltyBeforeCombat;

    public HpPenaltyBeforeCombatEffect(int hpPenaltyBeforeCombat)
        : base(EffectsApplyOrder.ThirdOrder)
    {
        _hpPenaltyBeforeCombat = hpPenaltyBeforeCombat;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.HealthStatus.PenaltyBeforeCombat += _hpPenaltyBeforeCombat;
        unit.HealthStatus.ActualHpValue = Math.Max(unit.HealthStatus.ActualHpValue - _hpPenaltyBeforeCombat, 1);
    }
}