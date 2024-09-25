using Fire_Emblem_Common;
using Fire_Emblem_View;
namespace Fire_Emblem;

public class Combat
{
    private readonly Round _round;
    private readonly TeamManager _teamManager;
    private readonly View _view;
    
    private int _roundCounter = 1;

    public Combat((List<Tuple<string, List<string>>>, List<Tuple<string, List<string>>>) playersInfo, View view)
    {
        _teamManager = new TeamManager(playersInfo);
        _view = view;
        _round = new Round(view);
    }
    
    public void InitiateCombat()
    {
        while (_teamManager.AreTeamsAlive())
        {
            ProcessCombatRound();
            _roundCounter++;
        }
        _view.AnnounceWinner(_teamManager.GetPlayersUnits());
    }

    private void ProcessCombatRound()
    {
        (int attackerIndex, int defenderIndex) = CombatHelper.GetAttackerDefenderIndex(_roundCounter);
        
        Dictionary<string, Unit> roundInfo = new Dictionary<string, Unit>
        {
            { "Attacker", _teamManager.ChooseUnit(attackerIndex, _view) }, 
            { "Defender", _teamManager.ChooseUnit(defenderIndex, _view) }
        };
        
        _view.AnnounceRound(_roundCounter, roundInfo, CombatHelper.GetPlayerName(attackerIndex));
        _round.SimulateRound(roundInfo);
        
        _view.ReportRoundSummary(roundInfo);
        _teamManager.CheckUnitsHealth(roundInfo, attackerIndex, defenderIndex);
    }
}
