using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using DG.Tweening;
using UnityEditor.PackageManager;
using UnityEngine;

public class UIBoxController : MonoBehaviour
{
    public BoxColorEnum boxColorEnum;
    public BoxDirEnum boxDirEnum;
    public BoxSizeEnum boxSizeEnum;
    public UIBoxElement boxElement;

    public void Shake()
    {
        transform.DOShakePosition(1, .1f, 6, 11.3f, false, true, ShakeRandomnessMode.Harmonic);
    }

    public void InitBox(BoxSizeEnum boxSize, BoxDirEnum boxDir, BoxColorEnum boxColor)
    {
        boxSizeEnum = boxSize;
        boxColorEnum = boxColor;
        boxDirEnum = boxDir;


        switch (boxSizeEnum)
        {
            case BoxSizeEnum.Small:
                SpawnBox(GameManager.Ins.GameAssets.BoxSmall);
                break;
            case BoxSizeEnum.Medium:
                SpawnBox(GameManager.Ins.GameAssets.BoxMedium);
                break;
            case BoxSizeEnum.Large:
                SpawnBox(GameManager.Ins.GameAssets.BoxLarge);
                break;
            default:
                break;
        }


        boxElement.SetColor(GameManager.Ins.DataManager.DataBox.GetBoxColorInfoOfType(boxColorEnum).BoxColor);
        boxElement.BoxDir.sprite = GameManager.Ins.DataManager.DataBox.GetDirBoxInfoOfType(boxDirEnum).BoxDir;
        boxElement.BoxController = this;
    }

    public void SpawnBox(UIBoxElement box)
    {
        GameObject objClone = Instantiate(box.gameObject);
        objClone.transform.SetParent(transform);
        boxElement = objClone.GetComponent<UIBoxElement>();

    }

}
