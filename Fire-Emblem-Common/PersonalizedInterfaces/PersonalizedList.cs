using System.Collections;

namespace Fire_Emblem_Common.PersonalizedInterfaces;

public class PersonalizedList : IEnumerable<Object>
{
    private readonly List<Object> _list = new List<Object>();

    public void Add(Object item) => _list.Add(item);
    
    public Object Get(int index) => _list[index];
    
    public int Count => _list.Count;
    
    public IEnumerator<Object> GetEnumerator()
    {
        return _list.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}