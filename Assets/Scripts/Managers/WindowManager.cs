using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WindowManager : Singleton<WindowManager>
{
    [SerializeField] private List<GameObject> listWindows;
    [SerializeField] private Transform canvasTransfrom;

    private List<GameObject> createdWindows = new List<GameObject>();
    private IWindow currentWindow;

    public void CloseWindow<T>()
    {
        CloseWindow<T>();
    }

    public T OpenWindow<T>() where T : IWindow
    {
        var window = Get<T>();

       // if (currentWindow != null)
        //    currentWindow.CloseWindow();
        currentWindow = window.GetComponent<IWindow>();
        currentWindow.OpenWindow();
        window.TryGetComponent(out T win);

        return win;
    }

    private GameObject Get<T>()
    {
        //show hided window
        for (int i = 0; i < createdWindows.Count; i++)
        {
            if (createdWindows[i].TryGetComponent<T>(out _))
            {
                createdWindows[i].SetActive(false);
                return createdWindows[i];
            }
        }

        //new window
        for (int i = 0; i < listWindows.Count; i++)
        {
            if (listWindows[i].TryGetComponent<T>(out _))
            {
                var list = Instantiate(listWindows[i], canvasTransfrom);
                createdWindows.Add(list);
                list.gameObject.SetActive(false);
                return list;
            }
        }
        Dbg.Log("Window open Error!", Color.red);
        return null;
    }

    #region Open Windows
    public void OpenPauseWindow()
    {
        GameCore.windows.OpenWindow<PauseWindow>();
    }
    public void OpenBestScoreWindow()
    {
        GameCore.windows.OpenWindow<BestScoreWindow>();
    }
    #endregion
}

public interface IWindow
{
    void OpenWindow();
    void CloseWindow();
}
