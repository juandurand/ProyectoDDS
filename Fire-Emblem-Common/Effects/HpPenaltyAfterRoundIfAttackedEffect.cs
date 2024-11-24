using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class HpPenaltyAfterRoundIfAttackedEffect : Effect
{
    private readonly int _hpPenaltyAfterRoundIfAttacked;
    
    public HpPenaltyAfterRoundIfAttackedEffect(int hpPenaltyAfterRoundIfAttacked)
        : base(EffectsApplyOrder.ThirdOrder)
    {
        _hpPenaltyAfterRoundIfAttacked = hpPenaltyAfterRoundIfAttacked;
    }
    
    public override void ApplyEffect(Unit unit)
    {
        unit.HealthStatus.PenaltyAfterRoundIfUnitAttacked += _hpPenaltyAfterRoundIfAttacked;
    }
}