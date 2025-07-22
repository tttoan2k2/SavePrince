using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class UIBoxElement : MonoBehaviour
{
    public SpriteRenderer BoxSize;
    public SpriteRenderer BoxDir;
    public UIBoxController BoxController;

    public void SetColor(Color color)
    {
        BoxSize.color = color;
    }
    
}
