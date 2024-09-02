namespace Fire_Emblem;

public class Unit
{
    public string Name;
    public string Weapon;
    public string Gender;
    public string DeathQuote;
    public int Hp;
    public int Atk;
    public int Spd;
    public int Def;
    public int Res;
    public int ActualHp;
    public List<string> Skills;

    public Unit(Dictionary<string, object> unitData)
    {
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