namespace Fire_Emblem_Common.Models;

public class AttributeChange
{
    public int AttributeValue { get; }
    public string AttributeName { get; }
    public string SpecificAttack { get; }
    public string EffectType { get; }

    public AttributeChange(int attributeValue, string attributeName, string specificAttack, string effectType)
    {
        AttributeValue = attributeValue;
        AttributeName = attributeName;
        SpecificAttack = specificAttack;
        EffectType = effectType;
    }
}