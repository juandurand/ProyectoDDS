using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem_Common.TeamLoading;

public class TeamParser
{
    public readonly string TestFolder;
    private bool _isPlayerOne;
    private bool _isPlayerTwo;
    public StringList PlayerOneInfo;
    public StringList PlayerTwoInfo;

    public TeamParser(string folder)
    {
        TestFolder = folder;
        PlayerOneInfo = new StringList();
        PlayerTwoInfo = new StringList();
    }
    
    public void ParseTeamsFile(string fileName)
    {
        var lines = File.ReadLines($"{TestFolder}/{fileName}");
        
        foreach (var line in lines)
        {
            if (HasPlayersFlagsChanged(line))
            {
                continue;
            }
            if (_isPlayerOne)
            {
                PlayerOneInfo.AddString(line);
            }
            else if (_isPlayerTwo)
            {
                PlayerTwoInfo.AddString(line);
            }
        }
    }

    private bool HasPlayersFlagsChanged(string line)
    {
        switch (line)
        {
            case "Player 1 Team":
                _isPlayerOne = true;
                _isPlayerTwo = false;
                return true;

            case "Player 2 Team":
                _isPlayerOne = false;
                _isPlayerTwo = true;
                return true;

            default:
                return false;
        }
    }
}