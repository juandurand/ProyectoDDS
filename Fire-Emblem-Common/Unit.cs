using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Damage;
using Fire_Emblem_Common.Skills;
using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem_Common;

public class Unit
{
    public readonly string Name;
    public readonly WeaponType Weapon;
    public readonly string Gender;
    public readonly string DeathQuote;
    
    public readonly SkillList Skills;
    
    public readonly HealthStatus HealthStatus;
    public readonly Stat Atk;
    public readonly Stat Spd;
    public readonly Stat Def;
    public readonly Stat Res;
    public readonly DamageEffects DamageEffects;

    public Unit ActualOpponent;
    public Unit LastOpponent;
    public FirstAttack FirstAttack;
    public FirstDefense FirstDefense;
    public bool Attacking;

    public Unit(UnitData unitData)
    {
        Name = unitData.GetString(UnitDataKey.Name);
        Weapon = unitData.GetEnum<WeaponType>(UnitDataKey.Weapon);
        Gender = unitData.GetString(UnitDataKey.Gender);
        DeathQuote = unitData.GetString(UnitDataKey.DeathQuote);
        
        HealthStatus = new HealthStatus(unitData.GetInt(UnitDataKey.Hp));
        Atk = new Stat(unitData.GetInt(UnitDataKey.Atk));
        Spd = new Stat(unitData.GetInt(UnitDataKey.Spd));
        Def = new Stat(unitData.GetInt(UnitDataKey.Def));
        Res = new Stat(unitData.GetInt(UnitDataKey.Res));
        DamageEffects = new DamageEffects();
        
        Skills = SkillFactory.GetSkills(unitData.GetStringList(UnitDataKey.Skills), this);

        ActualOpponent = this;
        LastOpponent = this;
        FirstAttack = FirstAttack.HaveNotFirstAttacked;
        FirstDefense = FirstDefense.HaveNotFirstDefended;
        Attacking = false;
    }
}