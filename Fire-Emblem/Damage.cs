using Fire_Emblem_View;
namespace Fire_Emblem;

public class Damage
{
    private View _view;

    public Damage(View view)
    {
        _view = view;
    }
    
    public void AnnounceWtb(Unit attacker, Unit defender)
    {
        double wtb = WeaponTriangle.CalculateWtb(attacker.Weapon, defender.Weapon);
        if (wtb == 1.0)
        {
            _view.WriteLine("Ninguna unidad tiene ventaja con respecto a la otra");
        }
        else if (wtb == 1.2)
        {
            _view.WriteLine($"{attacker.Name} ({attacker.Weapon}) tiene ventaja con respecto a {defender.Name} ({defender.Weapon})");
        }
        else
        {
            _view.WriteLine($"{defender.Name} ({defender.Weapon}) tiene ventaja con respecto a {attacker.Name} ({attacker.Weapon})");
        }
    }
    
    public int GetDamage(Unit attacker, Unit defender)
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
        if (damage < 0) damage = 0;
        return damage;
    }

    
}