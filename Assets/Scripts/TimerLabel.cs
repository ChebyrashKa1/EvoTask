using UnityEngine;

public class TimerLabel : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text txtTimer;

    private int timer = 0;
    private System.Action finishAction;

    public int Timer => timer;

    public void UpdateStaticTime(int setTimer)
    {
        if(setTimer <= 0)
        {
            txtTimer.SetText("--:--");
            return;
        }
        txtTimer.SetText(UpdateManager.TimeToStr(setTimer));
        //txtTimer.SetText(setTimer);
    }

    public void StartTimer(int startTime, System.Action onFinish = null)
    {
        if (startTime <= 0)
        {
            txtTimer.SetText("00:00");
            return;
        }

        finishAction = onFinish;
        timer = startTime;
        GameCore.updater.secondTick -= UpdateTimer;
        GameCore.updater.secondTick += UpdateTimer;
    }

    public void StopTimer(bool makeFinishAction = false)
    {
        GameCore.updater.secondTick -= UpdateTimer;
        if (makeFinishAction)
        {
            finishAction?.Invoke();
        }
    }

    private void UpdateTimer()
    {
        if (timer <= 0)
        {
            txtTimer.SetText(UpdateManager.TimeToStr(timer));
            StopTimer(true);
            return;
        }
        txtTimer.SetText(UpdateManager.TimeToStr(--timer));
    }

    public void CleanSelf()
    {
        txtTimer.SetText("");
    }
}