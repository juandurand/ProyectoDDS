using Fire_Emblem_Common;

namespace Fire_Emblem;

public static class Damage
{
    public static int GetDamage(Unit attacker, Unit defender, string attackType)
    {
        double weaponTriangleBonus = WeaponTriangle.CalculateWtb(attacker.Weapon, defender.Weapon);
        
        int defense = GetDefenseByWeapon(attacker, defender, attackType);
        
        int damage = Convert.ToInt32(Math.Floor(attacker.GetTotalAtk(attackType) * weaponTriangleBonus)) - defense;
        
        return Math.Max(damage, 0);
    }

    private static int GetDefenseByWeapon(Unit attacker, Unit defender, string attackType)
    {
        if (attacker.Weapon == "Magic")
        {
            return defender.GetTotalRes(attackType);
        }

        return defender.GetTotalDef(attackType);
    }
}