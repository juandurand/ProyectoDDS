namespace Fire_Emblem_Common.Effects;
public class AtkBonusEffectt:Effectt
{
    private readonly int _atkBonus;
    private readonly string _attackType;

    public AtkBonusEffectt(int atkBonus, string attackType = "All")
        : base("Bonus")
    {
        _atkBonus = atkBonus;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        if (_attackType == "All")
        {
            unit.AtkBonus += _atkBonus;
        }
        else 
        {
            unit.AtkFirstAttackBonus += _atkBonus;
        }
    }
}