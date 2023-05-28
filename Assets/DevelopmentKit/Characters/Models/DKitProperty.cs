
[System.Serializable]
public class DKitProperty 
{    
    public Attributes attribute;
    public string abbreviation;
    public float value;
    public float minValue;
    public float maxValue;

    public DKitProperty(string _abbreviation = "", float _minValue = 0, float _maxValue = 0, float _value = 0) 
    {  
        this.abbreviation = _abbreviation;
        this.value = _value;
        this.minValue = _minValue;
        this.maxValue = _maxValue;
    }
}
