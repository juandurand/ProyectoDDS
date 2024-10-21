using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.PersonalizedInterfaces
{
    public class UnitData
    {
        private readonly Dictionary<UnitDataKey, object> _data;

        public UnitData()
        {
            _data = new Dictionary<UnitDataKey, object>
            {
                { UnitDataKey.Name, "" },
                { UnitDataKey.Weapon, "" },
                { UnitDataKey.Gender, "" },
                { UnitDataKey.DeathQuote, "" },
                { UnitDataKey.Hp, 0 },
                { UnitDataKey.Atk, 0 },
                { UnitDataKey.Spd, 0 },
                { UnitDataKey.Def, 0 },
                { UnitDataKey.Res, 0 },
                { UnitDataKey.Skills, new StringList() }
            };
        }

        public string GetString(UnitDataKey key)
        {
            return _data[key].ToString();
        }

        public int GetInt(UnitDataKey key)
        {
            return (int)_data[key];
        }

        public T GetEnum<T>(UnitDataKey key) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), _data[key].ToString());
        }

        public StringList GetStringList(UnitDataKey key)
        {
            return (StringList)_data[key];
        }

        public void Set(UnitDataKey key, object value)
        {
            _data[key] = value;
        }
    }
}