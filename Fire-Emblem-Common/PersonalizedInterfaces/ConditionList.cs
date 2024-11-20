using Fire_Emblem_Common.Conditions;
using System.Collections;

namespace Fire_Emblem_Common.PersonalizedInterfaces;

public class ConditionList : IEnumerable<Condition>
{
    private readonly List<Condition> _conditions = new List<Condition>();

    public void Add(Condition condition) => _conditions.Add(condition);
    
    public Condition GetCondition(int index) => _conditions[index];
    
    public int Count => _conditions.Count;
    
    public IEnumerator<Condition> GetEnumerator()
    {
        return _conditions.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}