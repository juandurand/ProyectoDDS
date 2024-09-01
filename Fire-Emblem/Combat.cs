using Fire_Emblem_View;
namespace Fire_Emblem;

public class Combat
{
    private List<Unit> _player1Units;
    private List<Unit> _player2Units;
    private View _view;
    private int _roundCounter = 1;
    private Damage _damage;

    public Combat((List<Tuple<string, List<string>>>, List<Tuple<string, List<string>>>) playersInfo, View view)
    {
        _player1Units = UnitLoader(playersInfo.Item1);
        _player2Units = UnitLoader(playersInfo.Item2);
        _view = view;
        _damage = new Damage(_view);
    }

    private List<Unit> UnitLoader(List<Tuple<string, List<string>>> playerInfo)
    {
        List<Unit> playerUnits = new List<Unit>();
        foreach (var unitInfo in playerInfo)
        {
            Unit unit = LoadingFunctions.CreateUnit(unitInfo.Item1, unitInfo.Item2);
            playerUnits.Add(unit);
        }
        return playerUnits;
    }

    private int GetAttackerIndex()
    {
        if (_roundCounter % 2 == 0) return 2;
        return 1;
    }
    
    private int GetDefenderIndex()
    {
        if (_roundCounter % 2 == 0) return 1;
        return 2;
    }

    private List<Unit> GetPlayersUnitsByIndex(int index)
    {
        if (index == 1) return _player1Units;
        return _player2Units;
    }

    private string GetPlayerNameByIndex(int index)
    {
        if (index == 1) return "Player 1";
        return "Player 2";
    }
    
    private void DisplayPlayerTeams(int playerIndex, List<Unit> playerUnits)
    {
        _view.WriteLine($"Player {playerIndex} selecciona una opción");
        for (int i = 0; i < playerUnits.Count; i++)
        {
            Unit unit = playerUnits[i];
            _view.WriteLine($"{i}: " + unit.Name);
        }
    }
    
    public void InitiateCombat()
    {
        while (_player1Units.Count != 0 && _player2Units.Count != 0)
        {
            List<Unit> attackerUnits = GetPlayersUnitsByIndex(GetAttackerIndex());
            DisplayPlayerTeams(GetAttackerIndex(), attackerUnits);
            Unit attackerUnit = attackerUnits[Convert.ToInt32(_view.ReadLine())];
            
            List<Unit> defenderUnits = GetPlayersUnitsByIndex(GetDefenderIndex());
            DisplayPlayerTeams(GetDefenderIndex(), GetPlayersUnitsByIndex(GetDefenderIndex()));
            Unit defenderUnit = defenderUnits[Convert.ToInt32(_view.ReadLine())];
            
            _view.WriteLine($"Round {_roundCounter}: {attackerUnit.Name} ({GetPlayerNameByIndex(GetAttackerIndex())}) comienza");
            _damage.AnnounceWtb(attackerUnit, defenderUnit);
            
            SimulateAttack(attackerUnit, defenderUnit);
            SimulateCounterAttack(defenderUnit, attackerUnit);
            SimulateFollowUp(attackerUnit, defenderUnit);
            _view.WriteLine($"{attackerUnit.Name} ({attackerUnit.ActualHP}) : {defenderUnit.Name} ({defenderUnit.ActualHP})");
            
            CheckHealth(attackerUnit, GetAttackerIndex());
            CheckHealth(defenderUnit, GetDefenderIndex());
            _roundCounter++;
        }

        if (_player1Units.Count == 0)
        {
            _view.WriteLine("Player 2 ganó");
        }
        else
        {
            _view.WriteLine("Player 1 ganó");
        }
    }
    
    private void SimulateAttack(Unit attacker, Unit defender)
    {
        int damage = _damage.GetDamage(attacker, defender);
        defender.DealDamage(damage);
        _view.WriteLine($"{attacker.Name} ataca a {defender.Name} con {damage} de daño");
    }

    private void SimulateCounterAttack(Unit attacker, Unit defender)
    {
        if (attacker.IsUnitAlive())
        {
            SimulateAttack(attacker, defender);
        }
    }

    private void SimulateFollowUp(Unit attacker, Unit defender)
    {
        if (attacker.IsUnitAlive() && defender.IsUnitAlive())
        {
            // FollowUp ** Skills cambia esto
            if (attacker.Spd - defender.Spd > 4)
            {
                SimulateAttack(attacker, defender);
            }
        
            else if (attacker.Spd - defender.Spd < -4)
            {
                SimulateAttack(defender, attacker);
            }
            else
            {
                _view.WriteLine("Ninguna unidad puede hacer un follow up");
            }
        }
    }

    private void CheckHealth(Unit unit, int playerIndex)
    {
        if (!unit.IsUnitAlive())
        {
            if (playerIndex == 1)
            {
                _player1Units.Remove(unit);
            }
            else
            {
                _player2Units.Remove(unit);
            }
        }
    }
}