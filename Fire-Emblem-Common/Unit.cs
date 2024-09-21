namespace Fire_Emblem_Common;

public class Unit
{
    public readonly string Name;
    public readonly string Weapon;
    public readonly string Gender;
    public readonly string DeathQuote;
    public readonly int Atk;
    public readonly int Spd;
    public readonly int Def;
    public readonly int Res;
    public int Hp;
    public int ActualHp;
    public List<string> Skills;
    public Unit LastOpponent;

    public int AtkBonus;
    public int SpdBonus;
    public int DefBonus;
    public int ResBonus;

    public int AtkPenalty;
    public int SpdPenalty;
    public int DefPenalty;
    public int ResPenalty;

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

        LastOpponent = null;
        ResetBonus();
        ResetPenalty();
    }

    public void ResetBonus()
    {
        AtkBonus = 0;
        SpdBonus = 0;
        DefBonus = 0;
        ResBonus = 0;
    }
    
    public void ResetPenalty()
    {
        AtkPenalty = 0;
        SpdPenalty = 0;
        DefPenalty = 0;
        ResPenalty = 0;
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

    public double GetHPPercentage()
    {
        return ActualHp / Hp;
    }

    public int GetTotalAtk()
    {
        return Atk + AtkBonus - AtkPenalty;
    }

    public int GetTotalSpd()
    {
        return Spd + SpdBonus - SpdPenalty;
    }

    public int GetTotalDef()
    {
        return Def + DefBonus - DefPenalty;
    }

    public int GetTotalRes()
    {
        return Res + ResBonus - ResPenalty;
    }
}