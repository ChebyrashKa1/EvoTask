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
        testSave();
        LoadScore();
        gameObject.SetActive(true);
    }
    #endregion

    #region Test
    private void testSave()
    {
        PlayerPrefs.SetInt(RecordPlace.First.ToString(), 15); 
    }
    public void testClear()
    {
        PlayerPrefs.DeleteAll();
    }
    #endregion

    private void LoadScore()
    {
        //расширения для енама, проход по пп с ключами
        var recordPlaces = GameCore.enumUtils.GetValues<RecordPlace>();
        string timerValue = "";
        for (int i = 0; i < recordPlaces.Count; i++)
        {
            if (PlayerPrefs.HasKey(recordPlaces[i].ToString()))
                timerValue = PlayerPrefs.GetInt(recordPlaces[i].ToString()).ToString();
            else
                timerValue = "--:--";
            timerLabels[i].UpdateTimer(timerValue);
        }
    }

    public enum RecordPlace
    {
        First   = 1,
        Second  = 2,
        Third   = 3,
    }
}