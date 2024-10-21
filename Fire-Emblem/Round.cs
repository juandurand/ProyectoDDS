using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_View;
using Fire_Emblem_Common.Enums;

namespace Fire_Emblem;

public class Round
{
    private readonly View _view;
    private readonly AttackManager _attackManager;

    public Round(View view)
    {
        _view = view;
        _attackManager = new AttackManager(view);
    }
    
    public void SimulateRound(RoundInfo roundInfo)
    {
        StartRound(roundInfo);
        ApplySkills(roundInfo);
        if (FirstAttacks(roundInfo))
        {
            EndRound(roundInfo);
            return;
        }
        PerformFollowUp(roundInfo);
        EndRound(roundInfo);
    }
    
    private void StartRound(RoundInfo roundInfo)
    {
        RoundManager.RoundStarted(roundInfo);
    }

    private void ApplySkills(RoundInfo roundInfo)
    {
        RoundManager.ApplyAllSkills(roundInfo);
        _view.AnnounceSkills(roundInfo);
    }

    private bool FirstAttacks(RoundInfo roundInfo)
    {
        DamageInfo attackDamageInfo = new DamageInfo(roundInfo.Attacker, roundInfo.Defender, AttackType.FirstAttack);
        DamageInfo counterAttackDamageInfo = new DamageInfo(roundInfo.Defender, roundInfo.Attacker, AttackType.FirstAttack);
        
        return _attackManager.SimulateAttack(attackDamageInfo) || _attackManager.SimulateAttack(counterAttackDamageInfo);
    }

    private void EndRound(RoundInfo roundInfo)
    {
        RoundManager.RoundEnded(roundInfo);
    }
    
    private void PerformFollowUp(RoundInfo roundInfo)
    {
        DamageInfo attackerFollowUpDamageInfo = new DamageInfo(roundInfo.Attacker, roundInfo.Defender, AttackType.FollowUp);
        DamageInfo defenderFollowUpDamageInfo = new DamageInfo(roundInfo.Defender, roundInfo.Attacker, AttackType.FollowUp);
        
        _attackManager.SimulateFollowUp(attackerFollowUpDamageInfo);
        _attackManager.SimulateFollowUp(defenderFollowUpDamageInfo);
        
        _attackManager.ReportNoFollowUp(attackerFollowUpDamageInfo);
    }
}

