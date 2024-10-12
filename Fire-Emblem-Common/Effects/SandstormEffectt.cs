namespace Fire_Emblem_Common.Effects;

public class SandstormEffectt:Effectt
{
    public SandstormEffectt()
        : base("Bonus/Penalty", 1){}
    public override void ApplyEffect(Unit unit)
    {
        int newTotalAtk = Convert.ToInt32(Math.Floor(1.5 * unit.Def.BaseValue));
        int adjustment = newTotalAtk - unit.Atk.BaseValue;
        
        if (adjustment > 0) {
            unit.Atk.FollowUpBonus += adjustment;
        } else if (adjustment < 0) {
            unit.Atk.FollowUpPenalty += Math.Abs(adjustment);
        }
    }
}