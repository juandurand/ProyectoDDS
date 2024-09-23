namespace Fire_Emblem_Common;

public class Unit
{
    public readonly string Name;
    public readonly string PersonalizedName;
    public readonly string Weapon;
    public readonly string Gender;
    public readonly string DeathQuote;
    public readonly int Atk;
    public readonly int Spd;
    public readonly int Def;
    public readonly int Res;
    public int Hp;
    public int ActualHp;
    public List<string> SkillsNames;
    public List<Skill> Skills = new List<Skill>();
    public Unit LastOpponent;

    public int AtkBonus;
    public int SpdBonus;
    public int DefBonus;
    public int ResBonus;

    public int AtkPenalty;
    public int SpdPenalty;
    public int DefPenalty;
    public int ResPenalty;

    public int AtkFirstAttackBonus;
    
    public int DefFirstAttackPenalty;
    public int ResFirstAttackPenalty;
    
    public int AtkFollowUpBonus;
    public int AtkFollowUpPenalty;

    public bool AtkBonusNeutralization;
    public bool SpdBonusNeutralization;
    public bool DefBonusNeutralization;
    public bool ResBonusNeutralization;

    public bool AtkPenaltyNeutralization;
    public bool SpdPenaltyNeutralization;
    public bool DefPenaltyNeutralization;
    public bool ResPenaltyNeutralization;

    public Unit(Dictionary<string, object> unitData)
    {
        PersonalizedName = (string)unitData["PersonalizedName"];
        Name = (string)unitData["Name"];
        Weapon = (string)unitData["Weapon"];
        Gender = (string)unitData["Gender"];
        DeathQuote = (string)unitData["DeathQuote"];
        Hp = (int)unitData["HP"];
        Atk = (int)unitData["Atk"];
        Spd = (int)unitData["Spd"];
        Def = (int)unitData["Def"];
        Res = (int)unitData["Res"];
        ActualHp = (int)unitData["HP"];
        SkillsNames = (List<string>)unitData["Skills"];

        LastOpponent = this;
        ResetBonus();
        ResetPenalty();
        CreateSkills();
    }

    private void CreateSkills()
    {
        foreach (string skillName in SkillsNames)
        {
            Skill skill = SkillFactory.CreateSkill(skillName, this);
            Skills.Add(skill);
        }
    }

    public void ResetBonus()
    {
        AtkBonus = 0;
        SpdBonus = 0;
        DefBonus = 0;
        ResBonus = 0;
        AtkFirstAttackBonus = 0;
        AtkFollowUpBonus = 0;
        AtkBonusNeutralization = false;
        SpdBonusNeutralization = false;
        DefBonusNeutralization = false;
        ResBonusNeutralization = false;
    }
    
    public void ResetPenalty()
    {
        AtkPenalty = 0;
        SpdPenalty = 0;
        DefPenalty = 0;
        ResPenalty = 0;
        DefFirstAttackPenalty = 0;
        ResFirstAttackPenalty = 0;
        AtkFollowUpPenalty = 0;
        AtkPenaltyNeutralization = false;
        SpdPenaltyNeutralization = false;
        DefPenaltyNeutralization = false;
        ResPenaltyNeutralization = false;
    }
    
    public bool IsUnitAlive()
    {
        
        return ActualHp > 0;
    }

    public void DealDamage(int damage)
    {
        ActualHp -= damage;
        if (ActualHp < 0)
        {
            ActualHp = 0;
        }
    }

    public double GetHpPercentage()
    {
        return (double)ActualHp / Hp;
    }

    public int GetTotalAtk(string attackType)
    {
        int totalAtk = Atk;
    
        if (!AtkBonusNeutralization)
        {
            totalAtk += AtkBonus;

            if (attackType == "First Attack")
            {
                totalAtk += AtkFirstAttackBonus;
            }
            else if (attackType == "Follow-Up")
            {
                totalAtk += AtkFollowUpBonus;
            }
        }
        
        if (!AtkPenaltyNeutralization)
        {
            totalAtk -= AtkPenalty;
            if (attackType != "First Attack")
            {
                totalAtk -= AtkFollowUpPenalty;
            }
        }

        return totalAtk;
    }

    public int GetTotalSpd()
    {
        int totalSpd = Spd;

        if (!SpdBonusNeutralization)
        {
            totalSpd += SpdBonus;
        }

        if (!SpdPenaltyNeutralization)
        {
            totalSpd -= SpdPenalty;
        }

        return totalSpd;
    }

    public int GetTotalDef(string attackType)
    {
        int totalDef = Def;

        if (!DefBonusNeutralization)
        {
            totalDef += DefBonus;
        }

        if (!DefPenaltyNeutralization)
        {
            if (attackType == "First Attack")
            {
                totalDef -= DefFirstAttackPenalty;
            }
            totalDef -= DefPenalty;
        }

        return totalDef;
    }


    public int GetTotalRes(string attackType)
    {
        int totalRes = Res;

        if (!ResBonusNeutralization)
        {
            totalRes += ResBonus;
        }

        if (!ResPenaltyNeutralization)
        {
            if (attackType == "First Attack")
            {
                totalRes -= ResFirstAttackPenalty;
            }
            totalRes -= ResPenalty;
        }

        return totalRes;
    }
    
}