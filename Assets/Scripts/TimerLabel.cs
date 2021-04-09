using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerLabel : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text txtTimer;

    public void UpdateTimer()
    {
        txtTimer.SetText("timer");
    }
}
