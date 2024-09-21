using Fire_Emblem_Common;
using System.Text.Json;
namespace Fire_Emblem;

public static class UnitsLoader
{
    public static Unit CreateUnit(string unitName, List<string> skills)
    {
        using JsonDocument doc = JsonDocument.Parse(File.ReadAllText("characters.json"));
        JsonElement rootElement = doc.RootElement;
        Dictionary<string, object> unitData = new Dictionary<string, object>();

        JsonElement unitElement = FindUnitElement(rootElement, unitName);
    
        if (unitElement.ValueKind == JsonValueKind.Undefined)
        {
            throw new ArgumentException($"Unit '{unitName}' not found in characters.json");
        }

        
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

        return new Unit(unitData);
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

    public static List<Unit> LoadUnits(List<Tuple<string, List<string>>> playerInfo)
    {
        var playerUnits = new List<Unit>();
        
        foreach (var unitInfo in playerInfo)
        {
            var unit = CreateUnit(unitInfo.Item1, unitInfo.Item2);
            playerUnits.Add(unit);
        }
        
        return playerUnits;
    }
}