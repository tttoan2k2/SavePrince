using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class UIBoxElement : MonoBehaviour
{
    public Image boxImage;
    public Image boxDirect;
    string boxColor;

    public void Setup(BoxDataInfo info)
    {
        boxImage.sprite = info.boxType;
        boxDirect.sprite = info.direction;
        boxColor = info.boxColor.ToString();

        switch (boxColor)
        {
            case "red":
                boxImage.color = Color.red;
                break;
            case "blue":
                boxImage.color = Color.blue;
                break;
            case "green":
                boxImage.color = Color.green;
                break;
            case "yellow":
                boxImage.color = Color.red;
                break;
            case "purple":
                boxImage.color = new Color(0.5f, 0f, 0.5f);
                break;
            case "pink":
                boxImage.color = new Color(1f, 0.75f, 0.8f);
                break;
        }
    }

    
}
