namespace Fire_Emblem_Common.Models;

public class Neutralization
{
    public bool IsNeutralized { get; }
    public string AttributeName { get; }
    public string NeutralizationType { get; }

    public Neutralization(bool isNeutralized, string attributeName, string neutralizationType)
    {
        IsNeutralized = isNeutralized;
        AttributeName = attributeName;
        NeutralizationType = neutralizationType;
    }
}