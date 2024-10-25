using Fire_Emblem_View.PersonalizedViews;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Exceptions;
using Fire_Emblem_Common.TeamLoading;

namespace Fire_Emblem

{
    public class TeamLoaderController
    {
        private PlayerUnitsInfo _player1UnitsInfo;
        private PlayerUnitsInfo _player2UnitsInfo;
        private readonly GeneralView _view;
        private readonly TeamParser _parser;
        private readonly TeamValidator _validator;
        
        public TeamLoaderController(GeneralView view, TeamParser parser)
        {
            _player1UnitsInfo = new PlayerUnitsInfo();
            _player2UnitsInfo = new PlayerUnitsInfo();
            _view = view;
            _parser = parser;
            _validator = new TeamValidator();
        }

        public (StringList Player1Lines, StringList Player2Lines) ChargePlayersInfo()
        {
            try
            {
                string teamCode = _view.ReadLine().PadLeft(3, '0');
                string fileName = FindFileByCode(teamCode, _parser.TestFolder);
        
                if (string.IsNullOrEmpty(fileName))
                {
                    throw new FileProcessingException($"No se encontró el archivo para el equipo: {teamCode}");
                }
                return _parser.ParseTeamsFile(fileName);
            }
            catch (FileProcessingException) 
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new FileProcessingException("Error inesperado al cargar la " +
                                                  "información de los equipos.", exception);
            }
        }

        private string FindFileByCode(string teamCode, string folder)
        {
            try
            {
                var files = Directory.GetFiles(folder, $"{teamCode}*.txt");
                var path = files.FirstOrDefault();
        
                if (string.IsNullOrEmpty(path))
                {
                    throw new FileProcessingException($"No se encontró el archivo para el equipo: {teamCode}");
                }

                return Path.GetFileName(path);
            }
            catch (Exception exception)
            {
                throw new FileProcessingException($"Error al buscar archivo en la carpeta: {folder}", exception);
            }
        }
        
        public bool IsTeamValid((StringList Player1Lines, StringList Player2Lines) playersInfo)
        {
            return _validator.IsPlayerValid(playersInfo.Player1Lines, out _player1UnitsInfo) &&
                   _validator.IsPlayerValid(playersInfo.Player2Lines, out _player2UnitsInfo);
        }
        
        public (PlayerUnitsInfo Player1, PlayerUnitsInfo Player2) GetPlayers()
        {
            return (_player1UnitsInfo, _player2UnitsInfo);
        }
        
    }    
}