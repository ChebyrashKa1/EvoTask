using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : MonoBehaviour, IWindow
{
    #region Window
    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }

    public void OpenWindow()
    {
        gameObject.SetActive(true);
    }
    #endregion

    public void GoRestart()
    {
        GameCore.scenes.LoadNewScene(1);
    }
    public void GoMainMenu()
    {
        GameCore.scenes.LoadNewScene(0);
    }
}