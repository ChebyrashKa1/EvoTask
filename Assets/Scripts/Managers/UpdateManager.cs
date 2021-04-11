using System.Collections;

public class UpdateManager : Singleton<UpdateManager>
{
    public System.Action secondTick;

    private void Start()
    {
        StartCoroutine(SecondTick());
    }

    private IEnumerator SecondTick()
    {
        var wait = GameCore.yield.WaitFor(1.0f);
        while (true)
        {
            secondTick?.Invoke();
            yield return wait;
        }
    }

    public static string TimeToStr(int timeCorrect)
    {
        string timeSt;
        int min = timeCorrect / 60 % 60;
        int sec = timeCorrect % 60;

        var minString = min.ToString();
        var secString = sec.ToString();

        if (sec < 10)            
            secString = "0" + sec;

        timeSt = minString + ":" + secString;
        return timeSt;
    }
}
