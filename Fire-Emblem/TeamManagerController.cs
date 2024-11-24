using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;
using Fire_Emblem_View.PersonalizedViews;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.TeamLoading;

namespace Fire_Emblem;

public class TeamManagerController
{
    private readonly PlayerArray _playersUnits;

    public TeamManagerController(PlayerUnitsInfo playerOneUnitsInfo, PlayerUnitsInfo playerTwoUnitsInfo)
    {
        _playersUnits = new PlayerArray();
        _playersUnits.AddUnitList(UnitsLoader.LoadUnits(playerOneUnitsInfo), 0);
        _playersUnits.AddUnitList(UnitsLoader.LoadUnits(playerTwoUnitsInfo), 1);
        
        SetUnitsTeam(_playersUnits.GetUnitList(0));
        SetUnitsTeam(_playersUnits.GetUnitList(1));
    }
    
    private void SetUnitsTeam(UnitList team)
    {
        for (int unitIndex = 0; unitIndex < team.Count; unitIndex++)
        {
            Unit unit = team.GetUnit(unitIndex);
            AddTeamMates(unit, team, unitIndex);
        }
    }

    private void AddTeamMates(Unit unit, UnitList team, int currentUnitIndex)
    {
        for (int teamMateIndex = 0; teamMateIndex < team.Count; teamMateIndex++)
        {
            if (teamMateIndex != currentUnitIndex)
            {
                Unit teamMate = team.GetUnit(teamMateIndex);
                unit.Team.AddUnit(teamMate);
            }
        }
    }

    public Unit ChooseUnit(int playerIndex, GeneralView view)
    {
        view.DisplayPlayerTeam(playerIndex + 1, _playersUnits.GetUnitList(playerIndex));
        
        int unitIndex = Convert.ToInt32(view.ReadLine());
        
        return _playersUnits.GetUnitList(playerIndex).GetUnit(unitIndex);
    }

    public void CheckUnitsHealth(RoundInfo roundInfo, int attackerIndex, int defenderIndex)
    {
        RemoveUnitIfDead(roundInfo.Attacker, attackerIndex);
        RemoveUnitIfDead(roundInfo.Defender, defenderIndex);
    }

    private void RemoveUnitIfDead(Unit unit, int playerIndex)
    {
        if (!HealthStatusManager.IsUnitAlive(unit.HealthStatus))
        {
            _playersUnits.GetUnitList(playerIndex).RemoveUnit(unit);
            RemoveDeadUnitFromTeam(unit, playerIndex);
        }
    }
    
    private void RemoveDeadUnitFromTeam(Unit deadUnit, int playerIndex)
    {
        for (int teamMateIndex = 0; teamMateIndex < _playersUnits.GetUnitList(playerIndex).Count; teamMateIndex++)
        {
            Unit unit = _playersUnits.GetUnitList(playerIndex).GetUnit(teamMateIndex);
            unit.Team.RemoveUnit(deadUnit);
        }
    }

    public bool AreTeamsAlive() => _playersUnits.GetUnitList(0).Count > 0 &&_playersUnits.GetUnitList(1).Count > 0;

    public PlayerArray GetPlayersUnits() => _playersUnits;
}
