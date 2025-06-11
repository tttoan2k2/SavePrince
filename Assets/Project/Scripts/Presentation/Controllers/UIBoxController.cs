using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class UIBoxController : MonoBehaviour
{
    public Transform BoxParent;
    public GameObject BoxPrefab;
    public void DisplayBoxs(List<BoxDataInfo> infos)
    {
        for (int i = 0; i < infos.Count; i++)
        {
            GameObject go = Instantiate(BoxPrefab, BoxParent);
            go.GetComponent<UIBoxElement>().Setup(infos[i]);
        }
    }
}
