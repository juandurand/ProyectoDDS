using Fire_Emblem_Common.EDDs.Models;
using Fire_Emblem_Common.EDDs.Managers;
using Fire_Emblem_View.PersonalizedViews;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.TeamLoading;

namespace Fire_Emblem;

public class TeamManagerController
{
    private readonly PlayerArray _playersUnits;

    public TeamManagerController((PlayerUnitsInfo, PlayerUnitsInfo) playersInfo)
    {
        _playersUnits = new PlayerArray();
        _playersUnits.Add(UnitsLoader.LoadUnits(playersInfo.Item1), 0);
        _playersUnits.Add(UnitsLoader.LoadUnits(playersInfo.Item2), 1);
        SetUnitsTeam(_playersUnits.Get(0));
        SetUnitsTeam(_playersUnits.Get(1));
    }

    private void SetUnitsTeam(UnitList team)
    // Más de dos niveles de indentación
    {
        for (int j = 0; j < team.Count; j++)
        {
            Unit unit = team.Get(j);
            for (int k = 0; k < team.Count; k++)
            {
                if (k != j)
                {
                    Unit teamMate = team.Get(k);
                    unit.Team.Add(teamMate);
                }
            }
        }
    }

    public Unit ChooseUnit(int playerIndex, GeneralView view)
    {
        view.DisplayPlayerTeam(playerIndex + 1, _playersUnits.Get(playerIndex));
        
        int unitIndex = Convert.ToInt32(view.ReadLine());
        
        return _playersUnits.Get(playerIndex).Get(unitIndex);
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
            _playersUnits.Get(playerIndex).Remove(unit);
            RemoveDeadUnitFromTeam(unit, playerIndex);
        }
    }
    
    private void RemoveDeadUnitFromTeam(Unit deadUnit, int playerIndex)
    {
        for (int i = 0; i < _playersUnits.Get(playerIndex).Count; i++)
        {
            Unit unit = _playersUnits.Get(playerIndex).Get(i);
            unit.Team.Remove(deadUnit);
        }
    }

    public bool AreTeamsAlive() => _playersUnits.Get(0).Count > 0 && _playersUnits.Get(1).Count > 0;

    public PlayerArray GetPlayersUnits() => _playersUnits;
}
