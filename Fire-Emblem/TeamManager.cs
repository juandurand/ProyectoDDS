using Fire_Emblem_Common;
using Fire_Emblem_View;
namespace Fire_Emblem;

public class TeamManager
{
    private readonly List<Unit>[] _playersUnits;

    public TeamManager((List<Tuple<string, List<string>>>, List<Tuple<string, List<string>>>) playersInfo)
    {
        _playersUnits = new List<Unit>[2]
        {
            UnitsLoader.LoadUnits(playersInfo.Item1),
            UnitsLoader.LoadUnits(playersInfo.Item2)
        };
    }

    public Unit ChooseUnit(int playerIndex, View view)
    {
        view.DisplayPlayerTeam(playerIndex + 1, _playersUnits[playerIndex]);
        int unitIndex = Convert.ToInt32(view.ReadLine());
        return _playersUnits[playerIndex][unitIndex];
    }

    public void CheckUnitsHealth(Dictionary<string, Unit> roundInfo, int attackerIndex, int defenderIndex)
    {
        RemoveUnitIfDead(roundInfo["Attacker"], attackerIndex);
        RemoveUnitIfDead(roundInfo["Defender"], defenderIndex);
    }

    private void RemoveUnitIfDead(Unit unit, int playerIndex)
    {
        if (!unit.HealthStatus.IsUnitAlive())
        {
            _playersUnits[playerIndex].Remove(unit);
        }
    }

    public bool AreTeamsAlive() => _playersUnits[0].Count > 0 && _playersUnits[1].Count > 0;

    public List<Unit>[] GetPlayersUnits() => _playersUnits;
}
