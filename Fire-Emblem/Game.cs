using Fire_Emblem_View.ViewLibrary;
using Fire_Emblem_Common.TeamLoading;

namespace Fire_Emblem;

public class Game
{
    private readonly View _view;
    private readonly TeamLoaderController _teamLoaderController;
    private readonly string _teamsFolder;
    
    public Game(View view, string teamsFolder)
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
            _view.AnnounceInvalidTeamSelection();
        }
    }
    
    private bool IsTeamFileValid()
    {
        return _teamLoaderController.IsTeamValid(_teamLoaderController.ChargePlayersInfo());
    }

    private void StartCombat()
    {
        CombatController combatController = new CombatController(_teamLoaderController.GetPlayers(), _view);
        combatController.SimulateCombat();
        combatController.AnnounceWinner();
    }
}