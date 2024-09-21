using Fire_Emblem_View;
namespace Fire_Emblem
{
    public class TeamLoader
    {
        private List<Tuple<string, List<string>>> _player1Info;
        private List<Tuple<string, List<string>>> _player2Info;
        
        private readonly View _view;
        private readonly TeamParser _parser;
        private readonly TeamValidator _validator;
        
        public TeamLoader(View view, TeamParser parser)
        {
            _player1Info = new List<Tuple<string, List<string>>>();
            _player2Info = new List<Tuple<string, List<string>>>();
            _view = view;
            _parser = parser;
            _validator = new TeamValidator();
        }

        public (List<string> Player1, List<string> Player2) ChargePlayersInfo()
        {
            string teamSelected = _view.ReadLine().PadLeft(3, '0');
            return _parser.ParseTeamFile(teamSelected);
        }

        public bool IsTeamValid((List<string> Player1, List<string> Player2) playersInfo)
        {
            return _validator.IsPlayerValid(playersInfo.Player1, out _player1Info) &&
                   _validator.IsPlayerValid(playersInfo.Player2, out _player2Info);
        }
        
        public (List<Tuple<string, List<string>>> Player1, List<Tuple<string, List<string>>> Player2) GetPlayers()
        {
            return (_player1Info, _player2Info);
        }
        
    }    
}