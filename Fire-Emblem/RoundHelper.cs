using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Skills;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem.Managers;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem;

public static class RoundHelper
{
    public static void StartRound(RoundInfo roundInfo)
    {
        SetAttacker(roundInfo);
        SetActualOpponent(roundInfo);
        SetFirstAttackDefense(roundInfo);
    }

    private static void SetAttacker(RoundInfo roundInfo)
    {
        roundInfo.Attacker.Attacking = true;
        roundInfo.Defender.Attacking = false;
    }

    private static void SetActualOpponent(RoundInfo roundInfo)
    {
        roundInfo.Attacker.ActualOpponent = roundInfo.Defender;
        roundInfo.Defender.ActualOpponent = roundInfo.Attacker;
    }
    
    private static void SetFirstAttackDefense(RoundInfo roundInfo)
    {
        UnitManager.SetFirstAttack(roundInfo.Attacker);
        UnitManager.SetFirstDefense(roundInfo.Defender);
    }
    
    public static void EndRound(RoundInfo roundInfo)
    {
        ResetSkills(roundInfo);
        SetLastOpponent(roundInfo);
        SetFirstAttackDefense(roundInfo);
    }
    
    private static void ResetSkills(RoundInfo roundInfo)
    {
        UnitManager.ResetEffects(roundInfo.Attacker);
        UnitManager.ResetEffects(roundInfo.Defender);
    }

    private static void SetLastOpponent(RoundInfo roundInfo)
    {
        roundInfo.Attacker.LastOpponent = roundInfo.Defender;
        roundInfo.Defender.LastOpponent = roundInfo.Attacker;
    }
    
    public static void ApplyAllSkills(RoundInfo roundInfo)
    {
        EnumList<EffectsApplyOrder> applyOrders = new EnumList<EffectsApplyOrder>(
                                        new List<EffectsApplyOrder>
        {
            EffectsApplyOrder.FirstOrder,
            EffectsApplyOrder.SecondOrder,
            EffectsApplyOrder.ThirdOrder
        });
        
        foreach (EffectsApplyOrder applyOrder in applyOrders)
        {
            ApplySkillsForSpecificSkillOwner(roundInfo, roundInfo.Defender, applyOrder);
            ApplySkillsForSpecificSkillOwner(roundInfo, roundInfo.Attacker, applyOrder);
        }
    }
    
    private static void ApplySkillsForSpecificSkillOwner(RoundInfo roundInfo, Unit skillOwner,
                                                         EffectsApplyOrder applyOrder)
    {
        roundInfo.SetCurrentSkillOwner(skillOwner);
        foreach (ISkill skill in roundInfo.SkillOwner.Skills)
        {
            skill.Apply(roundInfo, applyOrder);
        }
    }
    
    public static void SetPenaltyAfterRoundIfUnitsAttacked(RoundInfo roundInfo)
    {
        UnitManager.SetPenaltyAfterRoundIfUnitAttacked(roundInfo.Attacker);
        UnitManager.SetPenaltyAfterRoundIfUnitAttacked(roundInfo.Defender);
    }
    
    public static void ApplyDamageEffectsAfterRound(RoundInfo roundInfo)
    {
        HealthStatusManager.ApplyEffectsAfterRound(roundInfo.Attacker.HealthStatus);
        HealthStatusManager.ApplyEffectsAfterRound(roundInfo.Defender.HealthStatus);
    }

    public static void ResetAttacked(RoundInfo roundInfo)
    {
        UnitManager.ResetAttacked(roundInfo.Attacker);
        UnitManager.ResetAttacked(roundInfo.Defender);
    }
}
