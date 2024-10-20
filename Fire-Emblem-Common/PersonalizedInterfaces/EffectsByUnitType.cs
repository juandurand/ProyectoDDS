using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Effects;

namespace Fire_Emblem_Common.PersonalizedInterfaces
{
    public class EffectByUnitType
    {
        private readonly Dictionary<UnitRole, List<Effectt>> _effectsByUnitType;

        public EffectByUnitType()
        {
            _effectsByUnitType = new Dictionary<UnitRole, List<Effectt>>()
            {
                { UnitRole.Unit, new List<Effectt>() },
                { UnitRole.Rival, new List<Effectt>() },
                { UnitRole.Both, new List<Effectt>() }
            };
        }

        public void AddEffect(UnitRole role, Effectt effect)
        {
            if (_effectsByUnitType.ContainsKey(role))
            {
                _effectsByUnitType[role].Add(effect);
            }
        }
        
        public IEnumerable<Effectt> GetAllEffects()
        {
            return _effectsByUnitType.Values.SelectMany(effects => effects);
        }
        
        public UnitRole GetUnitRoleForEffect(Effectt effect)
        {
            foreach (var kvp in _effectsByUnitType)
            {
                if (kvp.Value.Contains(effect))
                {
                    return kvp.Key;
                }
            }
            // Lanzar una excepción si el efecto no se encuentra
            throw new InvalidOperationException("El efecto no está asociado a ningún UnitRole.");
        }
    }
}