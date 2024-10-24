using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.EDDs.Models;

namespace Fire_Emblem_Common.Skills;

public interface ISkill
{
    void Apply(RoundInfo roundInfo, EffectsApplyOrder applyOrder);
}