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

        if (currentWindow != null)
            currentWindow.CloseWindow();
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
            //Debug.Log("search! for:" + listWindows[i]);
            if (listWindows[i].TryGetComponent<T>(out _))
            {
                //Debug.Log("search!");
                var el = Instantiate(listWindows[i], canvasTransfrom);//.GetComponent<IWindowManager>();
                createdWindows.Add(el);
                //overlayWindows.Remove(el);
                el.gameObject.SetActive(false);

                //(el as MonoBehaviour).gameObject.SetActive(false);
                return el;
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
