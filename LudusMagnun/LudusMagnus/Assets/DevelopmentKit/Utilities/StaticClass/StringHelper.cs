using UnityEngine;

public static class StringHelper 
{
    public static string GetName()
    {
        string[] names = { "Crixo", "Marco", "Atilio", "Barca", 
            "Cómodo", "Espartaco", "Carpophorus", "Vero", 
            "Prisco", "Tetraites", "Spiculus", "Carpóforo",
            "Flamma", "Batiato", "Seis", "Quintus", "Cuartus", "Primus"};
        int index = Random.Range(0, names.Length);
        return names[index];
    }
}