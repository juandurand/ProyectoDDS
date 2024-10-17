namespace Fire_Emblem;

public class TeamParser
{
    public readonly string testFolder;
    private bool _isPlayerOne = false;
    private bool _isPlayerTwo = true;

    public TeamParser(string folder)
    {
        testFolder = folder;
    }
    
    public (List<string> Player1, List<string> Player2) ParseTeamFile(string fileName)
    {
        var lines = File.ReadLines($"{testFolder}/{fileName}");
        return ProcessTeamLines(lines);
    }

    private (List<string> Player1, List<string> Player2) ProcessTeamLines(IEnumerable<string> lines)
    {
        var playerOneInfo = new List<string>();
        var playerTwoInfo = new List<string>();
        

        foreach (var line in lines)
        {
            if (UpdatePlayerFlags(line))
            {
                continue;
            }

            if (_isPlayerOne)
            {
                playerOneInfo.Add(line);
            }
            else if (_isPlayerTwo)
            {
                playerTwoInfo.Add(line);
            }
        }

        return (playerOneInfo, playerTwoInfo);
    }

    private bool UpdatePlayerFlags(string line)
    {
        if (line == "Player 1 Team")
        {
            _isPlayerOne = true;
            _isPlayerTwo = false;
            return true;
        }
        if (line == "Player 2 Team")
        {
            _isPlayerOne = false;
            _isPlayerTwo = true;
            return true;
        }
    
        return false;
    }

}