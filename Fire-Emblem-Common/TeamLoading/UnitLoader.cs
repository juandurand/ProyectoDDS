using Fire_Emblem_Common.Models;
using System.Text.Json;
using Fire_Emblem_Common.PersonalizedInterfaces;
using Fire_Emblem_Common.Enums;
using Fire_Emblem_Common.Exceptions;

namespace Fire_Emblem_Common.TeamLoading;

public static class UnitsLoader
{
    public static UnitList LoadUnits(PlayerUnitsInfo playerUnitsInfo)
    {
        var playerUnits = new UnitList();
        
        foreach (var unitInfo in playerUnitsInfo)
        {
            var unit = CreateUnit(unitInfo);
            playerUnits.AddUnit(unit);
        }
        
        return playerUnits;
    }
    
    private static Unit CreateUnit(UnitInfo unitInfo)
    {
        using JsonDocument doc = JsonDocument.Parse(File.ReadAllText("characters.json"));
        
        JsonElement rootElement = doc.RootElement;
        
        JsonElement unitElement = GetUnitElement(rootElement, unitInfo.GetUnitName());

        UnitData unitData = GetUnitData(unitElement, unitInfo.GetUnitSkills());
        
        return new Unit(unitData);
    }
    
    private static JsonElement GetUnitElement(JsonElement rootElement, string unitName)
    {
        foreach (JsonElement element in rootElement.EnumerateArray())
        {
            if (element.GetProperty("Name").GetString().Equals(unitName))
            {
                return element;
            }
        }
        throw new UnitNotFoundException(unitName);
    }

    private static UnitData GetUnitData(JsonElement unitElement, StringList skills)
    {
        UnitData unitData = new UnitData();
        
        unitData.SetData(UnitDataKey.Name, GetJsonString(unitElement, "Name"));
        unitData.SetData(UnitDataKey.Weapon, GetJsonString(unitElement, "Weapon"));
        unitData.SetData(UnitDataKey.Gender, GetJsonString(unitElement, "Gender"));
        unitData.SetData(UnitDataKey.DeathQuote, GetJsonString(unitElement, "DeathQuote"));
        unitData.SetData(UnitDataKey.Hp, GetJsonInt(unitElement, "HP"));
        unitData.SetData(UnitDataKey.Atk, GetJsonInt(unitElement, "Atk"));
        unitData.SetData(UnitDataKey.Spd, GetJsonInt(unitElement, "Spd"));
        unitData.SetData(UnitDataKey.Def, GetJsonInt(unitElement, "Def"));
        unitData.SetData(UnitDataKey.Res, GetJsonInt(unitElement, "Res"));
        unitData.SetData(UnitDataKey.Skills, skills);
        
        return unitData;
    }
    
    private static string GetJsonString(JsonElement element, string propertyName)
    {
        JsonElement propertyElement = element.GetProperty(propertyName);
        return propertyElement.GetString();
    }
    
    private static int GetJsonInt(JsonElement element, string propertyName)
    {
        JsonElement propertyElement = element.GetProperty(propertyName);
        string propertyValue = propertyElement.GetString();
        return int.Parse(propertyValue);
    }

}