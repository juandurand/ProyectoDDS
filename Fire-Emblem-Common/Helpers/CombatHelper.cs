namespace Fire_Emblem_Common.Helpers;

public static class CombatHelper
{
    public static int GetAttackerIndex(int roundCounter)
    {
        return (roundCounter + 1) % 2;
    }

    public static int GetDefenderIndex(int roundCounter)
    {
        return roundCounter % 2;
    }

    public static string GetPlayerName(int playerIndex)
    {
        return playerIndex == 0 ? "Player 1" : "Player 2";
    }
}
