using Fire_Emblem_Common.Helpers;
using Fire_Emblem_View.PersonalizedViews;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.EDDs.Models;
    
namespace Fire_Emblem;

public class CombatController
{
    private readonly RoundController _roundController;
    private readonly TeamManagerController _teamManagerController;
    private readonly GeneralView _view;
    private int _roundCounter = 1;

    public CombatController((PlayerUnitsInfo, PlayerUnitsInfo) playersInfo, GeneralView view)
    {
        _teamManagerController = new TeamManagerController(playersInfo);
        _view = view;
        _roundController = new RoundController(view);
    }
    
    public void AnnounceWinner()
    {
        _view.AnnounceWinner(_teamManagerController.GetPlayersUnits());
    }
    
    public void SimulateCombat()
    {
        while (_teamManagerController.AreTeamsAlive())
        {
            ProcessCombatRound();
            _roundCounter++;
        }
    }

    private void ProcessCombatRound()
    {
        RoundInfo roundInfo = GetRoundInfo();
        
        AnnounceRoundStart(roundInfo);
        _roundController.SimulateRound(roundInfo);
        ManageRoundEnd(roundInfo);
    }
    
    private RoundInfo GetRoundInfo()
    {
        int attackerIndex = CombatHelper.GetAttackerIndex(_roundCounter);
        int defenderIndex = CombatHelper.GetDefenderIndex(_roundCounter);
        
        Unit attacker = _teamManagerController.ChooseUnit(attackerIndex, _view);
        Unit defender = _teamManagerController.ChooseUnit(defenderIndex, _view);
        
        return new RoundInfo(attacker, defender);
    }
    
    private void AnnounceRoundStart(RoundInfo roundInfo)
    {
        int attackerIndex = CombatHelper.GetAttackerIndex(_roundCounter);
        
        _view.AnnounceRound(_roundCounter, roundInfo, CombatHelper.GetPlayerName(attackerIndex));
    }

    private void ManageRoundEnd(RoundInfo roundInfo)
    {
        int attackerIndex = CombatHelper.GetAttackerIndex(_roundCounter);
        int defenderIndex = CombatHelper.GetDefenderIndex(_roundCounter);
        
        _view.ReportRoundSummary(roundInfo);
        _teamManagerController.CheckUnitsHealth(roundInfo, attackerIndex, defenderIndex);
    }
}
