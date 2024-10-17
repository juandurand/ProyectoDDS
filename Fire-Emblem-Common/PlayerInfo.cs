using System.Collections;

namespace Fire_Emblem_Common
{
    public class PlayerInfo : IEnumerable<Tuple<string, List<string>>>
    {
        private readonly List<Tuple<string, List<string>>> _playerInfo = new List<Tuple<string, List<string>>>();
        
        public void Add(Tuple<string, List<string>> unitInfo) => _playerInfo.Add(unitInfo);
        
        public bool IsDuplicateUnit(string name)
        {
            return _playerInfo.Any(unitInfo => unitInfo.Item1 == name);
        }
        
        public IEnumerator<Tuple<string, List<string>>> GetEnumerator()
        {
            return _playerInfo.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }
    }
}