using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BoxData", menuName = "ScriptableObjects/BoxData")]
public class BoxData : ScriptableObject
{
    public List<BoxColorInfo> ListBoxColorInfo = new();
    public List<BoxDirInfo> ListBoxDirInfo = new();
    public List<BoxSizeInfo> ListBoxSizeInfo = new();

    public BoxColorInfo GetBoxColorInfoOfType(BoxColorEnum boxColorEnum)
    {
        foreach (var item in ListBoxColorInfo)
        {
            if (item.boxColorEnum == boxColorEnum)
                return item;
        }
        return null;
    }

    public BoxDirInfo GetDirBoxInfoOfType(BoxDirEnum boxDirEnum)
    {
        foreach (var item in ListBoxDirInfo)
        {
            if (item.boxDirEnum == boxDirEnum)
                return item;
        }
        return null;
    }
    
    public BoxSizeInfo GetBoxSizeInfoOfType(BoxSizeEnum boxSizeEnum)
    {
        foreach (var item in ListBoxSizeInfo)
        {
            if (item.boxSizeEnum == boxSizeEnum)
                return item;
        }
        return null;
    }
}
