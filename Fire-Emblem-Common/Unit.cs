namespace Fire_Emblem_Common;

public class Unit
{
    public readonly string Name;
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

    public Unit(Dictionary<string, object> unitData)
    {
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
        if (attackType == "First Attack")
        {
            return Atk + AtkBonus + AtkFirstAttackBonus - AtkPenalty;
        }
        if (attackType == "Counter Attack")
        {
            return Atk + AtkBonus - AtkPenalty;
        }
        return Atk + AtkBonus + AtkFollowUpBonus - AtkPenalty - AtkFollowUpPenalty;
    }

    public int GetTotalSpd()
    {
        return Spd + SpdBonus - SpdPenalty;
    }

    public int GetTotalDef(string attackType)
    {
        if (attackType == "First Attack")
        {
            return Def + DefBonus - DefFirstAttackPenalty - DefPenalty;
        }
        return Def + DefBonus - DefPenalty;
    }

    public int GetTotalRes(string attackType)
    {
        if (attackType == "First Attack")
        {
            return Res + ResBonus - ResFirstAttackPenalty - ResPenalty;
        }
        return Res + ResBonus - ResPenalty;
    }
    
}