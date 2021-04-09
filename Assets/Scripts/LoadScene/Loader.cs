using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    //[SerializeField] private  leaderboard

    private void Start()
    {
        
    }

    public void GoGame()
    {
        GameCore.scenes.LoadNewScene(1);
    }
}
