namespace Fire_Emblem;
using Fire_Emblem_Common;

public static class Damage
{
    public static int GetDamage(Unit attacker, Unit defender, string attackType)
    {
        double weaponTriangleBonus = WeaponTriangle.CalculateWtb(attacker.Weapon, defender.Weapon);
        
        int defense = attacker.Weapon == "Magic" ? defender.GetTotalRes(attackType) : defender.GetTotalDef(attackType);
        
        int damage = Convert.ToInt32(Math.Floor(attacker.GetTotalAtk(attackType) * weaponTriangleBonus)) - defense;
        
        return Math.Max(damage, 0);
    }
}