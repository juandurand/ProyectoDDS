using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class SandstormEffect:Effect
{
    public SandstormEffect()
        : base(EffectsApplyOrder.FirstOrder){}
    public override void ApplyEffect(Unit unit)
    {
        
        int adjustment = GetAdjustment(unit);
        
        if (adjustment > 0) 
        {
            unit.Atk.FollowUpBonus += adjustment;
        } 
        else 
        {
            unit.Atk.FollowUpPenalty += Math.Abs(adjustment);
        }
    }

    private int GetAdjustment(Unit unit)
    {
        int newTotalAtk = Convert.ToInt32(Math.Floor(1.5 * unit.Def.BaseValue));
        return newTotalAtk - unit.Atk.BaseValue;
    }
}