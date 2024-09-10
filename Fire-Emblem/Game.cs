using Fire_Emblem_View;
namespace Fire_Emblem;

public class Game
{
    private readonly View _view;
    private readonly LoadingFunctions _loader;
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _loader = new LoadingFunctions(_view, teamsFolder);
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