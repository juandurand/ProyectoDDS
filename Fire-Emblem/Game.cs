using Fire_Emblem_View.PersonalizedViews;
using Fire_Emblem_View.ViewLibrary;
using Fire_Emblem_Common.TeamLoading;
using Fire_Emblem_View;

namespace Fire_Emblem;

public class Game
{
    private readonly IViewManager _view;
    private readonly string _teamsFolder;
    private readonly TeamLoaderController _teamLoaderController;
    
    public Game(View view, string teamsFolder)
    {
        _view = new FireEmblemConsoleView(view);
        _teamsFolder = teamsFolder;
        _teamLoaderController = new TeamLoaderController(_view, new TeamParser());
    }

    public Game(FireEmblemGuiView view)
    {
        _view = view;
        _teamsFolder = "";
        _teamLoaderController = new TeamLoaderController(_view, new TeamParser());
    }

    public void Play()
    {
        string teamFileName = _view.SelectTeamFile(_teamsFolder);
        
        if (IsTeamFileValid(teamFileName))
        {
            StartCombat();
        }
        else
        {
            _view.ReportInvalidTeamSelection();
        }
    }
    
    private bool IsTeamFileValid(string teamFileName)
    {
        _teamLoaderController.ParsePlayersInfo(teamFileName);
        return _teamLoaderController.IsTeamValid();
    }

    private void StartCombat()
    {
        CombatController combatController = new CombatController(_teamLoaderController.GetPlayerOneUnitsInfo(),
                                                                 _teamLoaderController.GetPlayerTwoUnitsInfo(), 
                                                                 _view);
        combatController.SimulateCombat();
        combatController.ReportWinner();
    }
}