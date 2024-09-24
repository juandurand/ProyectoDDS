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
            unit.Atk.Bonus += _atkBonus;
        }
        else 
        {
            unit.Atk.FirstAttackBonus += _atkBonus;
        }
    }
}