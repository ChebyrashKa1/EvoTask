using UnityEngine.SceneManagement;

public class ScenesManager
{
    public static SceneType GetActiveScene()
    {
        return (SceneType)SceneManager.GetActiveScene().buildIndex;
    }

    public static void LoadNewScene(SceneType type)
    {
        SceneManager.LoadScene((int)type);
    }
    public static void LoadNewScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public static void LoadNewScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
public enum SceneType
{
    Load = 0,
    Game = 1,
}