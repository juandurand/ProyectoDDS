namespace Fire_Emblem_Common;

public class Unit
{
    public readonly string Name;
    public readonly string PersonalizedName;
    public readonly string Weapon;
    public readonly string Gender;
    public readonly string DeathQuote;
    
    public List<string> SkillsNames;
    public List<Skill> Skills = new List<Skill>();
    public Unit LastOpponent;
    
    public Hp Hp;
    
    public AtkStat Atk;
    public SpdStat Spd;
    public DefStat Def;
    public ResStat Res;

    public Unit(Dictionary<string, object> unitData)
    {
        PersonalizedName = (string)unitData["PersonalizedName"];
        Name = (string)unitData["Name"];
        Weapon = (string)unitData["Weapon"];
        Gender = (string)unitData["Gender"];
        DeathQuote = (string)unitData["DeathQuote"];
        LastOpponent = this;
        
        Hp = new Hp((int)unitData["HP"]);
        
        Atk = new AtkStat((int)unitData["Atk"]);
        Spd = new SpdStat((int)unitData["Spd"]);
        Def = new DefStat((int)unitData["Def"]);
        Res = new ResStat((int)unitData["Res"]);
        
        SkillsNames = (List<string>)unitData["Skills"];
        
        CreateSkills();
    }

    private void CreateSkills()
    {
        foreach (string skillName in SkillsNames)
        {
            Skill skill = SkillFactory.CreateSkill(skillName, this);
            Skills.Add(skill);
        }
    }
    
    public void ResetEffects()
    {
        Atk.ResetEffects();
        Spd.ResetEffects();
        Def.ResetEffects();
        Res.ResetEffects();
    }
    
    public int GetTotalAtk(string attackType)
    {
        return Atk.GetTotalStat(attackType);
    }

    public int GetTotalSpd()
    {
        return Spd.GetTotalStat(string.Empty); // No se necesita tipo de ataque para la velocidad
    }

    public int GetTotalDef(string attackType)
    {
        return Def.GetTotalStat(attackType);
    }

    public int GetTotalRes(string attackType)
    {
        return Res.GetTotalStat(attackType);
    }
}