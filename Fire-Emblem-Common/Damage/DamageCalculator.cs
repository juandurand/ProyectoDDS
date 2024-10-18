using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.Damage;

public static class DamageCalculator
{
    public static int GetDamage(Unit attacker, Unit defender, AttackType attackType)
    {
        int baseDamage = CalculateBaseDamage(attacker, defender, attackType);
        
        int damageWithEffects = ApplyDamageBonusesAndPenalties(baseDamage, attacker, defender, attackType);
        
        return Math.Max(damageWithEffects, 0);
    }

    public static int GetDamageWithoutDamageReductions(Unit attacker, Unit defender, AttackType attackType)
    {
        int baseDamage = CalculateBaseDamage(attacker, defender, attackType);
        
        int damageWithBonus = baseDamage + DamageEffectsController.GetTotalBonus(attacker.DamageEffects, attackType);
        
        return damageWithBonus;
    }

    private static int CalculateBaseDamage(Unit attacker, Unit defender, AttackType attackType)
    {
        double weaponTriangleBonus = WeaponTriangle.CalculateWtb(attacker.Weapon, defender.Weapon);
        int defense = GetDefenseByWeapon(attacker, defender, attackType);
        
        int baseDamage = Convert.ToInt32(Math.Floor(UnitController.GetTotalStat(attacker, StatType.Atk, attackType) * weaponTriangleBonus)) - defense;
        return Math.Max(baseDamage, 0);
    }
    
    private static int ApplyDamageBonusesAndPenalties(int baseDamage, Unit attacker, Unit defender, AttackType attackType)
    {
        baseDamage += DamageEffectsController.GetTotalBonus(attacker.DamageEffects, attackType);
        
        double modifiedDamage = baseDamage * DamageEffectsController.GetTotalPercentageReduction(defender.DamageEffects, attackType);
        modifiedDamage = Math.Round(modifiedDamage, 9);
        
        return Convert.ToInt32(Math.Floor(modifiedDamage)) - defender.DamageEffects.Penalty;
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
