namespace Fire_Emblem;
using System.Text.Json.Serialization;

public class Unit
{
    public string Name;
    public string Weapon;
    public string Gender;
    public string DeathQuote;
    public int HP;
    public int Atk;
    public int Spd;
    public int Def;
    public int Res;
    public int ActualHP;
    public List<string> Skills;

    public Unit(Dictionary<string, object> unitData)
    {
        Name = (string)unitData["Name"];
        Weapon = (string)unitData["Weapon"];
        Gender = (string)unitData["Gender"];
        DeathQuote = (string)unitData["DeathQuote"];
        HP = (int)unitData["HP"];
        Atk = (int)unitData["Atk"];
        Spd = (int)unitData["Spd"];
        Def = (int)unitData["Def"];
        Res = (int)unitData["Res"];
        ActualHP = (int)unitData["HP"];
        Skills = (List<string>)unitData["Skills"];
    }

    public bool IsUnitAlive()
    {
        if (ActualHP < 0)
        {
            ActualHP = 0;
        }
        return ActualHP > 0;
    }

    public void DealDamage(int damage)
    {
        ActualHP -= damage;
    }
    
    
}