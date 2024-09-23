using Fire_Emblem_Common.Conditions;
using Fire_Emblem_Common.Effects;

namespace Fire_Emblem_Common;

public static class SkillFactory
{
    public static Skill CreateSkill(string skillName, Unit unit)
    {
        List<string> statType = new List<string> { "Atk", "Def", "Res", "Spd" };
        
        List<Condition> conditions = new List<Condition>();
        List<Effectt> effects = new List<Effectt>();
        string conditionConnector = "No Connector";
        string typeOfUnit = "Unit";
        
        //                  HP+15
        
        if (skillName == "HP +15")
        {
            Effectt effect = new AlterBaseStatsEffectt();
            effects.Add(effect);
        }
        
        //                  BONUUUUS 
        
        if (skillName == "Fair Fight")
        {
            Condition condition = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition);

            Effectt effect = new AtkBonusEffectt(6);
            effects.Add(effect);
            
            typeOfUnit = "Both";
        }
        
        if (skillName == "Will to Win")
        {
            Condition condition = new HpPercentageCondition(0.5, "Unit");
            conditions.Add(condition);

            Effectt effect = new AtkBonusEffectt(8);
            effects.Add(effect);
        }
        
        if (skillName == "Single-Minded")
        {
            Condition condition = new LastOpponentCondition();
            conditions.Add(condition);

            Effectt effect = new AtkBonusEffectt(8);
            effects.Add(effect);
        }
        
        if (skillName == "Ignis")
        {
            Effectt effect = new AtkBonusEffectt(unit.Atk/2, "First Attack");
            effects.Add(effect);
        }
        
        if (skillName == "Perceptive")
        {
            Condition condition = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition);

