using Fire_Emblem_Common;

namespace Fire_Emblem;

public static class Damage
{
    public static int GetDamage(Unit attacker, Unit defender, string attackType)
    {
        double weaponTriangleBonus = WeaponTriangle.CalculateWtb(attacker.Weapon, defender.Weapon);
        
        int defense = GetDefenseByWeapon(attacker, defender, attackType);
        
        int damage = Convert.ToInt32(Math.Floor(attacker.GetTotalStat("Atk", attackType) * weaponTriangleBonus)) - defense + attacker.Damage.GetTotalBonus(attackType);
        
        double newDamage = damage * defender.Damage.GetTotalPercentageReduction(attackType);
        
        newDamage = Math.Round(newDamage, 9);
        
        damage = Convert.ToInt32(Math.Floor(newDamage)) - defender.Damage.Penalty;
        
        return Math.Max(damage, 0);
    }

    private static int GetDefenseByWeapon(Unit attacker, Unit defender, string attackType)
    {
        if (attacker.Weapon == "Magic")
        {
            return defender.GetTotalStat("Res", attackType);
        }

        return defender.GetTotalStat("Def", attackType);
    }
}