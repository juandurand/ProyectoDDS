namespace Fire_Emblem_Common;

public class HealthStatus
{
    public int HpBaseValue;
    public int ActualHpValue;
    
    public HealthStatus(int initialValue)
    {
        HpBaseValue = initialValue;
        ActualHpValue = initialValue;
    }
}