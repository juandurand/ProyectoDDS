namespace Fire_Emblem;

public class Unit
{
    public string Name { get; set; }
    public string Weapon { get; set; }
    public string Gender { get; set; }
    public string DeathQuote { get; set; }
    public string HP { get; set; }
    public string Atk { get; set; }
    public string Spd { get; set; }
    public string Def { get; set; }
    public string Res { get; set; }
    
    public List<string> Skills;

    public bool IsUnitAlive()
    {
        return Stats["Actual Health"] > 0;
    }

    public void DealDamage(int damage)
    {
        Stats["Actual Health"] -= damage;
    }
    
    
}