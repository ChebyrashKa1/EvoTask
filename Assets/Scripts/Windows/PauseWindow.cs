public class PauseWindow : BaseWindow, IWindow
{
    public override void OpenWindow()
    {
        base.OpenWindow();
        GameCore.cells.StopTimer();
    }

    public override void CloseWindow()
    {
        base.CloseWindow();
        GameCore.cells.ActiveTimer();
    }
}