using Fire_Emblem_View.PersonalizedViews;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Exceptions;
using Fire_Emblem_Common.TeamLoading;

namespace Fire_Emblem;

public class TeamLoaderController
{
    private readonly GeneralView _view;
    private readonly TeamParser _parser;
    private readonly TeamValidator _validator;
    
    public TeamLoaderController(GeneralView view, TeamParser parser)
    {
        _view = view;
        _parser = parser;
        _validator = new TeamValidator();
    }

    public void ParsePlayersInfo()
    {
        string teamCode = _view.ReadLine().PadLeft(3, '0');
        string fileName = GetFileByCode(teamCode, _parser.TestFolder);

        CheckStringIsEmpty(fileName, teamCode);

        _parser.ParseTeamsFile(fileName);
    }

    private static string GetFileByCode(string teamCode, string folder)
    {
        var files = Directory.GetFiles(folder, $"{teamCode}*.txt");
        var path = files.FirstOrDefault();

        CheckStringIsEmpty(path, teamCode);

        return Path.GetFileName(path);
    }
    
    private static void CheckStringIsEmpty(string str, string teamCode)
    {
        if (string.IsNullOrEmpty(str))
        {
            throw new FileProcessingException($"El archivo para el equipo {teamCode} está vacío");
        }
    }
    
    public bool IsTeamValid()
    {
        return _validator.IsPlayerValid(_parser.PlayerOneInfo) && _validator.IsPlayerValid(_parser.PlayerTwoInfo);
    }
    
    public PlayerUnitsInfo GetPlayerOneUnitsInfo()
    {
        return _validator.GetPlayerInfo(_parser.PlayerOneInfo);
    }
    
    public PlayerUnitsInfo GetPlayerTwoUnitsInfo()
    {
        return _validator.GetPlayerInfo(_parser.PlayerTwoInfo);
    }
}    
