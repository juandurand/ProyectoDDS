namespace Fire_Emblem_Common.Effects;
public class AtkBonusEffectt:Effectt
{
    private readonly int _atkBonus;
    private readonly AttackType _attackType;

    public AtkBonusEffectt(int atkBonus, AttackType attackType = AttackType.None)
        : base("Bonus", 1)
    {
        _atkBonus = atkBonus;
        _attackType = attackType;
    }

    public override void ApplyEffect(Unit unit)
    {
        if (_attackType == AttackType.None)
        {
            unit.Atk.Bonus += _atkBonus;
        }
        else if (_attackType == AttackType.FirstAttack)
        {
            unit.Atk.FirstAttackBonus += _atkBonus;
        }
        else
        {
            unit.Atk.FollowUpBonus += _atkBonus;
        }
    }
}