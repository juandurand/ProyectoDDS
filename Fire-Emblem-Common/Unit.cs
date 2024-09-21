namespace Fire_Emblem_Common;

public class Unit
{
    public readonly string Name;
    public readonly string Weapon;
    public readonly string Gender;
    public readonly string DeathQuote;
    public readonly int Hp;
    public readonly int Atk;
    public readonly int Spd;
    public readonly int Def;
    public readonly int Res;
    public int ActualHp;
    public List<string> Skills;

    public Unit(Dictionary<string, object> unitData)
    {
        // SOBRECARGAR CONSTRUCTOR?
        Name = (string)unitData["Name"];
        Weapon = (string)unitData["Weapon"];
        Gender = (string)unitData["Gender"];
        DeathQuote = (string)unitData["DeathQuote"];
        Hp = (int)unitData["HP"];
        Atk = (int)unitData["Atk"];
        Spd = (int)unitData["Spd"];
        Def = (int)unitData["Def"];
        Res = (int)unitData["Res"];
        ActualHp = (int)unitData["HP"];
        Skills = (List<string>)unitData["Skills"];
    }

    public bool IsUnitAlive()
    {
        return ActualHp > 0;
    }

    public void DealDamage(int damage)
    {
        ActualHp -= damage;
        if (ActualHp < 0)
        {
            ActualHp = 0;
        }
    }
    
    
}