using Fire_Emblem_View;
namespace Fire_Emblem;

public class Combat
{
    private List<Unit> _player1Units;
    private List<Unit> _player2Units;

    public Combat((List<Tuple<string, List<string>>>, List<Tuple<string, List<string>>>) playersInfo)
    {
        _player1Units = UnitLoader(playersInfo.Item1);
        _player2Units = UnitLoader(playersInfo.Item2);
    }

    private List<Unit> UnitLoader(List<Tuple<string, List<string>>> playerInfo)
    {
        List<Unit> playerUnits = new List<Unit>();
        foreach (var unitInfo in playerInfo)
        {
            Unit unit = LoadingFunctions.CreateUnit(unitInfo.Item1, unitInfo.Item2);
            playerUnits.Add(unit);
        }
        return playerUnits;
    }

    public void Prueba(View view)
    {
        foreach (var unit in _player2Units)
        {
            view.WriteLine(unit.Name);
        }
    }
}