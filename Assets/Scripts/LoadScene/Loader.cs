using UnityEngine;

public class Loader : MonoBehaviour
{
    public void GoGame()
    {
        ScenesManager.LoadNewScene(SceneType.Game);
    }
}