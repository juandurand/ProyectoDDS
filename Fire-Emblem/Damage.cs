namespace Fire_Emblem;

public static class Damage
{
    public static int GetDamage(Unit attacker, Unit defender)
    {
        double wtb = WeaponTriangle.CalculateWtb(attacker.Weapon, defender.Weapon);
        
        int damage;
        if (attacker.Weapon == "Magic")
        {
            damage = Convert.ToInt32(Math.Floor(attacker.Atk * wtb)) - defender.Res;
        }
        else
        {
            damage = Convert.ToInt32(Math.Floor(attacker.Atk * wtb)) - defender.Def;
        }
        
        return Math.Max(damage, 0);
    }
}