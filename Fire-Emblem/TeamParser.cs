using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem;

public class TeamParser
{
    public readonly string testFolder;
    private bool _isPlayerOne = false;
    private bool _isPlayerTwo = false;

    public TeamParser(string folder)
    {
        testFolder = folder;
    }
    
    public (StringList Player1Lines, StringList Player2Lines) ParseTeamsFile(string fileName)
    {
        var lines = File.ReadLines($"{testFolder}/{fileName}");
        return GetTeamsLines(lines);
    }

    private (StringList Player1Lines, StringList Player2Lines) GetTeamsLines(IEnumerable<string> lines)
    {
        var playerOneInfo = new StringList();
        var playerTwoInfo = new StringList();

        foreach (var line in lines)
        {
            if (UpdatePlayersFlag(line))
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

    private bool UpdatePlayersFlag(string line)
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