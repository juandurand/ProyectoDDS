using Fire_Emblem_Common.EDDs.Models;
using System.Collections;

namespace Fire_Emblem_Common.PersonalizedInterfaces;

public class UnitList : IEnumerable<Unit>
{
    private readonly List<Unit> _units = new List<Unit>();

    public void AddUnit(Unit unit) => _units.Add(unit);
    
    public void RemoveUnit(Unit unit) => _units.Remove(unit);
    
    public int Count => _units.Count;
    
    public Unit GetUnit(int index) => _units[index];
    
    public IEnumerator<Unit> GetEnumerator()
    {
        return _units.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
