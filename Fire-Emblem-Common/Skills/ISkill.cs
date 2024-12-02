using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Skills;

public interface ISkill
{
    string Name { get; }
    void Apply(RoundInfo roundInfo, EffectsApplyOrder applyOrder);
}