using Fire_Emblem_Common.Conditions;
using Fire_Emblem_Common.Effects;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.ConditionEvaluators;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Exceptions;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Skills;

public static class SkillFactory
{
    public static SkillList GetSkills(StringList skillNames, Unit unit)
    {
        SkillList skills = new SkillList();
        foreach (string skillName in skillNames)
        {
            skills.AddSkill(CreateSkill(skillName, unit));
        }
        return skills;
    }
    
    private static ISkill CreateSkill(string skillName, Unit unit)
    {
        ConditionEvaluatorType conditionEvaluatorType = ConditionEvaluatorType.Default;
        
        ConditionList conditions = new ConditionList();
        EffectByUnitType effectsByUnitType = new EffectByUnitType();
        
        ConditionList secondConditions = new ConditionList();
        EffectByUnitType secondEffectsByUnitType = new EffectByUnitType();
        
        ConditionList thirdConditions = new ConditionList();
        EffectByUnitType thirdEffectsByUnitType = new EffectByUnitType();
        
        CompositeSkill compositeSkill = new CompositeSkill(new SkillComponentList());
        
        if (skillName == "HP +15")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpBaseValuePlusConstantEffect(15));
        }

        else if (skillName == "Fair Fight")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Both, new StatBonusEffect(6, StatType.Atk));
        }

        else if (skillName == "Will to Win")
        {
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Atk));
        }

        else if (skillName == "Single-Minded")
        {
            conditions.Add(new LastOpponentCondition());
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Atk));
        }

        else if (skillName == "Ignis")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(unit.Atk.BaseValue / 2, StatType.Atk, 
                AttackType.FirstAttack));
        }

        else if (skillName == "Perceptive")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(12 + unit.Spd.BaseValue / 4, StatType.Spd));
        }

        else if (skillName == "Tome Precision")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Magic }))));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
        }

        else if (skillName == "Attack +6")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
        }

        else if (skillName == "Speed +5")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(5, StatType.Spd));
        }

        else if (skillName == "Defense +5")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(5, StatType.Def));
        }

        else if (skillName == "Wrath")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new WrathEffect());
        }

        else if (skillName == "Resolve")
        {
            conditions.Add(new HpPercentageCondition(0.75, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Res));
        }

        else if (skillName == "Resistance +5")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(5, StatType.Res));
        }

        else if (skillName == "Atk/Def +5")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(5, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(5, StatType.Def));
        }

        else if (skillName == "Atk/Res +5")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(5, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(5, StatType.Res));
        }

        else if (skillName == "Spd/Res +5")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(5, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(5, StatType.Res));
        }
        
        else if (skillName == "Deadly Blade")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Sword })));
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Atk));
            conditionEvaluatorType = ConditionEvaluatorType.And;
        }

        else if (skillName == "Death Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Atk));
        }

        else if (skillName == "Armored Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Def));
        }

        else if (skillName == "Darting Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Spd));
        }

        else if (skillName == "Warding Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Res));
        }

        else if (skillName == "Swift Sparrow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Spd));
        }

        else if (skillName == "Sturdy Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Def));
        }

        else if (skillName == "Mirror Strike")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Res));
        }

        else if (skillName == "Steady Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Spd));
        }

        else if (skillName == "Swift Strike")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Spd));
        }

        else if (skillName == "Bracing Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Def));
        }

        else if (skillName == "Brazen Atk/Spd")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Spd));
        }

        else if (skillName == "Brazen Atk/Def")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Def));
        }

        else if (skillName == "Brazen Atk/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Res));
        }

        else if (skillName == "Brazen Spd/Def")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Def));
        }

        else if (skillName == "Brazen Spd/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Res));
        }

        else if (skillName == "Brazen Def/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Res));
        }
        
        else if (skillName == "Fire Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
        }
        
        else if (skillName == "Wind Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Spd));
        }
        
        else if (skillName == "Earth Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Def));
        }
        
        else if (skillName == "Water Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Res));
        }
        
        else if (skillName == "Chaos Style")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new ChaosStyleCondition());
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(3, StatType.Spd));
            conditionEvaluatorType = ConditionEvaluatorType.And;
        }
        
        else if (skillName == "Blinding Flash")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Spd));
        }
        
        else if (skillName == "Not *Quite*")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Atk));
        }
        
        else if (skillName == "Stunning Smile")
        {
            conditions.Add(new ManRivalCondition());
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(8, StatType.Spd));
        }
        
        else if (skillName == "Disarming Sigh")
        {
            conditions.Add(new ManRivalCondition());
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(8, StatType.Atk));
        }

        else if (skillName == "Charmer")
        {
            conditions.Add(new LastOpponentCondition());
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Spd));
        }
        
        else if (skillName == "Luna")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyByPercentageOfBaseValueEffect(0.5, 
                StatType.Def, AttackType.FirstAttack));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyByPercentageOfBaseValueEffect(0.5, 
                StatType.Res, AttackType.FirstAttack));
        }
        
        else if (skillName == "Belief in Love")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            conditions.Add(new HpPercentageCondition(1.0, UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Def));
            conditionEvaluatorType = ConditionEvaluatorType.Or; 
        }
        
        else if (skillName == "Beorc's Blessing")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
        }
        
        else if (skillName == "Agnea's Arrow")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new PenaltyNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
        }
        
        else if (skillName == "Soulblade")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Sword })));
            effectsByUnitType.AddEffect(UnitRole.Rival, new AverageDefResEffect());
        }
        
        else if (skillName == "Sandstorm")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new SandstormEffect());
        }
        
        else if (skillName == "Sword Agility")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Sword })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(12, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyEffect(6, StatType.Atk));
        }
        
        else if (skillName == "Lance Power")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Lance })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyEffect(10, StatType.Def));
        }
        
        else if (skillName == "Sword Power")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Sword })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyEffect(10, StatType.Def));
        }
        
        else if (skillName == "Bow Focus")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Bow })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyEffect(10, StatType.Res));
        }

        else if (skillName == "Lance Agility")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Lance })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(12, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyEffect(6, StatType.Atk));
        }

        else if (skillName == "Axe Power")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Axe })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyEffect(10, StatType.Def));
        }

        else if (skillName == "Bow Agility")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Bow })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(12, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyEffect(6, StatType.Atk));
        }

        else if (skillName == "Sword Focus")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Sword })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyEffect(10, StatType.Res));
        }

        else if (skillName == "Close Def")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Sword, WeaponType.Lance, WeaponType.Axe })));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            conditionEvaluatorType = ConditionEvaluatorType.And; 
        }

        else if (skillName == "Distant Def")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Magic, WeaponType.Bow })));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            conditionEvaluatorType = ConditionEvaluatorType.And; 
        }

        else if (skillName == "Lull Atk/Spd")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Atk, StatType.Spd })));
        }

        else if (skillName == "Lull Atk/Def")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Atk, StatType.Def })));
        }

        else if (skillName == "Lull Atk/Res")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Atk, StatType.Res })));
        }

        else if (skillName == "Lull Spd/Def")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Spd, StatType.Def })));
        }

        else if (skillName == "Lull Spd/Res")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Spd, StatType.Res })));
        }

        else if (skillName == "Lull Def/Res")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(3, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Def, StatType.Res })));
        }

        else if (skillName == "Fort. Def/Res")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyEffect(2, StatType.Atk));
        }

        else if (skillName == "Life and Death")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyEffect(5, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyEffect(5, StatType.Res));
        }

        else if (skillName == "Solid Ground")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyEffect(5, StatType.Res));
        }

        else if (skillName == "Still Water")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyEffect(5, StatType.Def));
        }

        else if (skillName == "Dragonskin")
        {
            conditions.Add(new HpPercentageCondition(0.75, UnitRole.Rival));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            conditionEvaluatorType = ConditionEvaluatorType.Or; 
        }

        else if (skillName == "Light and Dark")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new PenaltyNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
        }

        else if (skillName == "Dragon Wall")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Res, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByStatComparisonEffect(
                0.4, StatType.Res, StatType.Res, 4));
        }
        
        else if (skillName == "Dodge")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByStatComparisonEffect(
                0.4, StatType.Spd, StatType.Spd, 4));
        }
        
        else if (skillName == "Golden Lotus")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Sword, WeaponType.Bow, WeaponType.Lance, WeaponType.Axe })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.5, AttackType.FirstAttack));
        }
        
        else if (skillName == "Gentility")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
        }
        
        else if (skillName == "Bow Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Bow })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
        }
        
        else if (skillName == "Arms Shield")
        {
            conditions.Add(new WeaponAdvantageCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(7));
        }
        
        else if (skillName == "Axe Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Axe })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
        }
        
        else if (skillName == "Magic Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Magic })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
        }
        
        else if (skillName == "Lance Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Lance })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
        }
        
        else if (skillName == "Sympathetic")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
            conditionEvaluatorType = ConditionEvaluatorType.And; 
        }

        else if (skillName == "Back at You")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageExtraBySpecificEffect(
                UnitRole.Unit, StatType.Hp, 0.5));
        }
        
        else if (skillName == "Lunar Brace")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Sword, WeaponType.Bow, WeaponType.Lance, WeaponType.Axe })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageExtraBySpecificEffect(
                UnitRole.Rival, StatType.Def, 0.3));
            conditionEvaluatorType = ConditionEvaluatorType.And;
        }
        
        else if (skillName == "Bravery")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageExtraByConstantEffect(5));
        }

        else if (skillName == "Bushido")
        {
           effectsByUnitType.AddEffect(UnitRole.Unit, new DamageExtraByConstantEffect(7));
           compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                       new EffectApplier((effectsByUnitType)));
           
           secondConditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
           secondEffectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByStatComparisonEffect(
               0.4, StatType.Spd, StatType.Spd, 4));
           compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), 
                                       new EffectApplier((secondEffectsByUnitType)));
           return compositeSkill;
        }
        
        else if (skillName == "Moon-Twin Wing")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Spd));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier((effectsByUnitType)));
            
            secondConditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            secondConditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByStatComparisonEffect(
                0.4, StatType.Spd, StatType.Spd, 4));
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), 
                                        new EffectApplier((secondEffectsByUnitType)));
            return compositeSkill;
        }
        
        else if (skillName == "Blue Skies")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageExtraByConstantEffect(5));
        }
        
        else if (skillName == "Aegis Shield")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(3, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.5, AttackType.FirstAttack));
        }
        
        else if (skillName == "Remote Sparrow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.3, AttackType.FirstAttack));
        }
        
        else if (skillName == "Remote Mirror")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.3, AttackType.FirstAttack));
        }
        
        else if (skillName == "Remote Sturdy")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.3, AttackType.FirstAttack));
        }
        
        else if (skillName == "Fierce Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.1, AttackType.FollowUp));
        }
        
        else if (skillName == "Darting Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.1, AttackType.FollowUp));
        }
        
        else if (skillName == "Steady Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.1, AttackType.FollowUp));
        }
        
        else if (skillName == "Warding Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(8, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.1, AttackType.FollowUp));
        }
        
        else if (skillName == "Kestrel Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.1, AttackType.FollowUp));
        }
        
        else if (skillName == "Sturdy Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.1, AttackType.FollowUp));
        }
        
        else if (skillName == "Mirror Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.1, AttackType.FollowUp));
        }
        
        else if (skillName == "Steady Posture")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.1, AttackType.FollowUp));
        }
        
        else if (skillName == "Swift Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.1, AttackType.FollowUp));
        }
        
        else if (skillName == "Bracing Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.1, AttackType.FollowUp));
        }
        
        else if (skillName == "Poetic Justice")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageExtraBySpecificEffect(UnitRole.Rival, 
                StatType.Atk, 0.15));
        }
        
        else if (skillName == "Laguz Friend")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(0.5));
            effectsByUnitType.AddEffect(UnitRole.Unit, new BonusNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Def, StatType.Res })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyByPercentageOfBaseValueEffect(
                0.5, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatPenaltyByPercentageOfBaseValueEffect(
                0.5, StatType.Res));
        }

        else if (skillName == "Chivalry")
        {
            conditions.Add(new HpPercentageCondition(1.0, UnitRole.Rival));
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageExtraByConstantEffect(2));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionEffect(2));
            conditionEvaluatorType = ConditionEvaluatorType.And; 
        }
        
        else if (skillName == "Dragon's Wrath")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.25, AttackType.FirstAttack));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new StatComparisonCondition(1, StatType.Atk, StatType.Res));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new DamageExtraBySpecificEffect(UnitRole.Both, 
                StatType.Atk, 0.25, StatType.Res, AttackType.FirstAttack));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Prescience")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Res));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondConditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Magic, WeaponType.Bow })));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.3, AttackType.FirstAttack));
            compositeSkill.AddComponent(new OrConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Extra Chivalry")
        {
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Def));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByHpEffect(0.5));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Guard Bearing")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new GuardBearingEffect());
        }
        
        else if (skillName == "Divine Recreation")
        {
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.3, AttackType.FirstAttack));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DivineRecreationEffect());
        }
        
        else if (skillName == "Sol")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPercentageBonusOfDamageEffect(0.25));
        }
        
        else if (skillName == "Nosferatu")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Magic })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPercentageBonusOfDamageEffect(0.5));
        }
        
        else if (skillName == "Solar Brace")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPercentageBonusOfDamageEffect(0.5));
        }
        
        else if (skillName == "Windsweep")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Sword })));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Sword })));
            effectsByUnitType.AddEffect(UnitRole.Rival, new CounterAttackDenialEffect());
            conditionEvaluatorType = ConditionEvaluatorType.And;
        }
        
        else if (skillName == "Surprise Attack")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Bow })));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Bow })));
            effectsByUnitType.AddEffect(UnitRole.Rival, new CounterAttackDenialEffect());
            conditionEvaluatorType = ConditionEvaluatorType.And;
        }
        
        else if (skillName == "Hliðskjálf")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Magic })));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Magic })));
            effectsByUnitType.AddEffect(UnitRole.Rival, new CounterAttackDenialEffect());
            conditionEvaluatorType = ConditionEvaluatorType.And;
        }
        
        else if (skillName == "Null C-Disrupt") 
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new CounterAttackDenialOfDenialEffect());
        }
        
        else if (skillName == "Laws of Sacae") 
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Res));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondConditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Sword, WeaponType.Lance, WeaponType.Axe })));
            secondConditions.Add(new StatComparisonCondition(5, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Rival, new CounterAttackDenialEffect());
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Eclipse Brace")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Sword, WeaponType.Lance, WeaponType.Axe, WeaponType.Bow })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageExtraBySpecificEffect(UnitRole.Rival, 
                StatType.Def, 0.3));
            compositeSkill.AddComponent(new AndConditionEvaluator(conditions),new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new HpPercentageBonusOfDamageEffect(0.5));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Resonance")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Magic })));
            conditions.Add(new ConstantStatLeftCondition(2, StatType.Hp));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyBeforeRoundEffect(1));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageExtraByConstantEffect(3));
            conditionEvaluatorType = ConditionEvaluatorType.And;
        }
        
        else if (skillName == "Flare")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Magic })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPercentageBonusOfDamageEffect(0.5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyByPercentageOfBaseValueEffect(
                0.2, StatType.Res));
        }
        
        else if (skillName == "Fury")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(4, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(4, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(4, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(4, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterRoundEffect(8));
        }
        
        else if (skillName == "Mystic Boost")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpBonusAfterRoundEffect(10));
        }

        else if (skillName == "Atk/Spd Push")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterRoundIfAttackedEffect(5));
        }
        
        else if (skillName == "Atk/Def Push")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterRoundIfAttackedEffect(5));
        }
        
        else if (skillName == "Atk/Res Push")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterRoundIfAttackedEffect(5));
        }
        
        else if (skillName == "Spd/Def Push")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterRoundIfAttackedEffect(5));
        }
        
        else if (skillName == "Spd/Res Push")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterRoundIfAttackedEffect(5));
        }
        
        else if (skillName == "Def/Res Push")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(7, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterRoundIfAttackedEffect(5));
        }
        
        else if (skillName == "True Dragon Wall")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Res, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByStatComparisonEffect(
                0.6, StatType.Res, StatType.Res, 6, AttackType.FirstAttack));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByStatComparisonEffect(
                0.4, StatType.Res, StatType.Res, 4, AttackType.FollowUp));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));

            secondConditions.Add(new TeamMatesWeaponTypeCondition(new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Magic })));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new HpBonusAfterRoundEffect(7));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Scendscale")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageExtraBySpecificEffect(UnitRole.Unit, 
                StatType.Atk, 0.25));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyAfterRoundIfAttackedEffect(7));
        }
        
        else if (skillName == "Mastermind")
        {
            conditions.Add(new ConstantStatLeftCondition(2, StatType.Hp));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpPenaltyBeforeRoundEffect(1));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(9, StatType.Atk));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(9, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new MastermindEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Bewitching Tome")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Magic, WeaponType.Bow })));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BewitchingTomeEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(5, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(5, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(5, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(5, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusFromPercentageOfOtherStatEffect(
                new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Spd }), 
                StatType.Spd, 0.2));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.3, AttackType.FirstAttack));
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpBonusAfterRoundEffect(7));
            conditionEvaluatorType = ConditionEvaluatorType.Or;
        }
        
        else if (skillName == "Quick Riposte")
        {
            conditions.Add(new HpPercentageConditionInversed(0.6, UnitRole.Unit));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            conditionEvaluatorType = ConditionEvaluatorType.And;
        }
        
        else if (skillName == "Follow-Up Ring")
        {
            conditions.Add(new HpPercentageConditionInversed(0.5, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
        }
        
        else if (skillName == "Wary Fighter")
        {
            conditions.Add(new HpPercentageConditionInversed(0.5, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialEffect());
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
        }
        
        else if (skillName == "Piercing Tribute")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialOfGuaranteesEffect());
        }
        
        else if (skillName == "Mjölnir")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
        }
        
        else if (skillName == "Brash Assault")
        {
            conditions.Add(new HpPercentageCondition(0.99, UnitRole.Unit));
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondConditions.Add(new HpPercentageCondition(1, UnitRole.Rival));
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.3, AttackType.FirstAttack));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new BrashAssaultEffect());
            conditionEvaluatorType = ConditionEvaluatorType.Complex;
        }
        
        else if (skillName == "Melee Breaker")
        {
            conditions.Add(new HpPercentageConditionInversed(0.5, UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Sword, WeaponType.Lance, WeaponType.Axe })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            conditionEvaluatorType = ConditionEvaluatorType.And;
        }
        
        else if (skillName == "Range Breaker")
        {
            conditions.Add(new HpPercentageConditionInversed(0.5, UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(
                new List<WeaponType> { WeaponType.Bow, WeaponType.Magic })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            conditionEvaluatorType = ConditionEvaluatorType.And;
        }
        
        else if (skillName == "Pegasus Flight")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Def));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new BaseStatComparisonCondition(-10, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyFromBaseValueDifferenceEffect(
                StatType.Res, new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def }), 8, 0.8));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            
            thirdConditions.Add(new BaseStatComparisonCondition(-10, StatType.Spd, StatType.Spd));
            thirdConditions.Add(new DoubleStatComparisonCondition(1, StatType.Spd, 
                StatType.Res, StatType.Spd, StatType.Res));
            thirdEffectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            compositeSkill.AddComponent(new AndConditionEvaluator(thirdConditions), 
                                        new EffectApplier(thirdEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Wyvern Flight")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Def));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new BaseStatComparisonCondition(-10, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyFromBaseValueDifferenceEffect(
                StatType.Def, new EnumList<StatType>(new List<StatType> { StatType.Atk, StatType.Def }), 
                8, 0.8));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            
            thirdConditions.Add(new BaseStatComparisonCondition(-10, StatType.Spd, StatType.Spd));
            thirdConditions.Add(new DoubleStatComparisonCondition(1, StatType.Spd, StatType.Def, 
                StatType.Spd, StatType.Def));
            thirdEffectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            compositeSkill.AddComponent(new AndConditionEvaluator(thirdConditions), 
                                        new EffectApplier(thirdEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Null Follow-Up")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialOfGuaranteesEffect());
        }
        
        else if (skillName == "Sturdy Impact")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
        }
        
        else if (skillName == "Mirror Impact")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
        }
        
        else if (skillName == "Swift Impact")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
        }
        
        else if (skillName == "Steady Impact")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(6, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new StatBonusEffect(10, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
        }
        
        else if (skillName == "Slick Fighter")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Unit, new PenaltyNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            conditionEvaluatorType = ConditionEvaluatorType.And;
        }
        
        else if (skillName == "Wily Fighter")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Rival, new BonusNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            conditionEvaluatorType = ConditionEvaluatorType.And;
        }
        
        else if (skillName == "Savvy Fighter")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialOfGuaranteesEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Rival));
            secondConditions.Add(new StatComparisonCondition(-4, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.3, AttackType.FirstAttack));
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Flow Force")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new PenaltyNeutralizationEffect(new EnumList<StatType>(
                new List<StatType> { StatType.Atk, StatType.Spd })));
        }
        
        else if (skillName == "Flow Refresh")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new HpBonusAfterRoundEffect(10));
        }
        
        else if (skillName == "Flow Feather")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondConditions.Add(new StatComparisonCondition(-10, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new DamageExtraBySpecificEffect(UnitRole.Both, 
                StatType.Res, 0.7, StatType.Res, AttackType.None, 7));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionBySpecificEffect(0.7, 
                StatType.Res, StatType.Res, 7, 0));
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Flow Flight")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondConditions.Add(new StatComparisonCondition(-10, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new DamageExtraBySpecificEffect(UnitRole.Both, 
                StatType.Def, 0.7, StatType.Def, AttackType.None, 7));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionBySpecificEffect(0.7, 
                StatType.Def, StatType.Def, 7, 0));
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Binding Shield")
        {
            conditions.Add(new StatComparisonCondition(5, StatType.Spd, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Unit));
            secondConditions.Add(new StatComparisonCondition(5, StatType.Spd, StatType.Spd));
            secondEffectsByUnitType.AddEffect(UnitRole.Rival, new CounterAttackDenialEffect());
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Sun-Twin Wing")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialOfGuaranteesEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
        }
        
        else if (skillName == "Dragon's Ire")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            secondConditions.Add(new FirstAttackCondition(UnitRole.Rival));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Black Eagle Rule")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            secondConditions.Add(new FirstAttackCondition(UnitRole.Rival));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByConstantEffect(
                0.8, AttackType.FollowUp));
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Blue Lion Rule")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Def, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByStatComparisonEffect(
                0.4, StatType.Def, StatType.Def, 4));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new FirstAttackCondition(UnitRole.Rival));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpGuaranteeEffect());
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "New Divinity")
        {
            conditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Atk));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(5, StatType.Res));
            compositeSkill.AddComponent(new DefaultConditionEvaluator(conditions), 
                                        new EffectApplier(effectsByUnitType));
            
            secondConditions.Add(new HpPercentageConditionInversed(0.25, UnitRole.Unit));
            secondConditions.Add(new StatComparisonCondition(1, StatType.Res, StatType.Res));
            secondEffectsByUnitType.AddEffect(UnitRole.Unit, new DamagePercentageReductionByStatComparisonEffect(
                0.4, StatType.Res, StatType.Res, 4));
            compositeSkill.AddComponent(new AndConditionEvaluator(secondConditions), 
                                        new EffectApplier(secondEffectsByUnitType));
            
            thirdConditions.Add(new HpPercentageConditionInversed(0.4, UnitRole.Unit));
            thirdEffectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialEffect());
            compositeSkill.AddComponent(new DefaultConditionEvaluator(thirdConditions), 
                                        new EffectApplier(thirdEffectsByUnitType));
            return compositeSkill;
        }
        
        else if (skillName == "Phys. Null Follow")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Def));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialOfGuaranteesEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionOfPercentageReductionEffect(0.5));
        }
        
        else if (skillName == "Mag. Null Follow")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Rival, new StatPenaltyEffect(4, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new FollowUpDenialOfDenialsEffect());
            effectsByUnitType.AddEffect(UnitRole.Rival, new FollowUpDenialOfGuaranteesEffect());
            effectsByUnitType.AddEffect(UnitRole.Unit, new DamageReductionOfPercentageReductionEffect(0.5));
        }

        else
        {
            throw new NotImplementedSkillException($"La skill {skillName} no está implementada.");
        }
        
        ConditionEvaluator conditionEvaluator = GetConditionEvaluator(
            conditions, secondConditions, conditionEvaluatorType);
        EffectApplier effectApplier = new EffectApplier(effectsByUnitType);
        Skill skill = new Skill(conditionEvaluator, effectApplier);
        return skill;
    }
    
    private static ConditionEvaluator GetConditionEvaluator(ConditionList conditions, ConditionList secondConditions,
        ConditionEvaluatorType conditionEvaluatorType)
    {
        if (conditionEvaluatorType == ConditionEvaluatorType.And)
        {
            return new AndConditionEvaluator(conditions);
        }
        if (conditionEvaluatorType == ConditionEvaluatorType.Or)
        {
            return new OrConditionEvaluator(conditions);
        }
        if (conditionEvaluatorType == ConditionEvaluatorType.Complex)
        {
            return new ComplexConditionEvaluator(conditions, secondConditions);
        }
        return new DefaultConditionEvaluator(conditions);
    }
}