using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public BoxData DataBox;
    public MapData MapData;

    public int CurrentLevel
    {
        get { return PlayerPrefs.GetInt("CurrentLevel", 1); }
        set
        {
            PlayerPrefs.SetInt("CurrentLevel", value);
        }
    }
}
