using System.Collections;

namespace Fire_Emblem_Common.PersonalizedInterfaces;

public class StringList : IEnumerable<string>
{
    private readonly List<string> _stringList = new List<string>();
    
    public void Add(string line) => _stringList.Add(line);

    public int Count => _stringList.Count;
    
    public string Get(int index) => _stringList[index];
    
    public IEnumerator<string> GetEnumerator()
    {
        return _stringList.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
