using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController Instance;

    public BoxData boxData;

    public UIBoxController UIBoxController;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ShowAllGifts();
    }

    public void ShowAllGifts()
    {
        UIBoxController.DisplayBoxs(boxData.ListBoxDataInfo);
    }

}
