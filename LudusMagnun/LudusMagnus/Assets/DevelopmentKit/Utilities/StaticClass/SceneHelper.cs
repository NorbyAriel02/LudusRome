using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneHelper 
{
    public static void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
