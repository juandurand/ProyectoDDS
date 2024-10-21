using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.Effects;

public class AverageDefResEffect:Effect
{
    public AverageDefResEffect()
        : base(EffectsApplyOrder.FirstOrder){}
    public override void ApplyEffect(Unit unit)
    {
        (int defAdjustment, int resAdjustment) = GetDefAndResAdjustment(unit);
        
        if (defAdjustment > 0) 
        {
            unit.Def.Bonus += defAdjustment;
        } 
        else 
        {
            unit.Def.Penalty += Math.Abs(defAdjustment);
        }
        
        if (resAdjustment > 0) 
        {
            unit.Res.Bonus += resAdjustment;
        } 
        else 
        {
            unit.Res.Penalty += Math.Abs(resAdjustment);
        }
    }

    private (int, int) GetDefAndResAdjustment(Unit unit)
    {
        int average = (unit.Def.BaseValue + unit.Res.BaseValue) / 2;
        int defAdjustment = average - unit.Def.BaseValue;
        int resAdjustment = average - unit.Res.BaseValue;
        return (defAdjustment, resAdjustment);
    }
    
}