namespace Fire_Emblem_Common;

public class Unit
{
    public readonly string Name;
    public readonly WeaponType Weapon;
    public readonly string Gender;
    public readonly string DeathQuote;
    
    public List<Skill> Skills;
    public Unit ActualOpponent;
    public Unit LastOpponent;
    
    public HealthStatus HealthStatus;
    
    public UnitStat Atk;
    public UnitStat Spd;
    public UnitStat Def;
    public UnitStat Res;

    public UnitDamageInfo Damage;

    public int FirstAttack;
    public int FirstDefense;
    public bool Attacking; // True si empieza atacando || False si empieza defendiendo

    public Unit(Dictionary<string, object> unitData)
    {
        Name = (string)unitData["Name"];
        Weapon = (WeaponType)Enum.Parse(typeof(WeaponType), (string)unitData["Weapon"]);
        Gender = (string)unitData["Gender"];
        DeathQuote = (string)unitData["DeathQuote"];
        
        HealthStatus = new HealthStatus((int)unitData["HP"]);
        ActualOpponent = null;
        LastOpponent = null;
        
        Atk = new UnitStat((int)unitData["Atk"]);
        Spd = new UnitStat((int)unitData["Spd"]);
        Def = new UnitStat((int)unitData["Def"]);
        Res = new UnitStat((int)unitData["Res"]);
        Damage = new UnitDamageInfo();
        
        Skills = SkillFactory.GetSkills((List<string>)unitData["Skills"], this);

        FirstAttack = 0;
        FirstDefense = 0;
    }
    
    public void ResetEffects()
    {
        Atk.ResetEffects();
        Spd.ResetEffects();
        Def.ResetEffects();
        Res.ResetEffects();
        Damage.ResetEffects();
    }

    public void SetFirstAttack()
    {
        if (FirstAttack == 0 || FirstAttack == 1)
        {
            FirstAttack += 1;
        }
    }
    
    public void SetFirstDefense()
    {
        if (FirstDefense == 0 || FirstDefense == 1)
        {
            FirstDefense += 1;
        }
    }

    public int GetTotalStat(StatType stat, AttackType attackType)
    {
        if (stat == StatType.Atk) return GetTotalAtk(attackType);
        if (stat == StatType.Spd) return GetTotalSpd(attackType);
        if (stat == StatType.Res) return GetTotalRes(attackType);
        if (stat == StatType.Def) return GetTotalDef(attackType);
        return HealthStatus.ActualHpValue;
    }
    
    private int GetTotalAtk(AttackType attackType)
    {
        return Atk.GetTotalStat(attackType);
    }

    private int GetTotalSpd(AttackType attackType)
    {
        return Spd.GetTotalStat(attackType); 
    }

    private int GetTotalDef(AttackType attackType)
    {
        return Def.GetTotalStat(attackType);
    }

    private int GetTotalRes(AttackType attackType)
    {
        return Res.GetTotalStat(attackType);
    }
}