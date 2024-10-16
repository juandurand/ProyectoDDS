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
    
    public void InitiateCombatAndAnnounceWinner()
    {
        RunCombatRounds();
        AnnounceWinner();
    }

    private void RunCombatRounds()
    {
        while (_teamManager.AreTeamsAlive())
        {
            ProcessCombatRound();
            _roundCounter++;
        }
    }

    private void AnnounceWinner()
    {
        _view.AnnounceWinner(_teamManager.GetPlayersUnits());
    }

    private void ProcessCombatRound()
    {
        RoundInfo roundInfo = GetRoundInfo();
        
        AnnounceRoundStart(roundInfo);
        SimulateRound(roundInfo);
        AnnounceAndManageRoundEnd(roundInfo);
    }
    
    private RoundInfo GetRoundInfo()
    {
        (int attackerIndex, int defenderIndex) = CombatHelper.GetAttackerDefenderIndex(_roundCounter);
        
        Unit attacker = _teamManager.ChooseUnit(attackerIndex, _view);
        Unit defender = _teamManager.ChooseUnit(defenderIndex, _view);
        
        return new RoundInfo(attacker, defender);
    }
    
    private void AnnounceRoundStart(RoundInfo roundInfo)
    {
        int attackerIndex = CombatHelper.GetAttackerDefenderIndex(_roundCounter).Item1;
        _view.AnnounceRound(_roundCounter, roundInfo, CombatHelper.GetPlayerName(attackerIndex));
    }

    private void SimulateRound(RoundInfo roundInfo)
    {
        _round.SimulateRound(roundInfo);
    }

    private void AnnounceAndManageRoundEnd(RoundInfo roundInfo)
    {
        (int attackerIndex, int defenderIndex) = CombatHelper.GetAttackerDefenderIndex(_roundCounter);
        _view.ReportRoundSummary(roundInfo);
        _teamManager.CheckUnitsHealth(roundInfo, attackerIndex, defenderIndex);
    }
}
