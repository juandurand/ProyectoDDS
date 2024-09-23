namespace Fire_Emblem_Common.Effects;

public class SandstormEffectt:Effectt
{
    public SandstormEffectt()
        : base("Bonus/Penalty"){}
    public override void ApplyEffect(Unit unit)
    {
        int newTotalAtk = Convert.ToInt32(Math.Floor(1.5 * unit.Def));
        int adjustment = newTotalAtk - unit.Atk;
        
        if (adjustment > 0) {
            unit.AtkFollowUpBonus += adjustment;
        } else if (adjustment < 0) {
            unit.AtkFollowUpPenalty += Math.Abs(adjustment);
        }
    }
}