using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class HpPenaltyAfterCombatIfAttackedEffect : Effect
{
    private readonly int _hpPenaltyAfterCombatIfAttacked;
    
    public HpPenaltyAfterCombatIfAttackedEffect(int hpPenaltyAfterCombatIfAttacked)
        : base(EffectsApplyOrder.ThirdOrder)
    {
        _hpPenaltyAfterCombatIfAttacked = hpPenaltyAfterCombatIfAttacked;
    }
    
    public override void ApplyEffect(Unit unit)
    {
        unit.HealthStatus.PenaltyAfterCombatIfUnitAttacked += _hpPenaltyAfterCombatIfAttacked;
    }
}