
namespace Fire_Emblem_Common.Effects;

public class AverageDefResEffectt:Effectt
{
    public AverageDefResEffectt()
        : base("Bonus/Penalty"){}
    public override void ApplyEffect(Unit unit)
    {
        int average = (unit.Def.BaseValue + unit.Res.BaseValue) / 2;
        int defAdjustment = average - unit.Def.BaseValue;
        int resAdjustment = average - unit.Res.BaseValue;
        
        if (defAdjustment > 0) {
            unit.Def.Bonus += defAdjustment;
        } else if (defAdjustment < 0) {
            unit.Def.Penalty += Math.Abs(defAdjustment);
        }
        
        if (resAdjustment > 0) {
            unit.Res.Bonus += resAdjustment;
        } else if (resAdjustment < 0) {
            unit.Res.Penalty += Math.Abs(resAdjustment);
        }
    }
}