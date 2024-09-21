namespace Fire_Emblem_Common;

public static class WeaponTriangle
{
    private static readonly Dictionary<string, (string advantage, string disadvantage)> WeaponTriangleDic = new Dictionary<string, (string, string)>
    {
        { "Sword", ("Axe", "Lance") },
        { "Lance", ("Sword", "Axe") },
        { "Axe", ("Lance", "Sword") },
        { "Magic", ("", "")},
        { "Bow", ("", "")}
    };

    public static double CalculateWtb(string attackerWeapon, string defenderWeapon)
    {
        var (advantage, disadvantage) = WeaponTriangleDic[attackerWeapon];
        
        // QUE PASA CON ESE 1.2 0.8 (Naming)
        return advantage == defenderWeapon ? 1.2 :
            disadvantage == defenderWeapon ? 0.8 : 1.0;
    }
    
}