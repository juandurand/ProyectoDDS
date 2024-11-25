namespace Fire_Emblem_Common.Helpers;

public static class CombatHelper
{
    public static int GetAttackerIndex(int roundCounter)
    {
        int numberTwo = 2;
        return (roundCounter + 1) % numberTwo;
    }

    public static int GetDefenderIndex(int roundCounter)
    {
        int numberTwo = 2;
        return roundCounter % numberTwo;
    }

    public static string GetPlayerName(int playerIndex)
    {
        return playerIndex == 0 ? "Player 1" : "Player 2";
    }
}
