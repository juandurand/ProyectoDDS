using Fire_Emblem_Common.Helpers;
using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;
using Fire_Emblem_View.PersonalizedViews;
using Fire_Emblem_Common.Enums;

namespace Fire_Emblem;

public class RoundController
{
    private readonly GeneralView _view;
    private readonly AttackController _attackController;

    public RoundController(GeneralView view)
    {
        _view = view;
        _attackController = new AttackController(view);
    }
    
    public void SimulateRound(RoundInfo roundInfo)
    {
        StartRound(roundInfo);
        ApplySkills(roundInfo);
        SimulateFirstAttacks(roundInfo);
        
        if (!IsUnitAlive(roundInfo.Defender) || !IsUnitAlive(roundInfo.Attacker))
        {
            EndRound(roundInfo);
            return;
        }
        
        SimulateFollowUps(roundInfo);
        EndRound(roundInfo);
    }
    
    private void StartRound(RoundInfo roundInfo)
    {
        RoundHelper.StartRound(roundInfo);
    }

    private void ApplySkills(RoundInfo roundInfo)
    {
        RoundHelper.ApplyAllSkills(roundInfo);
        _view.ReportSkills(roundInfo);
    }

    private void SimulateFirstAttacks(RoundInfo roundInfo)
    {
        SimulateAttack(roundInfo.Attacker, roundInfo.Defender);
        if (IsUnitAlive(roundInfo.Defender))
        {
            SimulateAttack(roundInfo.Defender, roundInfo.Attacker);
        }
    }
    
    private bool IsUnitAlive(Unit unit)
    {
        return HealthStatusManager.IsUnitAlive(unit.HealthStatus);
    }

    private void EndRound(RoundInfo roundInfo)
    {
        ApplyDamageEffectsAfterRound(roundInfo);
        RoundHelper.ResetAttacked(roundInfo);
        RoundHelper.EndRound(roundInfo);
    }
    
    private void SimulateFollowUps(RoundInfo roundInfo)
    {
        SimulateFollowUp(roundInfo.Attacker, roundInfo.Defender);
        if (IsUnitAlive(roundInfo.Defender))
        {
            SimulateFollowUp(roundInfo.Defender, roundInfo.Attacker);
        }
        ReportNoFollowUp(roundInfo);
    }
    
    private void SimulateAttack(Unit attacker, Unit defender)
    {
        DamageInfo damageInfo = new DamageInfo(attacker, defender, AttackType.FirstAttack);
        _attackController.SimulateAttack(damageInfo);
    }
    
    private void ApplyDamageEffectsAfterRound(RoundInfo roundInfo)
    {
        RoundHelper.SetPenaltyAfterCombatIfUnitsAttacked(roundInfo);
        RoundHelper.ApplyDamageEffectsAfterRound(roundInfo);
        _view.ReportDamageAfterRound(roundInfo);
    }
    
    private void SimulateFollowUp(Unit attacker, Unit defender)
    {
        DamageInfo damageInfo = new DamageInfo(attacker, defender, AttackType.FollowUp);
        _attackController.SimulateFollowUp(damageInfo);
    }
    
    private void ReportNoFollowUp(RoundInfo roundInfo)
    {
        DamageInfo damageInfo = new DamageInfo(roundInfo.Attacker, roundInfo.Defender, AttackType.FollowUp);
        _attackController.ReportNoFollowUp(damageInfo);
    }
}

