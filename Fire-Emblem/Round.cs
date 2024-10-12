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
    
    public void SimulateRound(Dictionary<string, Unit> roundInfo)
    {
        RoundManager.RoundStarted(roundInfo);
        RoundManager.ApplyAllSkills(roundInfo);
        _view.AnnounceSkills(roundInfo);
        
        if (_attackManager.SimulateAttack(roundInfo["Attacker"], roundInfo["Defender"],"First Attack") ||
            _attackManager.SimulateAttack( roundInfo["Defender"], roundInfo["Attacker"], "First Attack"))
        {
            RoundManager.RoundEnded(roundInfo);
            return;
        }
        
        _attackManager.SimulateFollowUp(roundInfo["Attacker"], roundInfo["Defender"]);
        RoundManager.RoundEnded(roundInfo);
    }
}

