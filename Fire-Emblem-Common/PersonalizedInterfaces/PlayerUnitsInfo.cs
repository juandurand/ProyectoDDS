using System.Collections;

namespace Fire_Emblem_Common.PersonalizedInterfaces
{
    public class PlayerUnitsInfo : IEnumerable<UnitInfo>
    {
        private readonly List<UnitInfo> _playerInfo = new List<UnitInfo>();
        
        public void AddUnitInfo(UnitInfo unitInfo) => _playerInfo.Add(unitInfo);
        
        public bool IsDuplicateUnit(string name)
        {
            return _playerInfo.Any(unitInfo => unitInfo.GetUnitName() == name);
        }
        
        public IEnumerator<UnitInfo> GetEnumerator()
        {
            return _playerInfo.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }
    }
}