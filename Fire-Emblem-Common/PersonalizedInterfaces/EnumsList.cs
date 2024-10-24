using System.Collections;

namespace Fire_Emblem_Common.PersonalizedInterfaces;

public class EnumList<T> : IEnumerable<T> where T : Enum
{
    private readonly List<T> _enums;
    
    public EnumList(IEnumerable<T> initialValues )
    {
        _enums = new List<T>(initialValues);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _enums.GetEnumerator();
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
