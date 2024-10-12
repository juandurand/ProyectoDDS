namespace Fire_Emblem_Common;

public class Unit
{
    public readonly string Name;
    public readonly string Weapon;
    public readonly string Gender;
    public readonly string DeathQuote;
    
    public List<Skill> Skills;
    public Unit ActualOpponent;
    public Unit LastOpponent;
    
    public Hp Hp;
    
    public UnitStat Atk;
    public UnitStat Spd;
    public UnitStat Def;
    public UnitStat Res;

    public UnitDamageInfo Damage;

    public Unit(Dictionary<string, object> unitData)
    {
        Name = (string)unitData["Name"];
        Weapon = (string)unitData["Weapon"];
        Gender = (string)unitData["Gender"];
        DeathQuote = (string)unitData["DeathQuote"];
        
        Hp = new Hp((int)unitData["HP"]);
        ActualOpponent = null;
        LastOpponent = null;
        
        Atk = new UnitStat((int)unitData["Atk"]);
        Spd = new UnitStat((int)unitData["Spd"]);
        Def = new UnitStat((int)unitData["Def"]);
        Res = new UnitStat((int)unitData["Res"]);
        Damage = new UnitDamageInfo();
        
        Skills = SkillFactory.GetSkills((List<string>)unitData["Skills"], this);
    }
    
    public void ResetEffects()
    {
        Atk.ResetEffects();
        Spd.ResetEffects();
        Def.ResetEffects();
        Res.ResetEffects();
        Damage.ResetEffects();
    }

    public int GetTotalStat(string stat, string attackType)
    {
        if (stat == "Atk") return GetTotalAtk(attackType);
        if (stat == "Spd") return GetTotalSpd();
        if (stat == "Res") return GetTotalRes(attackType);
        if (stat == "Def") return GetTotalDef(attackType);
        return Hp.ActualHpValue;
    }
    
    private int GetTotalAtk(string attackType)
    {
        return Atk.GetTotalStat(attackType);
    }

    private int GetTotalSpd()
    {
        return Spd.GetTotalStat(string.Empty); // No se necesita tipo de ataque para la velocidad
    }

    private int GetTotalDef(string attackType)
    {
        return Def.GetTotalStat(attackType);
    }

    private int GetTotalRes(string attackType)
    {
        return Res.GetTotalStat(attackType);
    }
}