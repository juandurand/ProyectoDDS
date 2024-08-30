using Fire_Emblem_View;
namespace Fire_Emblem;

public class Game
{
    private View _view;
    private string _teamsFolder;
    
    public Game(View view, string teamsFolder)
    {
        _view = view;
        _teamsFolder = teamsFolder;
    }

    public void Play()
    {
        // SECCIÓN DE CARGA DE EQUIPOS
        LoadingFunctions loader = new LoadingFunctions(_view, _teamsFolder);
        loader.DisplayFileOptions();
        
        if (!loader.IsTeamValid(loader.ChargePlayersInfo()))
        {
            _view.WriteLine(("Archivo de equipos no válido"));
        }
        else
        {
            _view.WriteLine(("Archivo de equipos no válido"));
        }
    }
}