namespace Fire_Emblem_Common.Exceptions;

public class UnitNotFoundException : Exception
{
    public UnitNotFoundException(string unitName)
        : base($"Unit with name '{unitName}' not found in the JSON.")
    {
    }
}