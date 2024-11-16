using Fire_Emblem_Common.Conditions;
using Fire_Emblem_Common.Effects;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.ConditionEvaluators;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Exceptions;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Skills;

public static class SkillFactory
{
    public static SkillList GetSkills(StringList skillNames, Unit unit)
    {
        SkillList skills = new SkillList();
        foreach (string skillName in skillNames)
        {
            skills.Add(CreateSkill(skillName, unit));
        }
        return skills;
    }
    
    private static ISkill CreateSkill(string skillName, Unit unit)
    {
        ConditionList conditions = new ConditionList();
        EffectByUnitType effectsByUnitType = new EffectByUnitType();
        ConditionEvaluator conditionEvaluator;
        
        ConditionList secondConditions = new ConditionList();
        EffectByUnitType secondEffectsByUnitType = new EffectByUnitType();
        
        ConditionList thirdConditions = new ConditionList();
        EffectByUnitType thirdEffectsByUnitType = new EffectByUnitType();
        CompositeSkill compositeSkill = new CompositeSkill(new SkillComponentList());
        
        if (skillName == "HP +15")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPlusFifteenEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Fair Fight")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Both, new AtkBonusEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Will to Win")
        {
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Single-Minded")
        {
            conditions.Add(new LastOpponentCondition());
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Ignis")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(unit.Atk.BaseValue / 2, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Perceptive")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(12 + unit.Spd.BaseValue / 4));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Tome Precision")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Magic }))));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Attack +6")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Speed +5")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Defense +5")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Wrath")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new WrathEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Resolve")
        {
            conditions.Add(new HpPercentageCondition(0.75, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(7));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Resistance +5")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Atk/Def +5")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Atk/Res +5")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Spd/Res +5")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Deadly Blade")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Sword })));
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));

            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(8));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(8));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }

        else if (skillName == "Death Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Armored Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Darting Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Warding Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Swift Sparrow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Sturdy Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Mirror Strike")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Steady Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Swift Strike")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Bracing Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Brazen Atk/Spd")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Brazen Atk/Def")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Brazen Atk/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Brazen Spd/Def")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Brazen Spd/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Brazen Def/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Fire Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Wind Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Earth Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Water Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Chaos Style")
        {
            conditions.Add(new ChaosStyleCondition());
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(3));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Blinding Flash")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(4));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Not *Quite*")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(4));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Stunning Smile")
        {
            conditions.Add(new ManRivalCondition());
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Disarming Sigh")
        {
            conditions.Add(new ManRivalCondition());
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Charmer")
        {
            conditions.Add(new LastOpponentCondition());
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(3));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Luna")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPercentagePenaltyEffect(0.5, AttackType.FirstAttack));
            effectsByUnitType.AddEffect(UnitRole.Rival, new ResPercentagePenaltyEffect(0.5, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Belief in Love")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            conditions.Add(new HpPercentageCondition(1.0, UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPenaltyEffect(5));
            conditionEvaluator = new OrConditionEvaluator(conditions); 
        }
        
        else if (skillName == "Beorc's Blessing")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Agnea's Arrow")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new PenaltyNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Soulblade")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Sword })));
            effectsByUnitType.AddEffect(UnitRole.Rival, new AverageDefResEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Sandstorm")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new SandstormEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Sword Agility")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Sword })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(12));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkPenaltyEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Lance Power")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Lance })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefPenaltyEffect(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Sword Power")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Sword })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefPenaltyEffect(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Bow Focus")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Bow })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResPenaltyEffect(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Lance Agility")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Lance })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(12));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkPenaltyEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Axe Power")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Axe })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefPenaltyEffect(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Bow Agility")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Bow })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(12));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkPenaltyEffect(6));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Sword Focus")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Sword })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResPenaltyEffect(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Close Def")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Sword, WeaponType.Lance, WeaponType.Axe })));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(8));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(8));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }

        else if (skillName == "Distant Def")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Magic, WeaponType.Bow })));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(8));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(8));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }

        else if (skillName == "Lull Atk/Spd")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Spd })));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Lull Atk/Def")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPenaltyEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def })));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Lull Atk/Res")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Rival, new ResPenaltyEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Res })));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Lull Spd/Def")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPenaltyEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Spd, StatType.Def })));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Lull Spd/Res")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Rival, new ResPenaltyEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Spd, StatType.Res })));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Lull Def/Res")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPenaltyEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Rival, new ResPenaltyEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Def, StatType.Res })));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Fort. Def/Res")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkPenaltyEffect(2));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Life and Death")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResPenaltyEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Solid Ground")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResPenaltyEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Still Water")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefPenaltyEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Dragonskin")
        {
            conditions.Add(new HpPercentageCondition(0.75, UnitRole.Rival));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            conditionEvaluator = new OrConditionEvaluator(conditions); 
        }

        else if (skillName == "Light and Dark")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new ResPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new PenaltyNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Dragon Wall")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Res, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ComparisonPercentageReductionEffect(0.4, StatType.Res, StatType.Res, 4));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Dodge")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ComparisonPercentageReductionEffect(0.4, StatType.Spd, StatType.Spd, 4));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Golden Lotus")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Sword, WeaponType.Bow, WeaponType.Lance, WeaponType.Axe })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.5, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Gentility")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Bow Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Bow })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Arms Shield")
        {
            conditions.Add(new WeaponAdvantageCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(7));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Axe Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Axe })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Magic Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Magic })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Lance Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Lance })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Sympathetic")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }

        else if (skillName == "Back at You")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpecificExtraDamageEffect(UnitRole.Unit, StatType.Hp, 0.5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Lunar Brace")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Sword, WeaponType.Bow, WeaponType.Lance, WeaponType.Axe })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpecificExtraDamageEffect(UnitRole.Rival, StatType.Def, 0.3));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }
        
        else if (skillName == "Bravery")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantExtraDamageEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Bushido")
        {
           effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantExtraDamageEffect(7));
           compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier((effectsByUnitType)));
           
           secondConditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
           secondEffectsByUnitType.AddEffect(UnitRole.Unit, new ComparisonPercentageReductionEffect(0.4, StatType.Spd, StatType.Spd, 4));
           compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), new EffectApplier((secondEffectsByUnitType)));
           return compositeSkill;
        }
        
        else if (skillName == "Moon-Twin Wing")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(5));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier((effectsByUnitType)));
            
            secondConditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            secondConditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new ComparisonPercentageReductionEffect(0.4, StatType.Spd, StatType.Spd, 4));
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), new EffectApplier((secondEffectsByUnitType)));
            return compositeSkill;
        }
        
        else if (skillName == "Blue Skies")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantExtraDamageEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Aegis Shield")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(3));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.5, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Remote Sparrow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.3, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Remote Mirror")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.3, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Remote Sturdy")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.3, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Fierce Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(8));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Darting Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(8));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Steady Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(8));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Warding Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(8));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Kestrel Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Sturdy Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Mirror Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Steady Posture")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Swift Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Bracing Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.1, AttackType.FollowUp));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Poetic Justice")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpecificExtraDamageEffect(UnitRole.Rival, StatType.Atk, 0.15));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Laguz Friend")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new BonusNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Def, StatType.Res })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefPercentagePenaltyEffect(0.5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResPercentagePenaltyEffect(0.5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Chivalry")
        {
            conditions.Add(new HpPercentageCondition(1.0, UnitRole.Rival));
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantExtraDamageEffect(2));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(2));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }
        
        else if (skillName == "Dragon's Wrath")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.25, AttackType.FirstAttack));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new StatComparisonCondition(1, StatType.Atk, StatType.Res));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new SpecificExtraDamageEffect(UnitRole.Both, StatType.Atk, 0.25, StatType.Res, AttackType.FirstAttack));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Prescience")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new ResPenaltyEffect(5));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondConditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Magic, WeaponType.Bow })));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.3, AttackType.FirstAttack));
            compositeSkill.AddComponent(new OrConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Extra Chivalry")
        {
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPenaltyEffect(5));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new PercentageReductionByHpEffect(0.5));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Guard Bearing")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPenaltyEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Unit, new GuardBearingEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Divine Recreation")
        {
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPenaltyEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Rival, new ResPenaltyEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.3, AttackType.FirstAttack));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DivineRecreationEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Sol")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPercentageBonusOfDamageEffect(0.25));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Nosferatu")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Magic })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPercentageBonusOfDamageEffect(0.5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Solar Brace")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPercentageBonusOfDamageEffect(0.5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Windsweep")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Sword })));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Sword })));
            effectsByUnitType.AddEffect(UnitRole.Rival, new CounterAttackDenialEffect());
            conditionEvaluator = new AndConditionEvaluator(conditions);
        }
        
        else if (skillName == "Surprise Attack")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Bow })));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Bow })));
            effectsByUnitType.AddEffect(UnitRole.Rival, new CounterAttackDenialEffect());
            conditionEvaluator = new AndConditionEvaluator(conditions);
        }
        
        else if (skillName == "Hliðskjálf")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Magic })));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Magic })));
            effectsByUnitType.AddEffect(UnitRole.Rival, new CounterAttackDenialEffect());
            conditionEvaluator = new AndConditionEvaluator(conditions);
        }
        
        else if (skillName == "Null C-Disrupt") 
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new DenialOfCounterAttackDenialEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Laws of Sacae") 
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(6));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondConditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Sword, WeaponType.Lance, WeaponType.Axe })));
            secondConditions.Add(new StatComparisonCondition(5, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Rival, new CounterAttackDenialEffect());
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions),new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Eclipse Brace")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Sword, WeaponType.Lance, WeaponType.Axe, WeaponType.Bow })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpecificExtraDamageEffect(UnitRole.Rival, StatType.Def, 0.3));
            compositeSkill.AddComponent(new AndConditionEvaluator(conditions),new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new HpPercentageBonusOfDamageEffect(0.5));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions),new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Resonance")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Magic })));
            conditions.Add(new ConstantStatLeftCondition(2, StatType.Hp));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyBeforeCombatEffect(1));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantExtraDamageEffect(3));
            conditionEvaluator = new AndConditionEvaluator(conditions);
        }
        
        else if (skillName == "Flare")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Magic })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPercentageBonusOfDamageEffect(0.5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new ResPercentagePenaltyEffect(0.2));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Fury")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterCombatEffect(8));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Mystic Boost")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpBonusAfterCombatEffect(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }

        else if (skillName == "Atk/Spd Push")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterCombatIfAttackedEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Atk/Def Push")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterCombatIfAttackedEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Atk/Res Push")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterCombatIfAttackedEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Spd/Def Push")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterCombatIfAttackedEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Spd/Res Push")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterCombatIfAttackedEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Def/Res Push")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(7));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterCombatIfAttackedEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "True Dragon Wall")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Res, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ComparisonPercentageReductionEffect(0.6, StatType.Res, StatType.Res, 6, AttackType.FirstAttack));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ComparisonPercentageReductionEffect(0.4, StatType.Res, StatType.Res, 4, AttackType.FollowUp));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions),new EffectApplier(effectsByUnitType));

            secondConditions.Add(new TeamMatesWeaponTypeCondition(new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Magic })));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new HpBonusAfterCombatEffect(7));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions),new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Scendscale")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpecificExtraDamageEffect(UnitRole.Unit, StatType.Atk, 0.25));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterCombatIfAttackedEffect(7));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Mastermind")
        {
            conditions.Add(new ConstantStatLeftCondition(2, StatType.Hp));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyBeforeCombatEffect(1));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(9));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(9));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new MastermindEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Bewitching Tome")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Magic, WeaponType.Bow })));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BewitchingTomeEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new BonusFromPercentageOfOtherStatEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Spd }), StatType.Spd, 0.2));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.3, AttackType.FirstAttack));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpBonusAfterCombatEffect(7));
            conditionEvaluator = new OrConditionEvaluator(conditions);
        }
        
        else if (skillName == "Quick Riposte")
        {
            conditions.Add(new HpPercentageConditionInversed(0.6, UnitRole.Unit));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            conditionEvaluator = new AndConditionEvaluator(conditions);
        }
        
        else if (skillName == "Follow-Up Ring")
        {
            conditions.Add(new HpPercentageConditionInversed(0.5, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Wary Fighter")
        {
            conditions.Add(new HpPercentageConditionInversed(0.5, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialEffect());
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Piercing Tribute")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialOfGuaranteesEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Mjölnir")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Brash Assault")
        {
            conditions.Add(new HpPercentageCondition(0.99, UnitRole.Unit));
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondConditions.Add(new HpPercentageCondition(1, UnitRole.Rival));
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPenaltyEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Rival, new ResPenaltyEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.3, AttackType.FirstAttack));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new BrashAssaultEffect());
            conditionEvaluator = new ComplexConditionEvaluator(conditions, secondConditions);
        }
        
        else if (skillName == "Melee Breaker")
        {
            conditions.Add(new HpPercentageConditionInversed(0.5, UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Sword, WeaponType.Lance, WeaponType.Axe })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            conditionEvaluator = new AndConditionEvaluator(conditions);
        }
        
        else if (skillName == "Range Breaker")
        {
            conditions.Add(new HpPercentageConditionInversed(0.5, UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Bow, WeaponType.Magic })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            conditionEvaluator = new AndConditionEvaluator(conditions);
        }
        
        else if (skillName == "Pegasus Flight")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPenaltyEffect(4));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new BaseStatComparisonCondition(-10, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyFromBaseValueDifferenceEffect(StatType.Res, new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def }), 8, 0.8));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            
            thirdConditions.Add(new BaseStatComparisonCondition(-10, StatType.Spd, StatType.Spd));
            thirdConditions.Add(new DoubleStatComparisonCondition(1, StatType.Spd, StatType.Res, StatType.Spd, StatType.Res));
            thirdEffectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            compositeSkill.AddComponent(new AndConditionEvaluator(thirdConditions), new EffectApplier(thirdEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Wyvern Flight")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPenaltyEffect(4));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new BaseStatComparisonCondition(-10, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyFromBaseValueDifferenceEffect(StatType.Def, new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def }), 8, 0.8));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            
            thirdConditions.Add(new BaseStatComparisonCondition(-10, StatType.Spd, StatType.Spd));
            thirdConditions.Add(new DoubleStatComparisonCondition(1, StatType.Spd, StatType.Def, StatType.Spd, StatType.Def));
            thirdEffectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            compositeSkill.AddComponent(new AndConditionEvaluator(thirdConditions), new EffectApplier(thirdEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Null Follow-Up")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialOfGuaranteesEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Sturdy Impact")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Mirror Impact")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new AtkBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Swift Impact")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ResBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Steady Impact")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpdBonusEffect(6));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DefBonusEffect(10));
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Slick Fighter")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new PenaltyNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            conditionEvaluator = new AndConditionEvaluator(conditions);
        }
        
        else if (skillName == "Wily Fighter")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            conditionEvaluator = new AndConditionEvaluator(conditions);
        }
        
        else if (skillName == "Savvy Fighter")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialOfGuaranteesEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Rival));
            secondConditions.Add(new StatComparisonCondition(-4, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.3, AttackType.FirstAttack));
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Flow Force")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new PenaltyNeutralizationEffect(new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Spd })));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Flow Refresh")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpBonusAfterCombatEffect(10));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Flow Feather")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondConditions.Add(new StatComparisonCondition(-10, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new SpecificExtraDamageEffect(UnitRole.Both, StatType.Res, 0.7, StatType.Res, AttackType.None, 7));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new SpecificDamageReductionEffect(0.7, StatType.Res, StatType.Res, 7, 0));
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Flow Flight")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondConditions.Add(new StatComparisonCondition(-10, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new SpecificExtraDamageEffect(UnitRole.Both, StatType.Def, 0.7, StatType.Def, AttackType.None, 7));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new SpecificDamageReductionEffect(0.7, StatType.Def, StatType.Def, 7, 0));
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Binding Shield")
        {
            conditions.Add(new StatComparisonCondition(5, StatType.Spd, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondConditions.Add(new StatComparisonCondition(5, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Rival, new CounterAttackDenialEffect());
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Sun-Twin Wing")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialOfGuaranteesEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Dragon's Ire")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Rival, new ResPenaltyEffect(4));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            secondConditions.Add(new FirstAttackCondition(UnitRole.Rival));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Black Eagle Rule")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            secondConditions.Add(new FirstAttackCondition(UnitRole.Rival));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.8, AttackType.FollowUp));
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Blue Lion Rule")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Def, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ComparisonPercentageReductionEffect(0.4, StatType.Def, StatType.Def, 4));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Rival));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "New Divinity")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new ResPenaltyEffect(5));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            secondConditions.Add(new StatComparisonCondition(1, StatType.Res, StatType.Res));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new ComparisonPercentageReductionEffect(0.4, StatType.Res, StatType.Res, 4));
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), new EffectApplier(secondEffectsByUnitType));
            
            thirdConditions.Add(new HpPercentageConditionInversed(0.4, UnitRole.Unit));
            thirdEffectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(thirdConditions), new EffectApplier(thirdEffectsByUnitType));
            return compositeSkill;
        }

        else
        {
            throw new NotImplementedSkillException($"La skill {skillName} no está implementada.");
        }

        EffectApplier effectApplier = new EffectApplier(effectsByUnitType);
        Skill skill = new Skill(conditionEvaluator, effectApplier);
        return skill;
    }
}