using Fire_Emblem_Common;
using System.Text.Json;
namespace Fire_Emblem;

public static class UnitsLoader
{
    public static UnitList LoadUnits(PlayerInfo playerInfo)
    {
        var playerUnits = new UnitList();
        
        foreach (var unitInfo in playerInfo)
        {
            var unit = CreateUnit(unitInfo);
            playerUnits.Add(unit);
        }
        
        return playerUnits;
    }
    private static Unit CreateUnit(Tuple<string, List<string>> unitInfo)
    {
        using JsonDocument doc = JsonDocument.Parse(File.ReadAllText("characters.json"));
        JsonElement rootElement = doc.RootElement;
        JsonElement unitElement = FindUnitElement(rootElement, unitInfo.Item1);
        
        return new Unit(GetUnitData(unitElement, unitInfo.Item2));
    }

    private static Dictionary<string, object> GetUnitData(JsonElement unitElement, List<string> skills)
    {
        Dictionary<string, object> unitData = new Dictionary<string, object>();
        
        unitData["Name"] = GetJsonString(unitElement, "Name");
        unitData["Weapon"] = GetJsonString(unitElement, "Weapon");
        unitData["Gender"] = GetJsonString(unitElement, "Gender");
        unitData["DeathQuote"] = GetJsonString(unitElement, "DeathQuote");
        unitData["HP"] = GetJsonInt(unitElement, "HP");
        unitData["Atk"] = GetJsonInt(unitElement, "Atk");
        unitData["Spd"] = GetJsonInt(unitElement, "Spd");
        unitData["Def"] = GetJsonInt(unitElement, "Def");
        unitData["Res"] = GetJsonInt(unitElement, "Res");
        unitData["Skills"] = skills;
        
        return unitData;
    }
    
    private static JsonElement FindUnitElement(JsonElement rootElement, string unitName)
    {
        foreach (JsonElement element in rootElement.EnumerateArray())
        {
            if (element.GetProperty("Name").GetString().Equals(unitName))
            {
                return element;
            }
        }
        return default;
    }
    
    private static string GetJsonString(JsonElement element, string propertyName)
    {
        return element.GetProperty(propertyName).GetString();
    }

    private static int GetJsonInt(JsonElement element, string propertyName)
    {
        return int.Parse(element.GetProperty(propertyName).GetString());
    }
}