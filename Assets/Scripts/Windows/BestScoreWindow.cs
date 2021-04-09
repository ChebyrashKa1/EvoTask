using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreWindow : MonoBehaviour, IWindow
{
    [SerializeField] private List<TimerLabel> timerLabels;

    #region Window
    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }

    public void OpenWindow()
    {
        LoadScore();
        gameObject.SetActive(true);
    }
    #endregion

    private void LoadScore()
    {
        //расширения для енама, проход по пп с ключами
        if (PlayerPrefs.HasKey(RecordPlace.First.ToString()))
            PlayerPrefs.GetInt("First");
    }

    public void Init()
    {
       /* for (int i = 0; i < length; i++)
        {
        // инициализация значений если есть, нету = "--:--"
        }*/
    }

    private void GetSaveInfo()
    {
        PlayerPrefs.GetInt("First");
    }

    public enum RecordPlace
    {
        First   = 1,
        Second  = 2,
        Third   = 3,
    }
}