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
    
    public Stat Atk;
    public Stat Spd;
    public Stat Def;
    public Stat Res;

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
        
        Atk = new Stat((int)unitData["Atk"]);
        Spd = new Stat((int)unitData["Spd"]);
        Def = new Stat((int)unitData["Def"]);
        Res = new Stat((int)unitData["Res"]);
        Damage = new UnitDamageInfo();
        
        Skills = SkillFactory.GetSkills((List<string>)unitData["Skills"], this);

        FirstAttack = 0;
        FirstDefense = 0;
    }
}