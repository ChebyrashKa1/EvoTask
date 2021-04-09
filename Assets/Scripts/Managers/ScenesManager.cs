using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : Singleton<ScenesManager>
{
    private void Start()
    {       
        DontDestroyOnLoad(transform.gameObject);
    }

    public void LoadNewScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void LoadNewScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}