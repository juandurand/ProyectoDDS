
namespace Fire_Emblem_Common.Effects;

public class AverageDefResEffectt:Effectt
{
    public AverageDefResEffectt()
        : base("Bonus/Penalty"){}
    public override void ApplyEffect(Unit unit)
    {
        int average = (unit.Def + unit.Res) / 2;
        int defAdjustment = average - unit.Def;
        int resAdjustment = average - unit.Res;
        
        if (defAdjustment > 0) {
            unit.DefBonus += defAdjustment;
        } else if (defAdjustment < 0) {
            unit.DefPenalty += Math.Abs(defAdjustment);
        }
        
        if (resAdjustment > 0) {
            unit.ResBonus += resAdjustment;
        } else if (resAdjustment < 0) {
            unit.ResPenalty += Math.Abs(resAdjustment);
        }
    }
}