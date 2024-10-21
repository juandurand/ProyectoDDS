using Fire_Emblem_Common.Conditions;
using Fire_Emblem_Common.Effects;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.ConditionEvaluators;
using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem_Common.Skills;

public static class SkillFactory
{
    public static SkillList GetSkills(StringList skillNames, Unit unit)
    {
        SkillList skills = new SkillList();
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
        ConditionList conditions = new ConditionList();
        EffectByUnitType effectsByUnitType = new EffectByUnitType();
        
        ConditionEvaluator conditionEvaluator;
        
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
           conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Moon-Twin Wing")
        {
            conditions.Add(new HpPercentageCondition(-0.25, UnitRole.Unit)); // El menor igual al reves por eso el menos
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
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
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Prescience")
        {
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new ResPenaltyEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Extra Chivalry")
        {
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Rival));
            effectsByUnitType.AddEffect(UnitRole.Rival, new AtkPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new SpdPenaltyEffect(5));
            effectsByUnitType.AddEffect(UnitRole.Rival, new DefPenaltyEffect(5));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
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
        ConditionList conditions = new ConditionList();
        EffectByUnitType effectsByUnitType = new EffectByUnitType();
        
        ConditionEvaluator conditionEvaluator;
        
        if (skillName == "Bushido")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ComparisonPercentageReductionEffect(0.4, StatType.Spd, StatType.Spd, 4));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Moon-Twin Wing")
        {
            conditions.Add(new HpPercentageCondition(-0.25, UnitRole.Unit)); // El menor igual al reves por eso el menos
            conditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ComparisonPercentageReductionEffect(0.4, StatType.Spd, StatType.Spd, 4));
            conditionEvaluator = new AndConditionEvaluator(conditions); 
        }
        
        else if (skillName == "Dragon's Wrath")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Atk, StatType.Res));
            effectsByUnitType.AddEffect(UnitRole.Unit, new SpecificExtraDamageEffect(UnitRole.Both, StatType.Atk, 0.25, StatType.Res, AttackType.FirstAttack));
            conditionEvaluator = new DefaultConditionEvaluator(conditions);
        }
        
        else if (skillName == "Prescience")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new EnumList<WeaponType>(new List<WeaponType> { WeaponType.Magic, WeaponType.Bow })));
            effectsByUnitType.AddEffect(UnitRole.Unit, new ConstantPercentageReductionEffect(0.3, AttackType.FirstAttack));
            conditionEvaluator = new OrConditionEvaluator(conditions); 
        }
        
        else if (skillName == "Extra Chivalry")
        {
            effectsByUnitType.AddEffect(UnitRole.Unit, new PercentageReductionByHpEffect(0.5));
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