using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapData", menuName = "ScriptableObjects/MapData")]
public class MapData : ScriptableObject
{
    public List<MapDataInfo> mapDataInfo = new List<MapDataInfo>();

    public PointHandle GetMapDataByLevel(int level)
    {
        foreach(var item in mapDataInfo)
        {
            foreach (int i in item.listLevel)
            {
                if (i == level)
                {
                    return item.PointHandle;
                }
            }
            
        }
        return null;
    }
}
