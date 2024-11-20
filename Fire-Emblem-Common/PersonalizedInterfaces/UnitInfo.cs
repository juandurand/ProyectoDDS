namespace Fire_Emblem_Common.PersonalizedInterfaces
{
    public class UnitInfo
    {
        private Tuple<string, StringList> _unitInfo;
        
        public void SetUnitInfo(string unitName, StringList skills)
        {
            _unitInfo = new Tuple<string, StringList>(unitName, skills);
        }
        
        public string GetUnitName()
        {
            return _unitInfo.Item1;
        }
        
        public StringList GetUnitSkills()
        {
            return _unitInfo.Item2;
        }
    }
}