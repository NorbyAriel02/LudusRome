
[System.Serializable]
public class GladiatorModelV2 : DKitCharacter
{
    public DKitProperties Stats = new DKitProperties();
    public GladiatorModelV2(GladiatorObjectV2 gladiatorObject)
    {
        id = gladiatorObject.indexDB;
        name = gladiatorObject.name;
        Stats = gladiatorObject.attributes;
    }
}
