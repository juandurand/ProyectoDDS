namespace Fire_Emblem_Common.EDDs.Models;

public class PlayerIndexes
{
    public int AttackerIndex { get; }
    public int DefenderIndex { get; }
    
    public PlayerIndexes(int attackerIndex, int defenderIndex)
    {
        AttackerIndex = attackerIndex;
        DefenderIndex = defenderIndex;
    }
}