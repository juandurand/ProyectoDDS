using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class AverageDefResEffect:Effect
{
    private int _defAdjustment;
    private int _resAdjustment;

    public AverageDefResEffect()
        : base(EffectsApplyOrder.FirstOrder)
    {
        _resAdjustment = 0;
        _defAdjustment = 0;
    }
    
    public override void ApplyEffect(Unit unit)
    {
        SetAdjustments(unit);
        
        if (_defAdjustment > 0) 
        {
            unit.Def.Bonus += _defAdjustment;
        } 
        else 
        {
            unit.Def.Penalty += Math.Abs(_defAdjustment);
        }
        
        if (_resAdjustment > 0) 
        {
            unit.Res.Bonus += _resAdjustment;
        } 
        else 
        {
            unit.Res.Penalty += Math.Abs(_resAdjustment);
        }
    }

    private void SetAdjustments(Unit unit)
    {
        int average = (unit.Def.BaseValue + unit.Res.BaseValue) / 2;
        _defAdjustment = average - unit.Def.BaseValue;
        _resAdjustment = average - unit.Res.BaseValue;
    }
    
}