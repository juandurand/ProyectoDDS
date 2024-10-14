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

        double advantageValue = 1.2;
        double noadvantageValue = 1.0;
        double disadvantageValue = 0.8;
        
        return advantage == defenderWeapon ? advantageValue :
            disadvantage == defenderWeapon ? disadvantageValue : noadvantageValue;
    }
    
}