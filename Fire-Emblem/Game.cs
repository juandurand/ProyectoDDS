using Fire_Emblem_View;
namespace Fire_Emblem;

public class Game
{
    private View _view;
    private string _teamsFolder;
    private LoadingFunctions _loader;
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
        _loader = new LoadingFunctions(_view, _teamsFolder);
    }

    public void Play()
    {
        _loader.DisplayFileOptions();
        
        if (!_loader.IsTeamValid(_loader.ChargePlayersInfo()))
        {
            _view.WriteLine(("Archivo de equipos no válido"));
        }
        else
        {
            Combat combat = new Combat(_loader.GetPlayers(), _view);
            combat.InitiateCombat();
        }
    }
}