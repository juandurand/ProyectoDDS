using Fire_Emblem_View;
namespace Fire_Emblem;

public class Combat
{
    private readonly List<Unit> _player1Units;
    private readonly List<Unit> _player2Units;
    private readonly View _view;
    private int _roundCounter = 1;
    private readonly WeaponTriangle _weaponTriangle;

    public Combat((List<Tuple<string, List<string>>>, List<Tuple<string, List<string>>>) playersInfo, View view)
    {
        // SOBRECARGAR CONSTRUCTOR?
        _player1Units = UnitLoader(playersInfo.Item1);
        _player2Units = UnitLoader(playersInfo.Item2);
        _view = view;
        _weaponTriangle = new WeaponTriangle(_view);
    }

    private static List<Unit> UnitLoader(List<Tuple<string, List<string>>> playerInfo)
    {
        var playerUnits = new List<Unit>();
        
        foreach (var unitInfo in playerInfo)
        {
            var unit = LoadingFunctions.CreateUnit(unitInfo.Item1, unitInfo.Item2);
            playerUnits.Add(unit);
        }
        
        return playerUnits;
    }

    private int GetAttackerIndex()
    {
        return _roundCounter % 2 == 0 ? 2 : 1;
    }
    // QUE PASA CON ESE 2 (Naming)
    private int GetDefenderIndex()
    {
        return _roundCounter % 2 == 0 ? 1 : 2;
    }

    private List<Unit> GetPlayerUnitsByIndex(int playerIndex)
    {
        return playerIndex == 1 ? _player1Units : _player2Units;
    }

    private static string GetPlayerNameByIndex(int playerIndex)
    {
        return playerIndex == 1 ? "Player 1" : "Player 2";
    }
    
    private void DisplayPlayerTeam(int playerIndex, List<Unit> playerUnits)
    {
        _view.WriteLine($"Player {playerIndex} selecciona una opción");
        
        for (int unitIndex = 0; unitIndex < playerUnits.Count; unitIndex++)
        {
            Unit unit = playerUnits[unitIndex];
            _view.WriteLine($"{unitIndex}: " + unit.Name);
        }
    }

    private Unit SetAttackerUnit()
    {
        List<Unit> attackerUnits = GetPlayerUnitsByIndex(GetAttackerIndex());
        DisplayPlayerTeam(GetAttackerIndex(), attackerUnits);
        return attackerUnits[Convert.ToInt32(_view.ReadLine())];
    }
    
    private Unit SetDefenderUnit()
    {
        List<Unit> defenderUnits = GetPlayerUnitsByIndex(GetDefenderIndex());
        DisplayPlayerTeam(GetDefenderIndex(), GetPlayerUnitsByIndex(GetDefenderIndex()));
        return defenderUnits[Convert.ToInt32(_view.ReadLine())];
    }
    
    
    public void InitiateCombat()
    {
        while (_player1Units.Count != 0 && _player2Units.Count != 0)
        {
            Unit attackerUnit = SetAttackerUnit();
            Unit defenderUnit = SetDefenderUnit();
            
            // Announce round and WTB
            _view.WriteLine($"Round {_roundCounter}: {attackerUnit.Name} ({GetPlayerNameByIndex(GetAttackerIndex())}) comienza");
            _weaponTriangle.AnnounceWtb(attackerUnit, defenderUnit);
            
            // Simulate Attacks
            SimulateRound(attackerUnit, defenderUnit);
            
            _view.WriteLine($"{attackerUnit.Name} ({attackerUnit.ActualHp}) : {defenderUnit.Name} ({defenderUnit.ActualHp})");
            
            // Check Units Health after attacks
            CheckHealth(attackerUnit, GetAttackerIndex());
            CheckHealth(defenderUnit, GetDefenderIndex());
            
            // Round passed
            _roundCounter++;
        }

        // Announce winner
        _view.WriteLine(_player1Units.Count == 0 ? "Player 2 ganó" : "Player 1 ganó");
    }

    private void SimulateRound(Unit attackerUnit, Unit defenderUnit)
    {
        SimulateAttack(attackerUnit, defenderUnit);
        SimulateCounterAttack(defenderUnit, attackerUnit);
        SimulateFollowUp(attackerUnit, defenderUnit);
    }
    
    private void SimulateAttack(Unit attackerUnit, Unit defenderUnit)
    {
        int damage = Damage.GetDamage(attackerUnit, defenderUnit);
        defenderUnit.DealDamage(damage);
        _view.WriteLine($"{attackerUnit.Name} ataca a {defenderUnit.Name} con {damage} de daño");
    }

    private void SimulateCounterAttack(Unit attackerUnit, Unit defenderUnit)
    {
        if (attackerUnit.IsUnitAlive())
        {
            SimulateAttack(attackerUnit, defenderUnit);
        }
    }

    private void SimulateFollowUp(Unit attackerUnit, Unit defenderUnit)
    {
        if (!attackerUnit.IsUnitAlive() || !defenderUnit.IsUnitAlive())
        {
            return;
        }

        int requiredSpdDifference = 4;
        // FollowUp ** Skills cambia esto
        if (attackerUnit.Spd - defenderUnit.Spd > requiredSpdDifference)
        {
            SimulateAttack(attackerUnit, defenderUnit);
        }
    
        else if (attackerUnit.Spd - defenderUnit.Spd < -requiredSpdDifference)
        {
            SimulateAttack(defenderUnit, attackerUnit);
        }
        else
        {
            _view.WriteLine("Ninguna unidad puede hacer un follow up");
        }
        
    }

    private void CheckHealth(Unit unit, int playerIndex)
    {
        if (unit.IsUnitAlive())
        {
            return;
        }
        
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