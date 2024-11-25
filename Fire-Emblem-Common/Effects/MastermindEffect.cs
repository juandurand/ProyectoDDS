using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Models;

namespace Fire_Emblem_Common.Effects;

public class MastermindEffect:Effect
{
    private readonly double _percentageOfBonusOrPenalty;

    public MastermindEffect()
        : base(EffectsApplyOrder.ThirdOrder)
    {
        _percentageOfBonusOrPenalty = 0.8;
    }

    public override void ApplyEffect(Unit unit)
    {
        int extraDamage = GetExtraDamage(unit);
        
        unit.DamageEffects.Bonus += extraDamage;
    }
    
    private int GetExtraDamage(Unit unit)
    {
        int extraDamage = 0;
        
        extraDamage += GetSkillOwnerBonus(unit);
        extraDamage += GetOpponentPenalty(unit.ActualOpponent);
        
        return extraDamage;
    }
    
    private int GetSkillOwnerBonus(Unit unit)
    {
        int skillOwnerBonus = 0;
        if (!unit.Atk.BonusNeutralized)
        {
            skillOwnerBonus += unit.Atk.Bonus;
        }
        if (!unit.Spd.BonusNeutralized)
        {
            skillOwnerBonus += unit.Spd.Bonus;
        }
        if (!unit.Def.BonusNeutralized)
        {
            skillOwnerBonus += unit.Def.Bonus;
        }
        if (!unit.Res.BonusNeutralized)
        {
            skillOwnerBonus += unit.Res.Bonus;
        }
        skillOwnerBonus =  Convert.ToInt32(Math.Floor(skillOwnerBonus * _percentageOfBonusOrPenalty));
        return skillOwnerBonus;
    }
    
    private int GetOpponentPenalty(Unit opponent)
    {
        int opponentPenalty = 0;
        if (!opponent.Atk.PenaltyNeutralized)
        {
            opponentPenalty += opponent.Atk.Penalty;
        }
        if (!opponent.Spd.PenaltyNeutralized)
        {
            opponentPenalty += opponent.Spd.Penalty;
        }
        if (!opponent.Def.PenaltyNeutralized)
        {
            opponentPenalty += opponent.Def.Penalty;
        }
        if (!opponent.Res.PenaltyNeutralized)
        {
            opponentPenalty += opponent.Res.Penalty;
        }
        opponentPenalty =  Convert.ToInt32(Math.Floor(opponentPenalty * _percentageOfBonusOrPenalty));
        return opponentPenalty;
    }
}