using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilsYield : ASingleton<UtilsYield>
{
    private Dictionary<float, WaitForSeconds> yields = new Dictionary<float, WaitForSeconds>();
    private WaitForEndOfFrame endFrame = new WaitForEndOfFrame();
    private WaitForFixedUpdate fixUpdate = new WaitForFixedUpdate();


    public WaitForEndOfFrame EndFrame { get { return endFrame; } }
    public WaitForFixedUpdate FixUpdate { get { return fixUpdate; } }
    public WaitForSeconds WaitFor(float seconds)
    {
        if (yields.ContainsKey(seconds))
            return yields[seconds];

        var waiter = new WaitForSeconds(seconds);
        yields.Add(seconds, waiter);
        return waiter;
    }

}
