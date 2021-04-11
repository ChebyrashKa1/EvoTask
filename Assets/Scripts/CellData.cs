﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellData
{
    private CellType cellType;
    public CellType CellType { get => cellType; set => cellType = value; }
}

public enum CellType
{
    Empty = 0,
    Coin = 1,
    Hand = 2,
    Horse = 3,
    Lion = 4,
    Eagle = 5,
    Medusa = 6,
    Bull = 7,
}