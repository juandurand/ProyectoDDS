using Fire_Emblem_Common;
using Fire_Emblem_View;

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
        return _attackManager.SimulateAttack(roundInfo.Attacker, roundInfo.Defender, AttackType.FirstAttack) ||
               _attackManager.SimulateAttack(roundInfo.Defender, roundInfo.Attacker, AttackType.FirstAttack);
    }

    private void PerformFollowUp(RoundInfo roundInfo)
    {
        _attackManager.SimulateFollowUp(roundInfo.Attacker, roundInfo.Defender);
    }

    private void EndRound(RoundInfo roundInfo)
    {
        RoundManager.RoundEnded(roundInfo);
    }
}

