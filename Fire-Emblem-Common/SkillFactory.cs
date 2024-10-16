using Fire_Emblem_Common.Conditions;
using Fire_Emblem_Common.Effects;

namespace Fire_Emblem_Common;

public static class SkillFactory
{
    private static readonly List<string> _specialSkills = new List<string>
    {
        "Bushido", "Moon-Twin Wing", "Dragon's Wrath", "Prescience", "Extra Chivalry"
    };
    public static List<Skill> GetSkills(List<String> skillNames, Unit unit)
    {
        List<Skill> skills = new List<Skill>();
        foreach (string skillName in skillNames)
        {
            skills.Add(CreateSkill(skillName, unit));
            if (_specialSkills.Contains(skillName))
            {
                skills.Add(CreateSkill(skillName + "2", unit));
            }
        }
        return skills;
    }
    private static Skill CreateSkill(string skillName, Unit unit)
    {
        List<Condition> conditions = new List<Condition>();
        Dictionary<string, List<Effectt>> effectsByUnitType = new Dictionary<string, List<Effectt>>()
        {
            { "Rival", new List<Effectt>() },
            { "Unit", new List<Effectt>() },
            { "Both", new List<Effectt>() }
        };
        
        // DEFAULT VALUE
        string conditionConnector = "No Connector";
        
        if (skillName == "HP +15")
        {
            effectsByUnitType["Unit"].Add(new AlterBaseStatsEffectt(skillName));
        }

        if (skillName == "Fair Fight")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Both"].Add(new AtkBonusEffectt(6));
        }

