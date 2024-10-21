using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Effects;
using Fire_Emblem_Common.Exceptions;

namespace Fire_Emblem_Common.PersonalizedInterfaces
{
    public class EffectByUnitType
    {
        private readonly Dictionary<UnitRole, List<Effect>> _effectsByUnitType;

        public EffectByUnitType()
        {
            _effectsByUnitType = new Dictionary<UnitRole, List<Effect>>()
            {
                { UnitRole.Unit, new List<Effect>() },
                { UnitRole.Rival, new List<Effect>() },
                { UnitRole.Both, new List<Effect>() }
            };
        }

        public void AddEffect(UnitRole role, Effect effect)
        {
            _effectsByUnitType[role].Add(effect);
        }
        
        public IEnumerable<Effect> GetAllEffects()
        {
            return _effectsByUnitType.Values.SelectMany(effects => effects);
        }
        
        public UnitRole GetUnitRoleForEffect(Effect effect)
        {
            foreach (var kvp in _effectsByUnitType)
            {
                if (kvp.Value.Contains(effect))
                {
                    return kvp.Key;
                }
            }
            throw new InvalidOperationInDictionaryException("El efecto no está asociado a ningún UnitRole.");
        }
    }
}