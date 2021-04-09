using UnityEngine;
using System;

public class InputControl : Singleton<InputControl>
{
    public Action mouseDown;
    public Action mouseUp;
    public Action mousePress;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown?.Invoke();
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseUp?.Invoke();
        }
        if (Input.GetMouseButton(0))
        {
            mousePress?.Invoke();
        }
    }
}