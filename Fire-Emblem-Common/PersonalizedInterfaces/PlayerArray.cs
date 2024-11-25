using Fire_Emblem_Common.Exceptions;

namespace Fire_Emblem_Common.PersonalizedInterfaces
{
    public class PlayerArray
    {
        private readonly UnitList[] _playerArray = new UnitList[2];
        
        public void AddUnitList(UnitList unitList, int index)
        {
            CheckIndex(index);
            _playerArray[index] = unitList;
        }
        
        private void CheckIndex(int index)
        {
            if (index < 0 || index >= _playerArray.Length)
            {
                throw new IndexOutOfRangeInPlayerArrayException("Índice fuera del rango válido en el PlayerArray.");
            }
        }
        
        public UnitList GetUnitList(int index)
        {
            CheckIndex(index);
            return _playerArray[index];
        }
    }
}