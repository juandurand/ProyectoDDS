using Fire_Emblem_View.PersonalizedViews;
using Fire_Emblem_Common.TeamLoading;

namespace Fire_Emblem;

public class Game
{
    private readonly GeneralView _view;
    private readonly TeamLoaderController _teamLoaderController;
    private readonly string _teamsFolder;
    
    public Game(GeneralView view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        _teamLoaderController = new TeamLoaderController(_view, new TeamParser(teamsFolder));
    }

    public void Play()
    {
        _view.DisplayTeamSelection(_teamsFolder);
        
        if (IsTeamFileValid())
        {
            StartCombat();
        }
        else
        {
            _view.ReportInvalidTeamSelection();
        }
    }
    
    private bool IsTeamFileValid()
    {
        _teamLoaderController.ParsePlayersInfo();
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