using Fire_Emblem_Common.Conditions;
using Fire_Emblem_Common.Effects;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.ConditionEvaluators;
using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem_Common.Skills;

public static class SkillFactory
{
    public static List<Skill> GetSkills(StringList skillNames, Unit unit)
    {
        List<Skill> skills = new List<Skill>();
        foreach (string skillName in skillNames)
        {
            skills.Add(CreateSkill(skillName, unit));
            
            SpecialSkill? specialSkill = SpecialSkillMapper.FromString(skillName);
            if (specialSkill != null)
            {
                skills.Add(CreateSpecialSkill(skillName , unit));
            }
        }
        return skills;
    }
    private static Skill CreateSkill(string skillName, Unit unit)
    {
        List<Condition> conditions = new List<Condition>();
        Dictionary<UnitRole, List<Effectt>> effectsByUnitType = new Dictionary<UnitRole, List<Effectt>>()
        {
            { UnitRole.Unit, new List<Effectt>() },
            { UnitRole.Rival, new List<Effectt>() },
            { UnitRole.Both, new List<Effectt>() }
        };
        
        ConditionEvaluator conditionEvaluator;
        
        if (skillName == "HP +15")
        {
            effectsByUnitType[UnitRole.Unit].Add(new HpPlusFifteenEffectt());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Fair Fight")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Both].Add(new AtkBonusEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Will to Win")
        {
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Single-Minded")
        {
            conditions.Add(new LastOpponentCondition());
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Ignis")
        {
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(unit.Atk.BaseValue / 2, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Perceptive")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(12 + unit.Spd.BaseValue / 4));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Tome Precision")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Magic }));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Attack +6")
        {
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Speed +5")
        {
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Defense +5")
        {
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Wrath")
        {
            effectsByUnitType[UnitRole.Unit].Add(new WrathEffectt());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Resolve")
        {
            conditions.Add(new HpPercentageCondition(0.75, UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(7));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(7));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Resistance +5")
        {
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Atk/Def +5")
        {
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(5));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Atk/Res +5")
        {
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(5));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Spd/Res +5")
        {
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(5));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Deadly Blade")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Sword }));
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));

            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(8));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(8));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }

        else if (skillName == "Death Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Armored Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Darting Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Warding Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Swift Sparrow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Sturdy Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Mirror Strike")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Steady Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Swift Strike")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Bracing Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Brazen Atk/Spd")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(10));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Brazen Atk/Def")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(10));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Brazen Atk/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(10));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Brazen Spd/Def")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(10));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Brazen Spd/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(10));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Brazen Def/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(10));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Fire Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Wind Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Earth Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Water Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Chaos Style")
        {
            conditions.Add(new ChaosStyleCondition());
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(3));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Blinding Flash")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Rival].Add(new SpdPenaltyEffectt(4));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Not *Quite*")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Rival].Add(new AtkPenaltyEffectt(4));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Stunning Smile")
        {
            conditions.Add(new ManRivalCondition());
            effectsByUnitType[UnitRole.Rival].Add(new SpdPenaltyEffectt(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Disarming Sigh")
        {
            conditions.Add(new ManRivalCondition());
            effectsByUnitType[UnitRole.Rival].Add(new AtkPenaltyEffectt(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Charmer")
        {
            conditions.Add(new LastOpponentCondition());
            effectsByUnitType[UnitRole.Rival].Add(new AtkPenaltyEffectt(3));
            effectsByUnitType[UnitRole.Rival].Add(new SpdPenaltyEffectt(3));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Luna")
        {
            effectsByUnitType[UnitRole.Rival].Add(new DefPercentagePenaltyEffectt(0.5, AttackType.FirstAttack));
            effectsByUnitType[UnitRole.Rival].Add(new ResPercentagePenaltyEffectt(0.5, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Belief in Love")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            conditions.Add(new HpPercentageCondition(1.0, UnitRole.Rival));
            effectsByUnitType[UnitRole.Rival].Add(new AtkPenaltyEffectt(5));
            effectsByUnitType[UnitRole.Rival].Add(new DefPenaltyEffectt(5));
            conditionEvaluator = new OrConditionEvaluator(conditions); 
        }
        
        else if (skillName == "Beorc's Blessing")
        {
            effectsByUnitType[UnitRole.Rival].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Agnea's Arrow")
        {
            effectsByUnitType[UnitRole.Unit].Add(new PenaltyNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Soulblade")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Sword }));
            effectsByUnitType[UnitRole.Rival].Add(new AverageDefResEffectt());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Sandstorm")
        {
            effectsByUnitType[UnitRole.Unit].Add(new SandstormEffectt());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Sword Agility")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Sword }));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(12));
            effectsByUnitType[UnitRole.Unit].Add(new AtkPenaltyEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Lance Power")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Lance }));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(10));
            effectsByUnitType[UnitRole.Unit].Add(new DefPenaltyEffectt(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Sword Power")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Sword }));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(10));
            effectsByUnitType[UnitRole.Unit].Add(new DefPenaltyEffectt(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Bow Focus")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Bow }));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(10));
            effectsByUnitType[UnitRole.Unit].Add(new ResPenaltyEffectt(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Lance Agility")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Lance }));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(12));
            effectsByUnitType[UnitRole.Unit].Add(new AtkPenaltyEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Axe Power")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Axe }));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(10));
            effectsByUnitType[UnitRole.Unit].Add(new DefPenaltyEffectt(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Bow Agility")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Bow }));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(12));
            effectsByUnitType[UnitRole.Unit].Add(new AtkPenaltyEffectt(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Sword Focus")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Sword }));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(10));
            effectsByUnitType[UnitRole.Unit].Add(new ResPenaltyEffectt(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Close Def")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Sword, WeaponType.Lance, WeaponType.Axe }));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(8));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(8));
            effectsByUnitType[UnitRole.Rival].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }

        else if (skillName == "Distant Def")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Magic, WeaponType.Bow }));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(8));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(8));
            effectsByUnitType[UnitRole.Rival].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }

        else if (skillName == "Lull Atk/Spd")
        {
            effectsByUnitType[UnitRole.Rival].Add(new AtkPenaltyEffectt(3));
            effectsByUnitType[UnitRole.Rival].Add(new SpdPenaltyEffectt(3));
            effectsByUnitType[UnitRole.Rival].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Spd }));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Lull Atk/Def")
        {
            effectsByUnitType[UnitRole.Rival].Add(new AtkPenaltyEffectt(3));
            effectsByUnitType[UnitRole.Rival].Add(new DefPenaltyEffectt(3));
            effectsByUnitType[UnitRole.Rival].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def }));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Lull Atk/Res")
        {
            effectsByUnitType[UnitRole.Rival].Add(new AtkPenaltyEffectt(3));
            effectsByUnitType[UnitRole.Rival].Add(new ResPenaltyEffectt(3));
            effectsByUnitType[UnitRole.Rival].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Res }));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Lull Spd/Def")
        {
            effectsByUnitType[UnitRole.Rival].Add(new SpdPenaltyEffectt(3));
            effectsByUnitType[UnitRole.Rival].Add(new DefPenaltyEffectt(3));
            effectsByUnitType[UnitRole.Rival].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Spd, StatType.Def }));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Lull Spd/Res")
        {
            effectsByUnitType[UnitRole.Rival].Add(new SpdPenaltyEffectt(3));
            effectsByUnitType[UnitRole.Rival].Add(new ResPenaltyEffectt(3));
            effectsByUnitType[UnitRole.Rival].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Spd, StatType.Res }));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Lull Def/Res")
        {
            effectsByUnitType[UnitRole.Rival].Add(new DefPenaltyEffectt(3));
            effectsByUnitType[UnitRole.Rival].Add(new ResPenaltyEffectt(3));
            effectsByUnitType[UnitRole.Rival].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Def, StatType.Res }));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Fort. Def/Res")
        {
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new AtkPenaltyEffectt(2));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Life and Death")
        {
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new DefPenaltyEffectt(5));
            effectsByUnitType[UnitRole.Unit].Add(new ResPenaltyEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Solid Ground")
        {
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ResPenaltyEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Still Water")
        {
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new DefPenaltyEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Dragonskin")
        {
            conditions.Add(new HpPercentageCondition(0.75, UnitRole.Rival));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(6));
            effectsByUnitType[UnitRole.Rival].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));
            conditionEvaluator = new OrConditionEvaluator(conditions); 
        }

        else if (skillName == "Light and Dark")
        {
            effectsByUnitType[UnitRole.Rival].Add(new DefPenaltyEffectt(5));
            effectsByUnitType[UnitRole.Rival].Add(new ResPenaltyEffectt(5));
            effectsByUnitType[UnitRole.Rival].Add(new AtkPenaltyEffectt(5));
            effectsByUnitType[UnitRole.Rival].Add(new SpdPenaltyEffectt(5));
            effectsByUnitType[UnitRole.Rival].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));
            effectsByUnitType[UnitRole.Unit].Add(new PenaltyNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Dragon Wall")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Res, StatType.Res));
            effectsByUnitType[UnitRole.Unit].Add(new ComparisonPercentageReductionEffectt(0.4, StatType.Res, StatType.Res, 4));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Dodge")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
            effectsByUnitType[UnitRole.Unit].Add(new ComparisonPercentageReductionEffectt(0.4, StatType.Spd, StatType.Spd, 4));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Golden Lotus")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Sword, WeaponType.Bow, WeaponType.Lance, WeaponType.Axe }));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.5, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Gentility")
        {
            effectsByUnitType[UnitRole.Unit].Add(new DamageReductionEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Bow Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Bow }));
            effectsByUnitType[UnitRole.Unit].Add(new DamageReductionEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Arms Shield")
        {
            conditions.Add(new WeaponAdvantageCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new DamageReductionEffectt(7));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Axe Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Axe }));
            effectsByUnitType[UnitRole.Unit].Add(new DamageReductionEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Magic Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Magic }));
            effectsByUnitType[UnitRole.Unit].Add(new DamageReductionEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Lance Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Lance }));
            effectsByUnitType[UnitRole.Unit].Add(new DamageReductionEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Sympathetic")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new DamageReductionEffectt(5));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }

        else if (skillName == "Back at You")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new SpecificExtraDamageEffect(UnitRole.Unit, StatType.Hp, 0.5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Lunar Brace")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Sword, WeaponType.Bow, WeaponType.Lance, WeaponType.Axe }));
            effectsByUnitType[UnitRole.Unit].Add(new SpecificExtraDamageEffect(UnitRole.Rival, StatType.Def, 0.3));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }
        
        else if (skillName == "Bravery")
        {
            effectsByUnitType[UnitRole.Unit].Add(new ConstantExtraDamageEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Bushido")
        {
           effectsByUnitType[UnitRole.Unit].Add(new ConstantExtraDamageEffectt(7));
           conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Moon-Twin Wing")
        {
            conditions.Add(new HpPercentageCondition(-0.25, UnitRole.Unit)); // El menor igual al reves por eso el menos
            effectsByUnitType[UnitRole.Rival].Add(new AtkPenaltyEffectt(5));
            effectsByUnitType[UnitRole.Rival].Add(new SpdPenaltyEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Blue Skies")
        {
            effectsByUnitType[UnitRole.Unit].Add(new DamageReductionEffectt(5));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantExtraDamageEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Aegis Shield")
        {
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(3));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.5, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Remote Sparrow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(7));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(7));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.3, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Remote Mirror")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(7));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(10));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.3, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Remote Sturdy")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(7));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(10));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.3, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Fierce Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(8));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Darting Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(8));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Steady Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(8));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Warding Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(8));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Kestrel Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Sturdy Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Mirror Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new AtkBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Steady Posture")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Swift Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new SpdBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Bracing Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType[UnitRole.Unit].Add(new DefBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ResBonusEffectt(6));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Poetic Justice")
        {
            effectsByUnitType[UnitRole.Rival].Add(new SpdPenaltyEffectt(4));
            effectsByUnitType[UnitRole.Unit].Add(new SpecificExtraDamageEffect(UnitRole.Rival, StatType.Atk, 0.15));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Laguz Friend")
        {
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.5));
            effectsByUnitType[UnitRole.Unit].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Def, StatType.Res }));
            effectsByUnitType[UnitRole.Unit].Add(new DefPercentagePenaltyEffectt(0.5));
            effectsByUnitType[UnitRole.Unit].Add(new ResPercentagePenaltyEffectt(0.5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Chivalry")
        {
            conditions.Add(new HpPercentageCondition(1.0, UnitRole.Rival));
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantExtraDamageEffectt(2));
            effectsByUnitType[UnitRole.Unit].Add(new DamageReductionEffectt(2));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }
        
        else if (skillName == "Dragon's Wrath")
        {
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.25, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Prescience")
        {
            effectsByUnitType[UnitRole.Rival].Add(new AtkPenaltyEffectt(5));
            effectsByUnitType[UnitRole.Rival].Add(new ResPenaltyEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Extra Chivalry")
        {
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Rival));
            effectsByUnitType[UnitRole.Rival].Add(new AtkPenaltyEffectt(5));
            effectsByUnitType[UnitRole.Rival].Add(new SpdPenaltyEffectt(5));
            effectsByUnitType[UnitRole.Rival].Add(new DefPenaltyEffectt(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Guard Bearing")
        {
            effectsByUnitType[UnitRole.Rival].Add(new SpdPenaltyEffectt(4));
            effectsByUnitType[UnitRole.Rival].Add(new DefPenaltyEffectt(4));
            effectsByUnitType[UnitRole.Unit].Add(new GuardBearingEffectt());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Divine Recreation")
        {
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Rival));
            effectsByUnitType[UnitRole.Rival].Add(new AtkPenaltyEffectt(4));
            effectsByUnitType[UnitRole.Rival].Add(new SpdPenaltyEffectt(4));
            effectsByUnitType[UnitRole.Rival].Add(new DefPenaltyEffectt(4));
            effectsByUnitType[UnitRole.Rival].Add(new ResPenaltyEffectt(4));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.3, AttackType.FirstAttack));
            effectsByUnitType[UnitRole.Unit].Add(new DivineRecreationEffectt());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else
        {
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        EffectApplier effectApplier = new EffectApplier(effectsByUnitType);
        
        Skill skill = new Skill(conditionEvaluator, effectApplier);
        return skill;
    }

    private static Skill CreateSpecialSkill(string skillName, Unit unit)
    {
        List<Condition> conditions = new List<Condition>();
        Dictionary<UnitRole, List<Effectt>> effectsByUnitType = new Dictionary<UnitRole, List<Effectt>>()
        {
            { UnitRole.Unit, new List<Effectt>() },
            { UnitRole.Rival, new List<Effectt>() },
            { UnitRole.Both, new List<Effectt>() }
        };
        
        ConditionEvaluator conditionEvaluator;
        
        if (skillName == "Bushido")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
            effectsByUnitType[UnitRole.Unit].Add(new ComparisonPercentageReductionEffectt(0.4, StatType.Spd, StatType.Spd, 4));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Moon-Twin Wing")
        {
            conditions.Add(new HpPercentageCondition(-0.25, UnitRole.Unit)); // El menor igual al reves por eso el menos
            conditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
            effectsByUnitType[UnitRole.Unit].Add(new ComparisonPercentageReductionEffectt(0.4, StatType.Spd, StatType.Spd, 4));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }
        
        else if (skillName == "Dragon's Wrath")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Atk, StatType.Res));
            effectsByUnitType[UnitRole.Unit].Add(new SpecificExtraDamageEffect(UnitRole.Both, StatType.Atk, 0.25, StatType.Res, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Prescience")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Magic, WeaponType.Bow }));
            effectsByUnitType[UnitRole.Unit].Add(new ConstantPercentageReductionEffectt(0.3, AttackType.FirstAttack));
            conditionEvaluator = new OrConditionEvaluator(conditions); 
        }
        
        else if (skillName == "Extra Chivalry")
        {
            effectsByUnitType[UnitRole.Unit].Add(new PercentageReductionByHpEffectt(0.5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else
        {
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        
        EffectApplier effectApplier = new EffectApplier(effectsByUnitType);
        
        Skill skill = new Skill(conditionEvaluator, effectApplier);
        return skill;
    }
}