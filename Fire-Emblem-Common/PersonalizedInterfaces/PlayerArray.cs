using Fire_Emblem_Common.Exceptions;

namespace Fire_Emblem_Common.PersonalizedInterfaces
{
    public class PlayerArray
    {
        private readonly UnitList[] _playerArray = new UnitList[2];
        
        public void Add(UnitList unitList, int index)
        {
            if (index < 0 || index >= _playerArray.Length)
            {
                throw new IndexOutOfRangeInPlayerArrayException("Índice fuera del rango válido en el PlayerArray.");
            }
            _playerArray[index] = unitList;
        }
        
        public UnitList Get(int index)
        {
            if (index < 0 || index >= _playerArray.Length)
            {
                throw new IndexOutOfRangeInPlayerArrayException("Índice fuera del rango válido en el PlayerArray.");
            }
            return _playerArray[index];
        }
    }
}