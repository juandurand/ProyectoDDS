using Fire_Emblem_Common;

namespace Fire_Emblem;

public static class DamageCalculator
{
    public static int GetDamage(Unit attacker, Unit defender, AttackType attackType)
    {
        double weaponTriangleBonus = WeaponTriangle.CalculateWtb(attacker.Weapon, defender.Weapon);
        
        int defense = GetDefenseByWeapon(attacker, defender, attackType);
        
        int damage = Convert.ToInt32(Math.Floor(UnitController.GetTotalStat(attacker, StatType.Atk, attackType) * weaponTriangleBonus)) - defense;
        
        damage = Math.Max(damage, 0) + attacker.Damage.GetTotalBonus(attackType);
        
        double newDamage = damage * defender.Damage.GetTotalPercentageReduction(attackType);
        
        newDamage = Math.Round(newDamage, 9);
        
        damage = Convert.ToInt32(Math.Floor(newDamage)) - defender.Damage.Penalty;
        
        return Math.Max(damage, 0);
    }
    
    public static int GetDamageWithoutSkills(Unit attacker, Unit defender, AttackType attackType)
    {
        double weaponTriangleBonus = WeaponTriangle.CalculateWtb(attacker.Weapon, defender.Weapon);
        
        int defense = GetDefenseByWeapon(attacker, defender, attackType);
        
        int damage = Convert.ToInt32(Math.Floor(UnitController.GetTotalStat(attacker, StatType.Atk, attackType) * weaponTriangleBonus)) - defense;

        damage = Math.Max(damage, 0) + attacker.Damage.GetTotalBonus(attackType);
        
        return Math.Max(damage, 0);
    }

    private static int GetDefenseByWeapon(Unit attacker, Unit defender, AttackType attackType)
    {
        if (attacker.Weapon == WeaponType.Magic)
        {
            return UnitController.GetTotalStat(defender, StatType.Res, attackType);
        }

        return UnitController.GetTotalStat(defender, StatType.Def, attackType);
    }
}