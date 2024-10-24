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
        }
    }

    public bool AreTeamsAlive() => _playersUnits.Get(0).Count > 0 && _playersUnits.Get(1).Count > 0;

    public PlayerArray GetPlayersUnits() => _playersUnits;
}
