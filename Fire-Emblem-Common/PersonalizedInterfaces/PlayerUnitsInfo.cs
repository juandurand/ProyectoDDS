using System.Collections;

namespace Fire_Emblem_Common.PersonalizedInterfaces
{
    public class PlayerUnitsInfo : IEnumerable<Tuple<string, StringList>>
    {
        private readonly List<Tuple<string, StringList>> _playerInfo = new List<Tuple<string, StringList>>();
        
        public void Add(Tuple<string, StringList> unitInfo) => _playerInfo.Add(unitInfo);
        
        public bool IsDuplicateUnit(string name)
        {
            return _playerInfo.Any(unitInfo => unitInfo.Item1 == name);
        }
        
        public IEnumerator<Tuple<string, StringList>> GetEnumerator()
        {
            return _playerInfo.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }
    }
}