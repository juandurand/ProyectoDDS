using Fire_Emblem_View;

namespace Fire_Emblem;

public class WeaponTriangle
{
    private static readonly Dictionary<string, (string advantage, string disadvantage)> WeaponTriangleDic = new Dictionary<string, (string, string)>
    {
        { "Sword", ("Axe", "Lance") },
        { "Lance", ("Sword", "Axe") },
        { "Axe", ("Lance", "Sword") },
        { "Magic", ("", "")},
        { "Bow", ("", "")}
    };

    private readonly View _view;
    public WeaponTriangle(View view)
    {
        _view = view;
    }

    public static double CalculateWtb(string attackerWeapon, string defenderWeapon)
    {
        var (advantage, disadvantage) = WeaponTriangleDic[attackerWeapon];
        
        // QUE PASA CON ESE 1.2 0.8 (Naming)
        return advantage == defenderWeapon ? 1.2 :
            disadvantage == defenderWeapon ? 0.8 : 1.0;
    }
    
    public void AnnounceWtb(Unit attacker, Unit defender)
    {
        double wtb = CalculateWtb(attacker.Weapon, defender.Weapon);
        const double epsilon = 0.0001;
        
        if (Math.Abs(wtb - 1.0) < epsilon)
        {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
        
        else if (Math.Abs(wtb - 1.2) < epsilon)
        {
            _view.WriteLine($"{attacker.Name} ({attacker.Weapon}) tiene ventaja con respecto a {defender.Name} ({defender.Weapon})");
        }
        
        else
        {
            _view.WriteLine($"{defender.Name} ({defender.Weapon}) tiene ventaja con respecto a {attacker.Name} ({attacker.Weapon})");
        }
    }
}