using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoxColor
{
    red,
    blue,
    green,
    yellow,
    purple,
    pink,
}


[System.Serializable]
public class BoxDataInfo
{
    public Sprite direction;
    public Sprite boxType;
    public BoxColor boxColor;
}
