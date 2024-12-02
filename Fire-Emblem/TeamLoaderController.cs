using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.TeamLoading;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class TeamLoaderController
{
    private readonly IViewManager _view;
    private readonly TeamParser _parser;
    private readonly TeamValidator _validator;
    
    public TeamLoaderController(IViewManager view, TeamParser parser)
    {
        _view = view;
        _parser = parser;
        _validator = new TeamValidator();
    }

    public void ParsePlayersInfo(string fileName)
    {
        _parser.ParseTeamsFile(fileName);
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
