using Fire_Emblem_Common.Helpers;
using Fire_Emblem_View.PersonalizedViews;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Models;
    
namespace Fire_Emblem;

public class CombatController
{
    private readonly RoundController _roundController;
    private readonly TeamManagerController _teamManagerController;
    private readonly GeneralView _view;
    private int _roundCounter = 1;

    public CombatController(PlayerUnitsInfo playerOneUnitsInfo, PlayerUnitsInfo playerTwoUnitsInfo, GeneralView view)
    {
        _teamManagerController = new TeamManagerController(playerOneUnitsInfo, playerTwoUnitsInfo);
        _view = view;
        _roundController = new RoundController(view);
    }
    
    public void ReportWinner()
    {
        PlayerArray playersArray = _teamManagerController.GetPlayersUnits();
        
        _view.ReportWinner(playersArray);
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
        PlayerIndexes playerIndexes = GetPlayerIndexes();
        RoundInfo roundInfo = GetRoundInfo(playerIndexes);
        
        ReportRoundStart(roundInfo, playerIndexes);
        _roundController.SimulateRound(roundInfo);
        ManageRoundEnd(roundInfo, playerIndexes);
    }
    
    private PlayerIndexes GetPlayerIndexes()
    {
        return new PlayerIndexes(CombatHelper.GetAttackerIndex(_roundCounter),
                                 CombatHelper.GetDefenderIndex(_roundCounter));
    }
    
    private RoundInfo GetRoundInfo(PlayerIndexes playerIndexes)
    {
        Unit attacker = _teamManagerController.ChooseUnit(playerIndexes.AttackerIndex, _view);
        Unit defender = _teamManagerController.ChooseUnit(playerIndexes.DefenderIndex, _view);
        
        return new RoundInfo(attacker, defender);
    }
    
    private void ReportRoundStart(RoundInfo roundInfo, PlayerIndexes playerIndexes)
    {
        string attackerName = CombatHelper.GetPlayerName(playerIndexes.AttackerIndex);
        
        _view.ReportRound(_roundCounter, roundInfo, attackerName);
    }

    private void ManageRoundEnd(RoundInfo roundInfo, PlayerIndexes playerIndexes)
    {
        _view.ReportRoundSummary(roundInfo);
        _teamManagerController.CheckUnitsHealth(roundInfo, playerIndexes.AttackerIndex, playerIndexes.DefenderIndex);
    }
}
