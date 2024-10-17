using Fire_Emblem_View;
namespace Fire_Emblem;

public class Game
{
    private readonly View _view;
    private readonly TeamLoader _teamLoader;
    private readonly string _teamsFolder;
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        _teamLoader = new TeamLoader(_view, new TeamParser(teamsFolder));
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
        return _teamLoader.IsTeamValid(_teamLoader.ChargePlayersInfo());
    }

    private void StartCombat()
    {
        Combat combat = new Combat(_teamLoader.GetPlayers(), _view);
        combat.SimulateCombat();
        combat.AnnounceWinner();
    }
}