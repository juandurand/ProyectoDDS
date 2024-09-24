namespace Fire_Emblem_Common;

public class Hp
{
    public int HpBaseValue;
    public int ActualHpValue;
    
    public Hp(int initialValue)
    {
        HpBaseValue = initialValue;
        ActualHpValue = initialValue;
    }
    
    public bool IsUnitAlive()
    {
        return ActualHpValue > 0;
    }
    
    public void DealDamage(int damage)
    {
        ActualHpValue -= damage;
        if (ActualHpValue < 0)
        {
            ActualHpValue = 0;
        }
    }
    
    public double GetHpPercentage()
    {
        return (double)ActualHpValue / HpBaseValue;
    }

    public void ApplyHpPlus15()
    {
        HpBaseValue += 15;
        ActualHpValue = HpBaseValue;
    }
}