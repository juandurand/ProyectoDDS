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

    private bool UnitLoader(List<Tuple<string, List<string>>>)
    {
        
    }
}