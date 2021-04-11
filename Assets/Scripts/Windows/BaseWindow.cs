using UnityEngine;

public class BaseWindow : MonoBehaviour, IWindow
{
    #region Window
    public virtual void CloseWindow()
    {
        gameObject.SetActive(false);
    }

    public virtual void OpenWindow()
    {
        gameObject.SetActive(true);
    }
    #endregion

    public void GoRestart()
    {
        ScenesManager.LoadNewScene(SceneType.Game);
    }
    public void GoMainMenu()
    {
        ScenesManager.LoadNewScene(SceneType.Load);
    }
}
