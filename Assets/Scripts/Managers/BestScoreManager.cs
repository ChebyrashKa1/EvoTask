﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestScoreManager : ASingleton<BestScoreManager>
{
    public static void SaveNewScore(int newScore)
    {
        List<int> scoresList = new List<int>(GetSummaryScores())
        {
            newScore
        };

        scoresList.Sort((p1, p2) => p1.CompareTo(p2));

        SaveScores(scoresList);
    }

    private static void SaveScores(List<int> newValues)
    {
        var recordPlaces = GameCore.enumUtils.GetValues<RecordPlace>();
        for (int i = 0; i < recordPlaces.Count; i++)
        {
            PlayerPrefs.SetInt(recordPlaces[i].ToString(), newValues[i]);
        }
    }

    public static List<int> GetSummaryScores()
    {
        List<int> list = new List<int>();
        var recordPlaces = GameCore.enumUtils.GetValues<RecordPlace>();
        for (int i = 0; i < recordPlaces.Count; i++)
        {
            if (PlayerPrefs.HasKey(recordPlaces[i].ToString()))
                list.Add(PlayerPrefs.GetInt(recordPlaces[i].ToString()));
        }
        return list;
    }
}
public enum RecordPlace
{
    First   = 0,
    Second  = 1,
    Third   = 2,
}