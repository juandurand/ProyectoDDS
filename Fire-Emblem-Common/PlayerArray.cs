namespace Fire_Emblem_Common
{
    public class PlayerArray
    {
        private readonly UnitList[] _playerArray = new UnitList[2];
        
        public void Add(UnitList unitList, int index)
        {
            if (index < 0 || index >= _playerArray.Length)
            {
                throw new IndexOutOfRangeException("Índice fuera del rango válido.");
            }
            _playerArray[index] = unitList;
        }
        
        public UnitList Get(int index)
        {
            if (index < 0 || index >= _playerArray.Length)
            {
                throw new IndexOutOfRangeException("Índice fuera del rango válido.");
            }
            return _playerArray[index];
        }
    }
}