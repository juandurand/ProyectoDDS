namespace Fire_Emblem;

public class TeamParser
{
    public readonly string testFolder;

    public TeamParser(string folder)
    {
        testFolder = folder;
    }
    
    public (List<string> Player1, List<string> Player2) ParseTeamFile(string fileName)
    {
        var playerOneInfo = new List<string>();
        var playerTwoInfo = new List<string>();
        bool isPlayerOne = false, isPlayerTwo = false;

        foreach (var line in File.ReadLines($"{testFolder}/{fileName}"))
        {
            if (line == "Player 1 Team") isPlayerOne = true;
            else if (line == "Player 2 Team") { isPlayerOne = false; isPlayerTwo = true; }
            else if (isPlayerOne) playerOneInfo.Add(line);
            else if (isPlayerTwo) playerTwoInfo.Add(line);
        }

        return (playerOneInfo, playerTwoInfo);
    }
}