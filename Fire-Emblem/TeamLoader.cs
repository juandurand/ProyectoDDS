using Fire_Emblem_View;
using Fire_Emblem_Common;
namespace Fire_Emblem
{
    public class TeamLoader
    {
        private PlayerInfo _player1Info;
        private PlayerInfo _player2Info;
        
        private readonly View _view;
        private readonly TeamParser _parser;
        private readonly TeamValidator _validator;
        
        public TeamLoader(View view, TeamParser parser)
        {
            _player1Info = new PlayerInfo();
            _player2Info = new PlayerInfo();
            _view = view;
            _parser = parser;
            _validator = new TeamValidator();
        }

        public (List<string> Player1, List<string> Player2) ChargePlayersInfo()
        {
            string teamCode = _view.ReadLine().PadLeft(3, '0');
            string fileName = FindFileByCode(teamCode, _parser.testFolder);
            return fileName != null ? _parser.ParseTeamFile(fileName) : (new List<string>(), new List<string>());
        }
        
        private string FindFileByCode(string code, string folder)
        {
            var files = Directory.GetFiles(folder, $"{code}*.txt");
            return Path.GetFileName(files.FirstOrDefault());
        }


        public bool IsTeamValid((List<string> Player1, List<string> Player2) playersInfo)
        {
            return _validator.IsPlayerValid(playersInfo.Player1, out _player1Info) &&
                   _validator.IsPlayerValid(playersInfo.Player2, out _player2Info);
        }
        
        public (PlayerInfo Player1, PlayerInfo Player2) GetPlayers()
        {
            return (_player1Info, _player2Info);
        }
        
    }    
}