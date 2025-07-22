using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoxColorEnum
{
    Red,
    Blue,
    Green,
    Yellow,
    Purple,
    Pink,
}
public enum BoxDirEnum
{
    Top,
    Bottom,
    Left,
    Right,
}

public enum BoxSizeEnum
{
    Small,
    Medium,
    Large,
}


[System.Serializable]
public class BoxColorInfo
{
    public BoxColorEnum boxColorEnum;
    public Color BoxColor;
}

[System.Serializable]
public class BoxDirInfo
{
    public BoxDirEnum boxDirEnum;
    public Sprite BoxDir;
}

[System.Serializable]
public class BoxSizeInfo
{
    public BoxSizeEnum boxSizeEnum;
    public Sprite BoxSize;
}

