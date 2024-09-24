using Fire_Emblem_Common.Conditions;
using Fire_Emblem_Common.Effects;

namespace Fire_Emblem_Common;

public static class SkillFactory
{
    public static Skill CreateSkill(string skillName, Unit unit)
    {
        List<string> statType = new List<string> { "Atk", "Def", "Res", "Spd" };
        
        List<Condition> conditions = new List<Condition>();
        Dictionary<string, List<Effectt>> effectsByUnitType = new Dictionary<string, List<Effectt>>()
        {
            { "Rival", new List<Effectt>() },
            { "Unit", new List<Effectt>() },
            { "Both", new List<Effectt>() }
        };
        string conditionConnector = "No Connector";
        
        if (skillName == "HP +15")
        {
            effectsByUnitType["Unit"].Add(new AlterBaseStatsEffectt(skillName));
        }

        if (skillName == "Fair Fight")
        {
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));
            effectsByUnitType["Both"].Add(new AtkBonusEffectt(6));
        }

        if (skillName == "Will to Win")
        {
            conditions.Add(new HpPercentageCondition(0.5, "Unit"));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(8));
        }

        if (skillName == "Single-Minded")
        {
            conditions.Add(new LastOpponentCondition());
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(8));
        }

        if (skillName == "Ignis")
        {
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(unit.Atk / 2, "First Attack"));
        }

        if (skillName == "Perceptive")
        {
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(12 + unit.Spd / 4));
        }

        if (skillName == "Tome Precision")
        {
            conditions.Add(new WeaponTypeCondition("Unit", new List<string> { "Magic" }));
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
            effectsByUnitType["Unit"].Add(new AlterBaseStatsEffectt("Wrath"));
        }

        if (skillName == "Resolve")
        {
            conditions.Add(new HpPercentageCondition(0.75, "Unit"));
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
            conditions.Add(new WeaponTypeCondition("Unit", new List<string> { "Sword" }));
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));

            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(8));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(8));

            conditionConnector = "And";
        }

        if (skillName == "Death Blow")
        {
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(8));
        }

        if (skillName == "Armored Blow")
        {
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(8));
        }

        if (skillName == "Darting Blow")
        {
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(8));
        }

        if (skillName == "Warding Blow")
        {
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(8));
        }

        if (skillName == "Swift Sparrow")
        {
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
        }

        if (skillName == "Sturdy Blow")
        {
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
        }

        if (skillName == "Mirror Strike")
        {
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
        }

        if (skillName == "Steady Blow")
        {
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
        }

        if (skillName == "Swift Strike")
        {
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
        }

        if (skillName == "Bracing Blow")
        {
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
        }

        if (skillName == "Brazen Atk/Spd")
        {
            conditions.Add(new HpPercentageCondition(0.8, "Unit"));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(10));
        }

        if (skillName == "Brazen Atk/Def")
        {
            conditions.Add(new HpPercentageCondition(0.8, "Unit"));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(10));
        }

        if (skillName == "Brazen Atk/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, "Unit"));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(10));
        }

        if (skillName == "Brazen Spd/Def")
        {
            conditions.Add(new HpPercentageCondition(0.8, "Unit"));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(10));
        }

        if (skillName == "Brazen Spd/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, "Unit"));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(10));
        }

        if (skillName == "Brazen Def/Res")
        {
            conditions.Add(new HpPercentageCondition(0.8, "Unit"));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(10));
        }
        
        if (skillName == "Fire Boost")
        {
            conditions.Add(new HpComparisonCondition(3));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
        }
        
        if (skillName == "Wind Boost")
        {
            conditions.Add(new HpComparisonCondition(3));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
        }
        
        if (skillName == "Earth Boost")
        {
            conditions.Add(new HpComparisonCondition(3));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
        }
        
        if (skillName == "Water Boost")
        {
            conditions.Add(new HpComparisonCondition(3));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
        }
        
        if (skillName == "Chaos Style")
        {
            conditions.Add(new ChaosStyleCondition(unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(3));
        }
        
        if (skillName == "Blinding Flash")
        {
            conditions.Add(new FirstAttackCondition("Unit", unit.PersonalizedName));
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(4));
        }
        
        if (skillName == "Not *Quite*")
        {
            conditions.Add(new FirstAttackCondition("Rival", unit.PersonalizedName));
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
            effectsByUnitType["Rival"].Add(new DefPercentagePenaltyEffectt(0.5));
            effectsByUnitType["Rival"].Add(new ResPercentagePenaltyEffectt(0.5));
        }
        
        if (skillName == "Belief in Love")
        {
            conditions.Add(new FirstAttackCondition("Rival", unit.PersonalizedName));
            conditions.Add(new HpPercentageCondition(1.0, "Rival"));
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new DefPenaltyEffectt(5));
            conditionConnector = "Or";
        }
        
        if (skillName == "Beorc's Blessing")
        {
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(statType));
        }
        
        if (skillName == "Agnea's Arrow")
        {
            effectsByUnitType["Unit"].Add(new PenaltyNeutralizationEffectt(statType));
        }
        
        if (skillName == "Soulblade")
        {
            conditions.Add(new WeaponTypeCondition("Unit", new List<string> { "Sword" }));
            effectsByUnitType["Rival"].Add(new AverageDefResEffectt());
        }
        
        if (skillName == "Sandstorm")
        {
            effectsByUnitType["Unit"].Add(new SandstormEffectt());
        }
        
        if (skillName == "Sword Agility")
        {
            conditions.Add(new WeaponTypeCondition("Unit", new List<string> { "Sword" }));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(12));
            effectsByUnitType["Unit"].Add(new AtkPenaltyEffectt(6));
        }
        
        if (skillName == "Lance Power")
        {
            conditions.Add(new WeaponTypeCondition("Unit", new List<string> { "Lance" }));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new DefPenaltyEffectt(10));
        }
        
        if (skillName == "Sword Power")
        {
            conditions.Add(new WeaponTypeCondition("Unit", new List<string> { "Sword" }));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new DefPenaltyEffectt(10));
        }
        
        if (skillName == "Bow Focus")
        {
            conditions.Add(new WeaponTypeCondition("Unit", new List<string> { "Bow" }));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new ResPenaltyEffectt(10));
        }

        if (skillName == "Lance Agility")
        {
            conditions.Add(new WeaponTypeCondition("Unit", new List<string> { "Lance" }));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(12));
            effectsByUnitType["Unit"].Add(new AtkPenaltyEffectt(6));
        }

        if (skillName == "Axe Power")
        {
            conditions.Add(new WeaponTypeCondition("Unit", new List<string> { "Axe" }));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new DefPenaltyEffectt(10));
        }

        if (skillName == "Bow Agility")
        {
            conditions.Add(new WeaponTypeCondition("Unit", new List<string> { "Bow" }));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(12));
            effectsByUnitType["Unit"].Add(new AtkPenaltyEffectt(6));
        }

        if (skillName == "Sword Focus")
        {
            conditions.Add(new WeaponTypeCondition("Unit", new List<string> { "Sword" }));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(10));
            effectsByUnitType["Unit"].Add(new ResPenaltyEffectt(10));
        }

        if (skillName == "Close Def")
        {
            conditions.Add(new WeaponTypeCondition("Rival", new List<string> { "Sword", "Lance", "Axe" }));
            conditions.Add(new FirstAttackCondition("Rival", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(8));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(8));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(statType)); // Este efecto aplica al rival

            conditionConnector = "And";
        }

        if (skillName == "Distant Def")
        {
            conditions.Add(new WeaponTypeCondition("Rival", new List<string> { "Magic", "Bow" }));
            conditions.Add(new FirstAttackCondition("Rival", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(8));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(8));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(statType));

            conditionConnector = "And";
        }

        if (skillName == "Lull Atk/Spd")
        {
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(3));
            statType = new List<string> { "Atk", "Spd" };
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(statType));
        }

        if (skillName == "Lull Atk/Def")
        {
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new DefPenaltyEffectt(3));
            statType = new List<string> { "Atk", "Def" };
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(statType));
        }

        if (skillName == "Lull Atk/Res")
        {
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new ResPenaltyEffectt(3));
            statType = new List<string> { "Atk", "Res" };
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(statType));
        }

        if (skillName == "Lull Spd/Def")
        {
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new DefPenaltyEffectt(3));
            statType = new List<string> { "Spd", "Def" };
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(statType));
        }

        if (skillName == "Lull Spd/Res")
        {
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new ResPenaltyEffectt(3));
            statType = new List<string> { "Spd", "Res" };
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(statType));
        }

        if (skillName == "Lull Def/Res")
        {
            effectsByUnitType["Rival"].Add(new DefPenaltyEffectt(3));
            effectsByUnitType["Rival"].Add(new ResPenaltyEffectt(3));
            statType = new List<string> { "Def", "Res" };
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(statType));
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
            conditions.Add(new HpPercentageCondition(0.75, "Rival"));
            conditions.Add(new FirstAttackCondition("Rival", unit.PersonalizedName));
            effectsByUnitType["Unit"].Add(new DefBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new ResBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new AtkBonusEffectt(6));
            effectsByUnitType["Unit"].Add(new SpdBonusEffectt(6));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(statType));

            conditionConnector = "Or";
        }

        if (skillName == "Light and Dark")
        {
            effectsByUnitType["Rival"].Add(new DefPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new ResPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new AtkPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new SpdPenaltyEffectt(5));
            effectsByUnitType["Rival"].Add(new BonusNeutralizationEffectt(statType));
            effectsByUnitType["Unit"].Add(new PenaltyNeutralizationEffectt(statType));
        }
        
        Skill skill = new Skill(effectsByUnitType, conditions, conditionConnector, unit.PersonalizedName);
        return skill;
    }
}