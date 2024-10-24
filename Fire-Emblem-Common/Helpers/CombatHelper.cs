namespace Fire_Emblem_Common.Helpers;

public static class CombatHelper
{
    public static (int, int) GetAttackerDefenderIndex(int roundCounter)
    {
        return ((roundCounter + 1) % 2, roundCounter % 2);
    }

    public static string GetPlayerName(int playerIndex)
    {
        return playerIndex == 0 ? "Player 1" : "Player 2";
    }
}
