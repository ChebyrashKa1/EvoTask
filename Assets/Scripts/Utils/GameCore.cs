using UnityEngine;

public static class GameCore
{
    public static WindowManager     windows         => WindowManager.Instance;
    public static InputControl      input           => InputControl.Instance;
    public static ScenesManager     scenes          => ScenesManager.Instance;

    public static void SetAlpha(this UnityEngine.UI.Image self, float newAlpha)
    {
        self.color = new Color(self.color.r, self.color.g, self.color.b, newAlpha);
    }
    public static void SetAlpha(this TMPro.TMP_Text self, float newAlpha)
    {
        self.color = new Color(self.color.r, self.color.g, self.color.b, newAlpha);
    }
}