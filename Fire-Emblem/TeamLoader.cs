using Fire_Emblem_View;
using Fire_Emblem_Common.PersonalizedInterfaces;

namespace Fire_Emblem

{
    public class TeamLoader
    {
        private PlayerUnitsInfo _player1UnitsInfo;
        private PlayerUnitsInfo _player2UnitsInfo;
        
        private readonly View _view;
        private readonly TeamParser _parser;
        private readonly TeamValidator _validator;
        
        public TeamLoader(View view, TeamParser parser)
        {
            _player1UnitsInfo = new PlayerUnitsInfo();
            _player2UnitsInfo = new PlayerUnitsInfo();
            _view = view;
            _parser = parser;
            _validator = new TeamValidator();
        }

        public (StringList Player1Lines, StringList Player2Lines) ChargePlayersInfo()
        {
            string teamCode = _view.ReadLine().PadLeft(3, '0');
            
            string fileName = FindFileByCode(teamCode, _parser.testFolder);
            
            return fileName != null ? _parser.ParseTeamsFile(fileName) : (new StringList(), new StringList());
        }
        
        private string FindFileByCode(string teamCode, string folder)
        {
            var files = Directory.GetFiles(folder, $"{teamCode}*.txt");
            var path = files.FirstOrDefault();
            return Path.GetFileName(path);
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