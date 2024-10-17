
namespace Fire_Emblem_Common;

public class UnitList
{
    private readonly List<Unit> _units = new List<Unit>();

    public void Add(Unit unit) => _units.Add(unit);
    
    public void Remove(Unit unit) => _units.Remove(unit);
    
    public int Count => _units.Count;
    
    public Unit Get(int index) => _units[index];
}
