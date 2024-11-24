using Fire_Emblem_Common.Enums;
namespace Fire_Emblem_Common;

public static class WeaponTriangle
{
    private static readonly Dictionary<WeaponType, (WeaponType advantage, WeaponType disadvantage)> WeaponTriangleDic = 
        new Dictionary<WeaponType, (WeaponType, WeaponType)>
    {
        { WeaponType.Sword, (WeaponType.Axe, WeaponType.Lance) },
        { WeaponType.Lance, (WeaponType.Sword, WeaponType.Axe) },
        { WeaponType.Axe, (WeaponType.Lance, WeaponType.Sword) },
        { WeaponType.Magic, (WeaponType.None, WeaponType.None) },
        { WeaponType.Bow, (WeaponType.None, WeaponType.None) }
    };

    public static double GetWtb(WeaponType attackerWeapon, WeaponType defenderWeapon)
    {
        var (advantage, disadvantage) = WeaponTriangleDic[attackerWeapon];

        double advantageValue = 1.2;
        double noAdvantageValue = 1.0;
        double disadvantageValue = 0.8;

        return advantage == defenderWeapon ? advantageValue :
            disadvantage == defenderWeapon ? disadvantageValue : noAdvantageValue;
    }
}