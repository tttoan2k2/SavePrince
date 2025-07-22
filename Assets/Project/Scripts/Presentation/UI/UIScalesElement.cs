using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScalesElement : MonoBehaviour
{
    public SpriteRenderer scales;

    public void SetColor(Color color)
    {
        scales.color = color;
    }
}
