[System.Serializable]
public class GladiatorModel 
{
    public int id;
    public Stats attributes;
    public float baseHealthPoints = 50;
    public int level = 1;
    public int value = 1;
    public float damagePoints;
    public float armorPoints;
    public float maxHealthPoints;
    public float healthPoints;
    public float cooldownAttack;

    public GladiatorModel(GladiatorObject gladiatorObject)
    {
        id = gladiatorObject.id;
        attributes = gladiatorObject.attributes;
        level= gladiatorObject.level;
        value = gladiatorObject.value;
        damagePoints = gladiatorObject.damagePoints;
        armorPoints = gladiatorObject.armorPoints;
        maxHealthPoints= gladiatorObject.maxHealthPoints;
        healthPoints = gladiatorObject.healthPoints;
        cooldownAttack= gladiatorObject.cooldownAttack;
    }
}
