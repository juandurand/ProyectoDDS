using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Effects;

public class DefBonusEffect:Effect
{
    private readonly int _defBonus;

    public DefBonusEffect(int defBonus)
        : base(EffectsApplyOrder.FirstOrder)
    {
        _defBonus = defBonus;
    }

    public override void ApplyEffect(Unit unit)
    {
        unit.Def.Bonus += _defBonus;
    }
}