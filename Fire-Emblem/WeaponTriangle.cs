namespace Fire_Emblem;

public static class WeaponTriangle
{
    private static readonly Dictionary<string, (string advantage, string disadvantage)> WeaponTriangleDic = new Dictionary<string, (string, string)>
    {
        { "Sword", ("Axe", "Lance") },
        { "Lance", ("Sword", "Axe") },
        { "Axe", ("Lance", "Sword") }
    };

    public static double CalculateWtb(string attackerWeapon, string defenderWeapon)
    {
        // Tal vez es innecesario este if (poner return 1.0 al final)
        if (attackerWeapon == defenderWeapon || attackerWeapon == "Magic" || defenderWeapon == "Magic" || attackerWeapon == "Bow" || defenderWeapon == "Bow")
        {
            return 1.0;
        }

        if (WeaponTriangleDic[attackerWeapon].advantage == defenderWeapon)
        {
            return 1.2;
        }
        
        if (WeaponTriangleDic[attackerWeapon].disadvantage == defenderWeapon)
        {
            return 0.8;
        }

        return 1.0;
    }
}