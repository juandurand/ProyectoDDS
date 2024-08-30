using Fire_Emblem_View;
namespace Fire_Emblem
{
    public class LoadingFunctions
    {
        private List<Tuple<string, List<string>>> _player1Info;
        private List<Tuple<string, List<string>>> _player2Info;
        private View _view;
        private string _teamsFolder;
        
        public LoadingFunctions(View view, string teamsFolder)
        {
            _player1Info = new List<Tuple<string, List<string>>>();
            _player2Info = new List<Tuple<string, List<string>>>();
            _view = view;
            _teamsFolder = teamsFolder;
        }

        public void DisplayFileOptions()
        {
            _view.WriteLine("Elige un archivo para cargar los equipos");
            var teamsList = Directory.GetFiles(_teamsFolder).Select(Path.GetFileName).ToArray();
            Array.Sort(teamsList);
            for (int i = 0; i < teamsList.Length; i++) { _view.WriteLine($"{i}: {teamsList[i]}"); }
        }

        public (List<string> Player1, List<string> Player2) ChargePlayersInfo()
        {
            string teamSelected = _view.ReadLine().PadLeft(3, '0');
            var playerInfo = ParseTeamFile(_teamsFolder, teamSelected);
            return playerInfo;
        }

        public bool IsTeamValid((List<string> Player1, List<string> Player2) playersInfo)
        {
            return IsPlayerValid(playersInfo.Player1, 1) && IsPlayerValid(playersInfo.Player2, 2);
        }
        
        public (List<Tuple<string, List<string>>> Player1, List<Tuple<string, List<string>>> Player2) GetPlayers()
        {
            return (_player1Info, _player2Info);
        }

        private (List<string> Player1, List<string> Player2) ParseTeamFile(string folder, string fileName)
        {
            var playerOneInfo = new List<string>();
            var playerTwoInfo = new List<string>();
            bool isPlayerOne = false, isPlayerTwo = false;

            foreach (var line in File.ReadLines($"{folder}/{fileName}.txt"))
            {
                if (line == "Player 1 Team") isPlayerOne = true;
                else if (line == "Player 2 Team") { isPlayerOne = false; isPlayerTwo = true; }
                else if (isPlayerOne) playerOneInfo.Add(line);
                else if (isPlayerTwo) playerTwoInfo.Add(line);
            }

            return (playerOneInfo, playerTwoInfo);
        }
        
        private bool IsPlayerValid(List<string> player, int playerIndex)
        {
            if (player.Count < 1 || player.Count > 3) { return false;}
            
            var units = new List<Tuple<string, List<string>>>();
            
            foreach (string line in player)
            {
                var (name, skills) = ParseUnit(line);
                if (units.Any(u => u.Item1 == name) || !AreSkillsValid(skills)) return false;
                units.Add(Tuple.Create(name, skills));
            }
            
            if (playerIndex == 1) { _player1Info = units; }
            else { _player2Info = units; }
            return true;
        }

        private (string name, List<string> skills) ParseUnit(string line)
        {
            int index1 = line.IndexOf('(');
            if (index1 == -1) {return (line.Trim(), new List<string> { "a,", "b" });}

            string name = line.Substring(0, index1).Trim();
            int index2 = line.IndexOf(')');
            string skillsString = line.Substring(index1 + 1, index2 - index1 - 1).Trim();
            var skillsList = skillsString.Split(',').Select(skill => skill.Trim()).ToList();
            return (name, skillsList);
        }

        private bool AreSkillsValid(List<string> skillsInfo)
        {
            return skillsInfo.Count <= 2 && (skillsInfo.Count < 2 || skillsInfo[0] != skillsInfo[1]);
        }
    }    
}



