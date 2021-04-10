using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsManager : Singleton<IconsManager>
{
    [SerializeField] private Sprite[] sprites;

    public Sprite GetCellIcon(CellType cellType)
    {
        if ((int)cellType > sprites.Length)
            return sprites[0];
        return sprites[(int)cellType];
    }
}