            Effectt effect = new SpdBonusEffectt(12 + unit.Spd/4);
            effects.Add(effect);
        }
        
        if (skillName == "Tome Precision")
        {
            List<string> requiredWeaponType = new List<string> { "Magic" };
            Condition condition = new WeaponTypeCondition("Unit", requiredWeaponType);
            conditions.Add(condition);

            Effectt effect1 = new SpdBonusEffectt(6);
            Effectt effect2 = new AtkBonusEffectt(6);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Attack +6")
        {
            Effectt effect = new AtkBonusEffectt(6);
            effects.Add(effect);
        }
        
        if (skillName == "Speed +5")
        {
            Effectt effect = new SpdBonusEffectt(5);
            effects.Add(effect);
        }
        
        if (skillName == "Defense +5")
        {
            Effectt effect = new DefBonusEffectt(5);
            effects.Add(effect);
        }
        
        if (skillName == "Wrath")
        {
            int bonus = Math.Min(unit.Hp - unit.ActualHp, 0);
            Effectt effect1 = new SpdBonusEffectt(Math.Max(bonus, 30));
            Effectt effect2 = new AtkBonusEffectt(Math.Max(bonus, 30));
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Resolve")
        {
            Condition condition = new HpPercentageCondition(0.75, "Unit");
            conditions.Add(condition);

            Effectt effect1 = new DefBonusEffectt(7);
            Effectt effect2 = new ResBonusEffectt(7);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Resistance +5")
        {
            Effectt effect = new ResBonusEffectt(5);
            effects.Add(effect);
        }
        
        if (skillName == "Atk/Def +5")
        {
            Effectt effect1 = new AtkBonusEffectt(5);
            Effectt effect2 = new DefBonusEffectt(5);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Atk/Res +5")
        {
            Effectt effect1 = new AtkBonusEffectt(5);
            Effectt effect2 = new ResBonusEffectt(5);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Spd/Res +5")
        {
            Effectt effect1 = new SpdBonusEffectt(5);
            Effectt effect2 = new ResBonusEffectt(5);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Deadly Blade")
        {
            List<string> requiredWeaponType = new List<string> { "Sword" };
            Condition condition1 = new WeaponTypeCondition("Unit", requiredWeaponType);
            Condition condition2 = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition1);
            conditions.Add(condition2);

            Effectt effect1 = new SpdBonusEffectt(8);
            Effectt effect2 = new AtkBonusEffectt(8);
            effects.Add(effect1);
            effects.Add(effect2);

            conditionConnector = "And";
        }
        
        if (skillName == "Death Blow")
        {
            Condition condition = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition);

            Effectt effect = new AtkBonusEffectt(8);
            effects.Add(effect);
        }
        
        if (skillName == "Armored Blow")
        {
            Condition condition = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition);

            Effectt effect = new DefBonusEffectt(8);
            effects.Add(effect);
        }
        
        if (skillName == "Darting Blow")
        {
            Condition condition = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition);

            Effectt effect = new SpdBonusEffectt(8);
            effects.Add(effect);
        }
        
        if (skillName == "Warding Blow")
        {
            Condition condition = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition);

            Effectt effect = new ResBonusEffectt(8);
            effects.Add(effect);
        }
        
        if (skillName == "Swift Sparrow")
        {
            Condition condition = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition);

            Effectt effect1 = new AtkBonusEffectt(6);
            Effectt effect2 = new SpdBonusEffectt(6);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Sturdy Blow")
        {
            Condition condition = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition);

            Effectt effect1 = new AtkBonusEffectt(6);
            Effectt effect2 = new DefBonusEffectt(6);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Mirror Strike")
        {
            Condition condition = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition);

            Effectt effect1 = new AtkBonusEffectt(6);
            Effectt effect2 = new ResBonusEffectt(6);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Steady Blow")
        {
            Condition condition = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition);

            Effectt effect1 = new DefBonusEffectt(6);
            Effectt effect2 = new SpdBonusEffectt(6);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Swift Strike")
        {
            Condition condition = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition);

            Effectt effect1 = new ResBonusEffectt(6);
            Effectt effect2 = new SpdBonusEffectt(6);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Bracing Blow")
        {
            Condition condition = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition);

            Effectt effect1 = new ResBonusEffectt(6);
            Effectt effect2 = new DefBonusEffectt(6);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Brazen Atk/Spd")
        {
            Condition condition = new HpPercentageCondition(0.8, "Unit");
            conditions.Add(condition);

            Effectt effect1 = new AtkBonusEffectt(10);
            Effectt effect2 = new SpdBonusEffectt(10);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Brazen Atk/Def")
        {
            Condition condition = new HpPercentageCondition(0.8, "Unit");
            conditions.Add(condition);

            Effectt effect1 = new AtkBonusEffectt(10);
            Effectt effect2 = new DefBonusEffectt(10);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Brazen Atk/Res")
        {
            Condition condition = new HpPercentageCondition(0.8, "Unit");
            conditions.Add(condition);

            Effectt effect1 = new AtkBonusEffectt(10);
            Effectt effect2 = new ResBonusEffectt(10);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Brazen Spd/Def")
        {
            Condition condition = new HpPercentageCondition(0.8, "Unit");
            conditions.Add(condition);

            Effectt effect1 = new SpdBonusEffectt(10);
            Effectt effect2 = new DefBonusEffectt(10);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Brazen Spd/Res")
        {
            Condition condition = new HpPercentageCondition(0.8, "Unit");
            conditions.Add(condition);

            Effectt effect1 = new SpdBonusEffectt(10);
            Effectt effect2 = new ResBonusEffectt(10);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Brazen Def/Res")
        {
            Condition condition = new HpPercentageCondition(0.8, "Unit");
            conditions.Add(condition);

            Effectt effect1 = new DefBonusEffectt(10);
            Effectt effect2 = new ResBonusEffectt(10);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Fire Boost")
        {
            Condition condition = new HpComparisonCondition(3);
            conditions.Add(condition);

            Effectt effect = new AtkBonusEffectt(6);
            effects.Add(effect);
        }
        
        if (skillName == "Wind Boost")
        {
            Condition condition = new HpComparisonCondition(3);
            conditions.Add(condition);

            Effectt effect = new SpdBonusEffectt(6);
            effects.Add(effect);
        }
        
        if (skillName == "Earth Boost")
        {
            Condition condition = new HpComparisonCondition(3);
            conditions.Add(condition);

            Effectt effect = new DefBonusEffectt(6);
            effects.Add(effect);
        }
        
        if (skillName == "Water Boost")
        {
            Condition condition = new HpComparisonCondition(3);
            conditions.Add(condition);

            Effectt effect = new ResBonusEffectt(6);
            effects.Add(effect);
        }
        
        if (skillName == "Chaos Style") // FALTA EL CASO AL REVESSS
        {
            List<string> requiredWeaponType1 = new List<string> { "Sword", "Bow", "Lance", "Axe" };
            Condition condition1 = new WeaponTypeCondition("Unit", requiredWeaponType1);
            Condition condition2 = new FirstAttackCondition("Unit", unit.Name);
            List<string> requiredWeaponType2 = new List<string> { "Magic" };
            Condition condition3 = new WeaponTypeCondition("Unit", requiredWeaponType2);
            conditions.Add(condition1);
            conditions.Add(condition2);
            conditions.Add(condition3);

            Effectt effect = new SpdBonusEffectt(3);
            effects.Add(effect);
            
            conditionConnector = "And";
        }
        
        //                  PENALTY
        
        if (skillName == "Blinding Flash")
        {
            Condition condition = new FirstAttackCondition("Unit", unit.Name);
            conditions.Add(condition);

            Effectt effect = new SpdPenaltyEffectt(4);
            effects.Add(effect);

            typeOfUnit = "Rival";
        }
        
        if (skillName == "Not *Quite*")
        {
            Condition condition = new FirstAttackCondition("Rival", unit.Name);
            conditions.Add(condition);

            Effectt effect = new AtkPenaltyEffectt(4);
            effects.Add(effect);

            typeOfUnit = "Rival";
        }
        
        if (skillName == "Stunning Smile")
        {
            Condition condition = new ManRivalCondition();
            conditions.Add(condition);

            Effectt effect = new SpdPenaltyEffectt(8);
            effects.Add(effect);

            typeOfUnit = "Rival";
        }
        
        if (skillName == "Disarming Sigh")
        {
            Condition condition = new ManRivalCondition();
            conditions.Add(condition);

            Effectt effect = new AtkPenaltyEffectt(8);
            effects.Add(effect);

            typeOfUnit = "Rival";
        }
        
        if (skillName == "Charmer")
        {
            Condition condition = new LastOpponentCondition();
            conditions.Add(condition);

            Effectt effect1 = new AtkPenaltyEffectt(3);
            Effectt effect2 = new SpdPenaltyEffectt(3);
            effects.Add(effect1);
            effects.Add(effect2);

            typeOfUnit = "Rival";
        }
        
        if (skillName == "Luna") 
        {
            Effectt effect1 = new DefPercentagePenaltyEffectt(0.5);
            Effectt effect2 = new ResPercentagePenaltyEffectt(0.5);
            effects.Add(effect1);
            effects.Add(effect2);

            typeOfUnit = "Rival";
        }
        
        if (skillName == "Belief in Love")
        {
            Condition condition1 = new FirstAttackCondition("Rival", unit.Name);
            Condition condition2 = new HpPercentageCondition(1.0, "Rival");
            conditions.Add(condition1);
            conditions.Add(condition2);

            Effectt effect1 = new AtkPenaltyEffectt(5);
            Effectt effect2 = new DefPenaltyEffectt(5);
            effects.Add(effect1);
            effects.Add(effect2);

            typeOfUnit = "Rival";
            conditionConnector = "Or";
        }
        
        //                  BONUS NEUTRALIZATION
        if (skillName == "Beorc's Blessing") 
        {
            Effectt effect = new BonusNeutralizationEffectt(statType);
            effects.Add(effect);

            typeOfUnit = "Rival";
        }
        
        //                  PENALTY NEUTRALIZATION
        if (skillName == "Beorc's Blessing") 
        {
            Effectt effect = new PenaltyNeutralizationEffectt(statType);
            effects.Add(effect);
        }
        
        //                  HIBRIDS
        if (skillName == "SoulBlade")
        {
            List<string> requiredWeaponType = new List<string> { "Sword" };
            Condition condition = new WeaponTypeCondition("Unit", requiredWeaponType);
            conditions.Add(condition);

            Effectt effect = new AverageDefResEffectt();
            effects.Add(effect);
            
            typeOfUnit = "Rival";
        }
        
        if (skillName == "SoulBlade")
        {
            Effectt effect = new SandstormEffectt();
            effects.Add(effect);
        }
        
        if (skillName == "Sword Agility")
        {
            List<string> requiredWeaponType = new List<string> { "Sword" };
            Condition condition = new WeaponTypeCondition("Unit", requiredWeaponType);
            conditions.Add(condition);

            Effectt effect1 = new SpdBonusEffectt(12);
            Effectt effect2 = new AtkPenaltyEffectt(6);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Lance Power")
        {
            List<string> requiredWeaponType = new List<string> { "Lance" };
            Condition condition = new WeaponTypeCondition("Unit", requiredWeaponType);
            conditions.Add(condition);

            Effectt effect1 = new AtkBonusEffectt(10);
            Effectt effect2 = new DefPenaltyEffectt(10);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Sword Power")
        {
            List<string> requiredWeaponType = new List<string> { "Sword" };
            Condition condition = new WeaponTypeCondition("Unit", requiredWeaponType);
            conditions.Add(condition);

            Effectt effect1 = new AtkBonusEffectt(10);
            Effectt effect2 = new DefPenaltyEffectt(10);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Bow Focus")
        {
            List<string> requiredWeaponType = new List<string> { "Bow" };
            Condition condition = new WeaponTypeCondition("Unit", requiredWeaponType);
            conditions.Add(condition);

            Effectt effect1 = new AtkBonusEffectt(10);
            Effectt effect2 = new ResPenaltyEffectt(10);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Lance Agility")
        {
            List<string> requiredWeaponType = new List<string> { "Lance" };
            Condition condition = new WeaponTypeCondition("Unit", requiredWeaponType);
            conditions.Add(condition);

            Effectt effect1 = new SpdBonusEffectt(12);
            Effectt effect2 = new AtkPenaltyEffectt(6);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Axe Power")
        {
            List<string> requiredWeaponType = new List<string> { "Axe" };
            Condition condition = new WeaponTypeCondition("Unit", requiredWeaponType);
            conditions.Add(condition);

            Effectt effect1 = new AtkBonusEffectt(10);
            Effectt effect2 = new DefPenaltyEffectt(10);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Bow Agility")
        {
            List<string> requiredWeaponType = new List<string> { "Bow" };
            Condition condition = new WeaponTypeCondition("Unit", requiredWeaponType);
            conditions.Add(condition);

            Effectt effect1 = new SpdBonusEffectt(12);
            Effectt effect2 = new AtkPenaltyEffectt(6);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Sword Focus")
        {
            List<string> requiredWeaponType = new List<string> { "Sword" };
            Condition condition = new WeaponTypeCondition("Unit", requiredWeaponType);
            conditions.Add(condition);

            Effectt effect1 = new AtkBonusEffectt(10);
            Effectt effect2 = new ResPenaltyEffectt(10);
            effects.Add(effect1);
            effects.Add(effect2);
        }
        
        if (skillName == "Close Def") // ARREGLARRR
        {
            List<string> requiredWeaponType = new List<string> { "Sword", "Lance", "Axe" };
            Condition condition1 = new WeaponTypeCondition("Rival", requiredWeaponType);
            Condition condition2 = new FirstAttackCondition("Rival", unit.Name);
            conditions.Add(condition1);
            conditions.Add(condition2);

            Effectt effect1 = new DefBonusEffectt(8);
            Effectt effect2 = new ResBonusEffectt(8);
            Effectt effect3 = new BonusNeutralizationEffectt(statType); // ESTE DEBERÍA SER AL RIVAL
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);
            
            conditionConnector = "And";
        }
        
        if (skillName == "Distant Def") // ARREGLARRR
        {
            List<string> requiredWeaponType = new List<string> { "Magic", "Bow" };
            Condition condition1 = new WeaponTypeCondition("Rival", requiredWeaponType);
            Condition condition2 = new FirstAttackCondition("Rival", unit.Name);
            conditions.Add(condition1);
            conditions.Add(condition2);

            Effectt effect1 = new DefBonusEffectt(8);
            Effectt effect2 = new ResBonusEffectt(8);
            Effectt effect3 = new BonusNeutralizationEffectt(statType); // ESTE DEBERÍA SER AL RIVAL
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);
            
            conditionConnector = "And";
        }

        if (skillName == "Lull Atk/Spd")
        {
            Effectt effect1 = new AtkPenaltyEffectt(3);
            Effectt effect2 = new SpdPenaltyEffectt(3);
            statType = new List<string> { "Atk", "Spd" };
            Effectt effect3 = new BonusNeutralizationEffectt(statType);
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);

            typeOfUnit = "Rival";
        }
        
        if (skillName == "Lull Atk/Def")
        {
            Effectt effect1 = new AtkPenaltyEffectt(3);
            Effectt effect2 = new DefPenaltyEffectt(3);
            statType = new List<string> { "Atk", "Def" };
            Effectt effect3 = new BonusNeutralizationEffectt(statType);
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);
            
            typeOfUnit = "Rival";
        }
        
        if (skillName == "Lull Atk/Res")
        {
            Effectt effect1 = new AtkPenaltyEffectt(3);
            Effectt effect2 = new ResPenaltyEffectt(3);
            statType = new List<string> { "Atk", "Res" };
            Effectt effect3 = new BonusNeutralizationEffectt(statType);
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);
            
            typeOfUnit = "Rival";
        }
        
        if (skillName == "Lull Spd/Def")
        {
            Effectt effect1 = new SpdPenaltyEffectt(3);
            Effectt effect2 = new DefPenaltyEffectt(3);
            statType = new List<string> { "Spd", "Def" };
            Effectt effect3 = new BonusNeutralizationEffectt(statType);
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);
            
            typeOfUnit = "Rival";
        }
        
        if (skillName == "Lull Spd/Res")
        {
            Effectt effect1 = new SpdPenaltyEffectt(3);
            Effectt effect2 = new ResPenaltyEffectt(3);
            statType = new List<string> { "Spd", "Res" };
            Effectt effect3 = new BonusNeutralizationEffectt(statType);
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);
            
            typeOfUnit = "Rival";
        }
        
        if (skillName == "Lull Def/Res")
        {
            Effectt effect1 = new DefPenaltyEffectt(3);
            Effectt effect2 = new ResPenaltyEffectt(3);
            statType = new List<string> { "Def", "Res" };
            Effectt effect3 = new BonusNeutralizationEffectt(statType);
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);
            
            typeOfUnit = "Rival";
        }
        
        if (skillName == "Fort. Def/Res")
        {
            Effectt effect1 = new DefBonusEffectt(6);
            Effectt effect2 = new ResBonusEffectt(6);
            Effectt effect3 = new AtkPenaltyEffectt(2);
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);
        }
        
        if (skillName == "Life and Death")
        {
            Effectt effect1 = new AtkBonusEffectt(6);
            Effectt effect2 = new SpdBonusEffectt(6);
            Effectt effect3 = new DefPenaltyEffectt(5);
            Effectt effect4 = new ResPenaltyEffectt(5);
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);
            effects.Add(effect4);
        }
        
        if (skillName == "Solid Ground")
        {
            Effectt effect1 = new AtkBonusEffectt(6);
            Effectt effect2 = new DefBonusEffectt(6);
            Effectt effect3 = new ResPenaltyEffectt(5);
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);
        }
        
        if (skillName == "Still Water")
        {
            Effectt effect1 = new AtkBonusEffectt(6);
            Effectt effect2 = new ResBonusEffectt(6);
            Effectt effect3 = new DefPenaltyEffectt(5);
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);
        }
        
        if (skillName == "Dragonskin") // ARREGLARRR
        {
            Condition condition1 = new HpPercentageCondition(0.75, "Rival");
            Condition condition2 = new FirstAttackCondition("Rival", unit.Name);
            conditions.Add(condition1);
            conditions.Add(condition2);

            Effectt effect1 = new DefBonusEffectt(6);
            Effectt effect2 = new ResBonusEffectt(6);
            Effectt effect3 = new AtkBonusEffectt(6);
            Effectt effect4 = new SpdBonusEffectt(6);
            Effectt effect5 = new BonusNeutralizationEffectt(statType); // ESTE DEBERÍA SER AL RIVAL
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);
            effects.Add(effect4);
            effects.Add(effect5);

            conditionConnector = "Or";
        }
        
        if (skillName == "Light and Dark") // ARREGLARRR
        {
            Effectt effect1 = new DefPenaltyEffectt(5);
            Effectt effect2 = new ResPenaltyEffectt(5);
            Effectt effect3 = new AtkPenaltyEffectt(5);
            Effectt effect4 = new SpdPenaltyEffectt(5);
            Effectt effect5 = new BonusNeutralizationEffectt(statType);
            Effectt effect6 = new PenaltyNeutralizationEffectt(statType); // ESTE DEBERÍA EN LA UNIDAD
            effects.Add(effect1);
            effects.Add(effect2);
            effects.Add(effect3);
            effects.Add(effect4);
            effects.Add(effect5);
            effects.Add(effect6);

            typeOfUnit = "Rival";
        }
        
        
        Skill skill = new Skill(effects, conditions, conditionConnector, typeOfUnit, unit.Name);
        return skill;
    }
}