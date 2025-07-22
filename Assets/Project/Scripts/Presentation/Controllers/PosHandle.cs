using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosHandle : MonoBehaviour
{
    public Transform PosLeftBottom;
    public Transform PosRightBottom;
    public Transform PosLeftTop;
    public Transform PosRightTop;
    [Header("Pos Target")]
    public List<PosBoxController> ListPos;

    public Transform GetSlotEmpty()
    {
        foreach (var item in ListPos)
        {
            if (!item.BoxController)
            {
                return item.transform;
            } 
        }
        return null;
    }
}
