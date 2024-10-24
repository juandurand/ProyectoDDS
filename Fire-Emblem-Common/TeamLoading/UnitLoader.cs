using Fire_Emblem_Common.EDDs.Models;
using System.Text.Json;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Enums;

namespace Fire_Emblem_Common.TeamLoading;

public static class UnitsLoader
{
    public static UnitList LoadUnits(PlayerUnitsInfo playerUnitsInfo)
    {
        var playerUnits = new UnitList();
        
        foreach (var unitInfo in playerUnitsInfo)
        {
            var unit = CreateUnit(unitInfo);
            playerUnits.Add(unit);
        }
        
        return playerUnits;
    }
    private static Unit CreateUnit(UnitInfo unitInfo)
    {
        using JsonDocument doc = JsonDocument.Parse(File.ReadAllText("characters.json"));
        
        JsonElement rootElement = doc.RootElement;
        
        JsonElement unitElement = FindUnitElement(rootElement, unitInfo.GetUnitName());

        UnitData unitData = GetUnitData(unitElement, unitInfo.GetUnitSkills());
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

    private static UnitData GetUnitData(JsonElement unitElement, StringList skills)
    {
        UnitData unitData = new UnitData();
        
        unitData.Set(UnitDataKey.Name, GetJsonString(unitElement, "Name"));
        unitData.Set(UnitDataKey.Weapon, GetJsonString(unitElement, "Weapon"));
        unitData.Set(UnitDataKey.Gender, GetJsonString(unitElement, "Gender"));
        unitData.Set(UnitDataKey.DeathQuote, GetJsonString(unitElement, "DeathQuote"));
        unitData.Set(UnitDataKey.Hp, GetJsonInt(unitElement, "HP"));
        unitData.Set(UnitDataKey.Atk, GetJsonInt(unitElement, "Atk"));
        unitData.Set(UnitDataKey.Spd, GetJsonInt(unitElement, "Spd"));
        unitData.Set(UnitDataKey.Def, GetJsonInt(unitElement, "Def"));
        unitData.Set(UnitDataKey.Res, GetJsonInt(unitElement, "Res"));
        unitData.Set(UnitDataKey.Skills, skills);
        
        return unitData;
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