        if (skillName == "Will to Win")
        {
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(8));
        }

        if (skillName == "Single-Minded")
        {
            conditions.Add(new LastOpponentCondition());
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(8));
        }

        if (skillName == "Ignis")
        {
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(unit.Atk.BaseValue / 2, AttackType.FirstAttack));
        }

        if (skillName == "Perceptive")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(12 + unit.Spd.BaseValue / 4));
        }

        if (skillName == "Tome Precision")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Magic }));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
        }

        if (skillName == "Attack +6")
        {
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
        }

        if (skillName == "Speed +5")
        {
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(5));
        }

        if (skillName == "Defense +5")
        {
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(5));
        }

        if (skillName == "Wrath")
        {
            effectsByUnitType["Unit"].Add(new AlterBaseStatsEffectt("Wrath")); // Cambiar
        }

        if (skillName == "Resolve")
        {
            conditions.Add(new HpPercentageCondition(0.75, UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(7));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(7));
        }

        if (skillName == "Resistance +5")
        {
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(5));
        }

        if (skillName == "Atk/Def +5")
        {
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(5));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(5));
        }

        if (skillName == "Atk/Res +5")
        {
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(5));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(5));
        }

        if (skillName == "Spd/Res +5")
        {
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(5));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(5));
        }
        
        if (skillName == "Deadly Blade")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Sword }));
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));

            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(8));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(8));

            conditionConnector = "And";
        }

        if (skillName == "Death Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(8));
        }

        if (skillName == "Armored Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(8));
        }

        if (skillName == "Darting Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(8));
        }

        if (skillName == "Warding Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(8));
        }

        if (skillName == "Swift Sparrow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
        }

        if (skillName == "Sturdy Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
        }

        if (skillName == "Mirror Strike")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
        }

        if (skillName == "Steady Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
        }

        if (skillName == "Swift Strike")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
        }

        if (skillName == "Bracing Blow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
        }

        if (skillName == "Brazen Atk/Spd")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(10));
        }

        if (skillName == "Brazen Atk/Def")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(10));
        }

        if (skillName == "Brazen Atk/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(10));
        }

        if (skillName == "Brazen Spd/Def")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(10));
        }

        if (skillName == "Brazen Spd/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(10));
        }

        if (skillName == "Brazen Def/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(10));
        }
        
        if (skillName == "Fire Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
        }
        
        if (skillName == "Wind Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
        }
        
        if (skillName == "Earth Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
        }
        
        if (skillName == "Water Boost")
        {
            conditions.Add(new StatComparisonCondition(3, StatType.Hp, StatType.Hp));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
        }
        
        if (skillName == "Chaos Style")
        {
            conditions.Add(new ChaosStyleCondition());
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(3));
        }
        
        if (skillName == "Blinding Flash")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(4));
        }
        
        if (skillName == "Not *Quite*")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(4));
        }
        
        if (skillName == "Stunning Smile")
        {
            conditions.Add(new ManRivalCondition());
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(8));
        }
        
        if (skillName == "Disarming Sigh")
        {
            conditions.Add(new ManRivalCondition());
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(8));
        }

        if (skillName == "Charmer")
        {
            conditions.Add(new LastOpponentCondition());
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(3));
        }
        
        if (skillName == "Luna")
        {
            effectsByUnitType["Rival"].Add(new DefPercentagePenaltyEffectt(0.5, AttackType.FirstAttack));
            effectsByUnitType["Rival"].Add(new ResPercentagePenaltyEffectt(0.5, AttackType.FirstAttack));
        }
        
        if (skillName == "Belief in Love")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            conditions.Add(new HpPercentageCondition(1.0, UnitRole.Rival));
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new DefPenaltyEffectt(5));
            
            conditionConnector = "Or";
        }
        
        if (skillName == "Beorc's Blessing")
        {
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));
        }
        
        if (skillName == "Agnea's Arrow")
        {
            effectsByUnitType["Unit"].Add(new PenaltyNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));
        }
        
        if (skillName == "Soulblade")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Sword }));
            effectsByUnitType["Rival"].Add(new AverageDefResEffectt());
        }
        
        if (skillName == "Sandstorm")
        {
            effectsByUnitType["Unit"].Add(new SandstormEffectt());
        }
        
        if (skillName == "Sword Agility")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Sword }));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(12));
            effectsByUnitType["Unit"].Add(new AtkPenaltyEffectt(6));
        }
        
        if (skillName == "Lance Power")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Lance }));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new DefPenaltyEffectt(10));
        }
        
        if (skillName == "Sword Power")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Sword }));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new DefPenaltyEffectt(10));
        }
        
        if (skillName == "Bow Focus")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Bow }));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new ResPenaltyEffectt(10));
        }

        if (skillName == "Lance Agility")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Lance }));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(12));
            effectsByUnitType["Unit"].Add(new AtkPenaltyEffectt(6));
        }

        if (skillName == "Axe Power")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Axe }));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new DefPenaltyEffectt(10));
        }

        if (skillName == "Bow Agility")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Bow }));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(12));
            effectsByUnitType["Unit"].Add(new AtkPenaltyEffectt(6));
        }

        if (skillName == "Sword Focus")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Sword }));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new ResPenaltyEffectt(10));
        }

        if (skillName == "Close Def")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Sword, WeaponType.Lance, WeaponType.Axe }));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(8));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(8));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));

            conditionConnector = "And";
        }

        if (skillName == "Distant Def")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Magic, WeaponType.Bow }));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(8));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(8));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));

            conditionConnector = "And";
        }

        if (skillName == "Lull Atk/Spd")
        {
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Spd }));
        }

        if (skillName == "Lull Atk/Def")
        {
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new DefPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def }));
        }

        if (skillName == "Lull Atk/Res")
        {
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new ResPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Res }));
        }

        if (skillName == "Lull Spd/Def")
        {
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new DefPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Spd, StatType.Def }));
        }

        if (skillName == "Lull Spd/Res")
        {
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new ResPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Spd, StatType.Res }));
        }

        if (skillName == "Lull Def/Res")
        {
            effectsByUnitType["Rival"].Add(new DefPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new ResPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Def, StatType.Res }));
        }

        if (skillName == "Fort. Def/Res")
        {
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new AtkPenaltyEffectt(2));
        }

        if (skillName == "Life and Death")
        {
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new DefPenaltyEffectt(5));
            effectsByUnitType["Unit"].Add(new ResPenaltyEffectt(5));
        }

        if (skillName == "Solid Ground")
        {
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ResPenaltyEffectt(5));
        }

        if (skillName == "Still Water")
        {
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new DefPenaltyEffectt(5));
        }

        if (skillName == "Dragonskin")
        {
            conditions.Add(new HpPercentageCondition(0.75, UnitRole.Rival));
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));

            conditionConnector = "Or";
        }

        if (skillName == "Light and Dark")
        {
            effectsByUnitType["Rival"].Add(new DefPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new ResPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));
            effectsByUnitType["Unit"].Add(new PenaltyNeutralizationEffectt(new List<StatType> { StatType.Atk, StatType.Def, StatType.Res, StatType.Spd }));
        }

        if (skillName == "Dragon Wall")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Res, StatType.Res));
            effectsByUnitType["Unit"].Add(new ComparisonPercentageReductionEffectt(0.4, StatType.Res, StatType.Res, 4));
        }
        
        if (skillName == "Dodge")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
            effectsByUnitType["Unit"].Add(new ComparisonPercentageReductionEffectt(0.4, StatType.Spd, StatType.Spd, 4));
        }
        
        if (skillName == "Golden Lotus")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Sword, WeaponType.Bow, WeaponType.Lance, WeaponType.Axe }));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.5, AttackType.FirstAttack));
        }
        
        if (skillName == "Gentility")
        {
            effectsByUnitType["Unit"].Add(new DamageReductionEffectt(5));
        }
        
        if (skillName == "Bow Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Bow }));
            effectsByUnitType["Unit"].Add(new DamageReductionEffectt(5));
        }
        
        if (skillName == "Arms Shield")
        {
            conditions.Add(new WeaponAdvantageCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new DamageReductionEffectt(7));
        }
        
        if (skillName == "Axe Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Axe }));
            effectsByUnitType["Unit"].Add(new DamageReductionEffectt(5));
        }
        
        if (skillName == "Magic Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Magic }));
            effectsByUnitType["Unit"].Add(new DamageReductionEffectt(5));
        }
        
        if (skillName == "Lance Guard")
        {
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Lance }));
            effectsByUnitType["Unit"].Add(new DamageReductionEffectt(5));
        }
        
        if (skillName == "Sympathetic")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new DamageReductionEffectt(5));

            conditionConnector = "And";
        }

        if (skillName == "Back at You")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new SpecificExtraDamageEffect(UnitRole.Unit, StatType.Hp, 0.5));
        }
        
        if (skillName == "Lunar Brace")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Unit, new List<WeaponType> { WeaponType.Sword, WeaponType.Bow, WeaponType.Lance, WeaponType.Axe }));
            effectsByUnitType["Unit"].Add(new SpecificExtraDamageEffect(UnitRole.Rival, StatType.Def, 0.3));
            
            conditionConnector = "And";
        }
        
        if (skillName == "Bravery")
        {
            effectsByUnitType["Unit"].Add(new ConstantExtraDamageEffectt(5));
        }

        if (skillName == "Bushido")
        {
           effectsByUnitType["Unit"].Add(new ConstantExtraDamageEffectt(7));
        }

        if (skillName == "Bushido2")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
            effectsByUnitType["Unit"].Add(new ComparisonPercentageReductionEffectt(0.4, StatType.Spd, StatType.Spd, 4));
        }
        
        if (skillName == "Moon-Twin Wing")
        {
            conditions.Add(new HpPercentageCondition(-0.25, UnitRole.Unit)); // El menor igual al reves por eso el menos
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(5));
        }
        
        if (skillName == "Moon-Twin Wing2")
        {
            conditions.Add(new HpPercentageCondition(-0.25, UnitRole.Unit)); // El menor igual al reves por eso el menos
            conditions.Add(new StatComparisonCondition(1, StatType.Spd, StatType.Spd));
            effectsByUnitType["Unit"].Add(new ComparisonPercentageReductionEffectt(0.4, StatType.Spd, StatType.Spd, 4));
            
            conditionConnector = "And"; 
        }
        
        if (skillName == "Blue Skies")
        {
            effectsByUnitType["Unit"].Add(new DamageReductionEffectt(5));
            effectsByUnitType["Unit"].Add(new ConstantExtraDamageEffectt(5));
        }
        
        if (skillName == "Aegis Shield")
        {
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(3));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.5, AttackType.FirstAttack));
        }
        
        if (skillName == "Remote Sparrow")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(7));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(7));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.3, AttackType.FirstAttack));
        }
        
        if (skillName == "Remote Mirror")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(7));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.3, AttackType.FirstAttack));
        }
        
        if (skillName == "Remote Sturdy")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(7));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.3, AttackType.FirstAttack));
        }
        
        if (skillName == "Fierce Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(8));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
        }
        
        if (skillName == "Darting Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(8));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
        }
        
        if (skillName == "Steady Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(8));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
        }
        
        if (skillName == "Warding Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(8));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
        }
        
        if (skillName == "Kestrel Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
        }
        
        if (skillName == "Sturdy Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
        }
        
        if (skillName == "Mirror Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
        }
        
        if (skillName == "Steady Posture")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
        }
        
        if (skillName == "Swift Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
        }
        
        if (skillName == "Bracing Stance")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Rival));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.1, AttackType.FollowUp));
        }
        
        if (skillName == "Poetic Justice")
        {
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(4));
            effectsByUnitType["Unit"].Add(new SpecificExtraDamageEffect(UnitRole.Rival, StatType.Atk, 0.15));
        }
        
        if (skillName == "Laguz Friend")
        {
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.5));
            effectsByUnitType["Unit"].Add(new BonusNeutralizationEffectt(new List<StatType> { StatType.Def, StatType.Res }));
            effectsByUnitType["Unit"].Add(new DefPercentagePenaltyEffectt(0.5));
            effectsByUnitType["Unit"].Add(new ResPercentagePenaltyEffectt(0.5));
        }

        if (skillName == "Chivalry")
        {
            conditions.Add(new HpPercentageCondition(1.0, UnitRole.Rival));
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            effectsByUnitType["Unit"].Add(new ConstantExtraDamageEffectt(2));
            effectsByUnitType["Unit"].Add(new DamageReductionEffectt(2));

            conditionConnector = "And";
        }
        
        if (skillName == "Dragon's Wrath")
        {
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.25, AttackType.FirstAttack));
        }
        
        if (skillName == "Dragon's Wrath2")
        {
            conditions.Add(new StatComparisonCondition(1, StatType.Atk, StatType.Res));
            effectsByUnitType["Unit"].Add(new SpecificExtraDamageEffect(UnitRole.Both, StatType.Atk, 0.25, StatType.Res, AttackType.FirstAttack));
        }
        
        if (skillName == "Prescience")
        {
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new ResPenaltyEffectt(5));
        }
        
        if (skillName == "Prescience2")
        {
            conditions.Add(new FirstAttackCondition(UnitRole.Unit));
            conditions.Add(new WeaponTypeCondition(UnitRole.Rival, new List<WeaponType> { WeaponType.Magic, WeaponType.Bow }));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.3, AttackType.FirstAttack));
            
            conditionConnector = "Or";
        }
        
        if (skillName == "Extra Chivalry")
        {
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Rival));
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new DefPenaltyEffectt(5));
        }
        
        if (skillName == "Extra Chivalry2")
        {
            effectsByUnitType["Unit"].Add(new PercentageReductionByHpEffectt(0.5));
        }
        
        if (skillName == "Guard Bearing")
        {
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(4));
            effectsByUnitType["Rival"].Add(new DefPenaltyEffectt(4));
            effectsByUnitType["Unit"].Add(new GuardBearingEffectt());
        }
        
        if (skillName == "Divine Recreation")
        {
            conditions.Add(new HpPercentageCondition(0.5, UnitRole.Rival));
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(4));
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(4));
            effectsByUnitType["Rival"].Add(new DefPenaltyEffectt(4));
            effectsByUnitType["Rival"].Add(new ResPenaltyEffectt(4));
            effectsByUnitType["Unit"].Add(new ConstantPercentageReductionEffectt(0.3, AttackType.FirstAttack));
            effectsByUnitType["Unit"].Add(new DivineRecreationEffectt());
        }

        ConditionEvaluator conditionEvaluator = new ConditionEvaluator(conditions, conditionConnector);
        EffectApplier effectApplier = new EffectApplier(effectsByUnitType);
        
        Skill skill = new Skill(conditionEvaluator, effectApplier);
        return skill;
    }
}