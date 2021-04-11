using UnityEngine;

public class GoodJobWindow : BaseWindow, IWindow
{
    [SerializeField] private TimerLabel timerLabel;
    
    public void Init(int timer)
    {
        timerLabel.UpdateStaticTime(timer);
    }
}
