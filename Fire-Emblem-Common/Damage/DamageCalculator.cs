using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;

namespace Fire_Emblem_Common.Damage;

public static class DamageCalculator
{
    public static int GetDamage(DamageInfo damageInfo)
    {
        int baseDamage = GetBaseDamage(damageInfo);
        
        int damageWithEffects = ApplyDamageEffects(baseDamage, damageInfo);
        
        return Math.Max(damageWithEffects, 0);
    }

    private static int GetBaseDamage(DamageInfo damageInfo)
    {
        double weaponTriangleBonus = WeaponTriangle.GetWtb(damageInfo.Attacker.Weapon,
                                                                 damageInfo.Defender.Weapon);
        int defense = GetDefenseByWeapon(damageInfo);
        
        int baseDamage = Convert.ToInt32(Math.Floor(UnitManager.GetTotalStat(damageInfo.Attacker, StatType.Atk,
                                                        damageInfo.AttackType) * weaponTriangleBonus)) - defense;
        
        return Math.Max(baseDamage, 0);
    }
    
    private static int ApplyDamageEffects(int baseDamage, DamageInfo damageInfo)
    {
        baseDamage += DamageEffectsController.GetTotalBonus(damageInfo.Attacker.DamageEffects, damageInfo.AttackType);
        
        double modifiedDamage = baseDamage * DamageEffectsController.GetTotalPercentageReduction(
                                         damageInfo.Defender.DamageEffects, damageInfo.AttackType);
        
        modifiedDamage = Math.Round(modifiedDamage, 9);
        
        return Convert.ToInt32(Math.Floor(modifiedDamage)) - damageInfo.Defender.DamageEffects.Penalty;
    }
    
    private static int GetDefenseByWeapon(DamageInfo damageInfo)
    {
        return damageInfo.Attacker.Weapon switch
        {
            WeaponType.Magic => UnitManager.GetTotalStat(damageInfo.Defender, StatType.Res, damageInfo.AttackType),
            _ => UnitManager.GetTotalStat(damageInfo.Defender, StatType.Def, damageInfo.AttackType)
        };
    }
    
    public static int GetDamageWithoutDamageReductions(DamageInfo damageInfo)
    {
        int baseDamage = GetBaseDamage(damageInfo);
        
        int damageWithBonus = baseDamage + DamageEffectsController.GetTotalBonus(
                                damageInfo.Attacker.DamageEffects, damageInfo.AttackType);
        
        return damageWithBonus;
    }
}
