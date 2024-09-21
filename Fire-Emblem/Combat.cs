using Fire_Emblem_Common;
using Fire_Emblem_View;
namespace Fire_Emblem;

public class Combat
{
    private readonly List<Unit>[] _playersUnits;
    private readonly View _view;
    private int _roundCounter = 1;
    private Round _round;

    public Combat((List<Tuple<string, List<string>>>, List<Tuple<string, List<string>>>) playersInfo, View view)
    {
        _playersUnits = new List<Unit>[2]
        {
            UnitsLoader.LoadUnits(playersInfo.Item1),
            UnitsLoader.LoadUnits(playersInfo.Item2)
        };
        _view = view;
        _round = new Round(view);
    }
    
    public void InitiateCombat()
    {
        while (_playersUnits[0].Count > 0 && _playersUnits[1].Count > 0)
        {
            ProcessCombatRound();
            _roundCounter++;
        }

        // Announce winner
        _view.AnnounceWinner(_playersUnits);
    }

    private void ProcessCombatRound()
    {
        Unit attackerUnit = ChooseUnit(GetAttackerIndex());
        Unit defenderUnit = ChooseUnit(GetDefenderIndex());
        
        _view.AnnounceRound(_roundCounter, attackerUnit, defenderUnit, GetPlayerName(GetAttackerIndex()));
        _round.SimulateRound(attackerUnit, defenderUnit);
        _view.ReportRoundSummary(attackerUnit, defenderUnit);
        SetLastOpponent(attackerUnit, defenderUnit);
        CheckInvolvedUnitsHealth(attackerUnit, defenderUnit);
    }
    
    private int GetAttackerIndex() => (_roundCounter + 1) % 2;
    
    private int GetDefenderIndex() => _roundCounter % 2;
    
    private static string GetPlayerName(int index) => index == 0 ? "Player 1" : "Player 2";

    private Unit ChooseUnit(int playerIndex)
    {
        _view.DisplayPlayerTeam(playerIndex + 1, _playersUnits[playerIndex]);
        int unitIndex = Convert.ToInt32(_view.ReadLine());
        return _playersUnits[playerIndex][unitIndex];
    }

    private void CheckInvolvedUnitsHealth(Unit attackerUnit, Unit defenderUnit)
    {
        CheckHealth(attackerUnit, GetAttackerIndex());
        CheckHealth(defenderUnit, GetDefenderIndex());
    }

    private void CheckHealth(Unit unit, int playerIndex)
    {
        if (unit.IsUnitAlive())
        {
            return;
        }
        _playersUnits[playerIndex].Remove(unit);
    }

    private static void SetLastOpponent(Unit attackerUnit, Unit defenderUnit)
    {
        attackerUnit.LastOpponent = defenderUnit;
        defenderUnit.LastOpponent = attackerUnit;
    }
}