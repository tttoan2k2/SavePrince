using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BoxData", menuName = "ScriptableObjects/BoxData")]
public class BoxData : ScriptableObject
{
    public List<BoxDataInfo> ListBoxDataInfo = new();
}
