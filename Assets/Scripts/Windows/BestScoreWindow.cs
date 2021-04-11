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
        Init();
        gameObject.SetActive(true);
    }
    #endregion

    #region Test
    private void testSave()
    {
        //PlayerPrefs.SetInt(RecordPlace.First.ToString(), 15); 
    }
    public void testClear()
    {
        PlayerPrefs.DeleteAll();
    }
    #endregion

    private void Init()
    {
        List<int> recordPlaces = new List<int>(BestScoreManager.GetSummaryScores());

        for (int i = 0; i < timerLabels.Count; i++)
        {
            timerLabels[i].UpdateStaticTime(0); //default value
        }

        for (int i = 0; i < recordPlaces.Count; i++)
        {
            timerLabels[i].UpdateStaticTime(recordPlaces[i]);
        }
    }
}