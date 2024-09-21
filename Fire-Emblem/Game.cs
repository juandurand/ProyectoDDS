using Fire_Emblem_View;
namespace Fire_Emblem;

public class Game
{
    private readonly View _view;
    private readonly TeamLoader _teamLoader;
    private readonly string _teamsFolder;
    
    public Game(View view, string teamsFolder)
    {
        TeamParser parser = new TeamParser(teamsFolder);
        
        _view = view;
        _teamsFolder = teamsFolder;
        _teamLoader = new TeamLoader(_view, parser);
    }

    public void Play()
    {
        _view.DisplayTeamSelection(_teamsFolder);
        
        if (!_teamLoader.IsTeamValid(_teamLoader.ChargePlayersInfo()))
        {
            _view.WriteLine(("Archivo de equipos no válido"));
        }
        else
        {
            StartCombat();
        }
    }

    private void StartCombat()
    {
        Combat combat = new Combat(_teamLoader.GetPlayers(), _view);
        combat.InitiateCombat();
    }
}