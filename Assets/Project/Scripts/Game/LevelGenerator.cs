using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private UIBoxController _UIBoxController;
    [SerializeField] private List<BoxLevelInfo> _listBoxes;
    [SerializeField] private List<UIBoxController> _listUIBoxController;
    [SerializeField] private GameObject dragonPrefab;
    [SerializeField] private GameObject scalesPrefab;
    [SerializeField] private Transform scalesParent;
    [SerializeField] private GameObject headPrefab;
    [SerializeField] private GameObject tailPrefab;
    //[SerializeField] private PointHandle pointHandle;

    public float minX = -3f;        
    public float maxX = 3f;        
    public float spawnY = 6f;
    public float spacing = 0.6f;

    void Start()
    {
        SpawnPointMove();
        SpawnDragon();
    }

    private void SpawnDragon()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 basePos = new Vector3(randomX, spawnY, 0f);
        Quaternion partRotation = Quaternion.Euler(0, 0, 90f);

       
        GameObject dragonInstance = Instantiate(dragonPrefab, basePos, Quaternion.identity, transform);
        Transform bodyParent = dragonInstance.transform.Find("ScalesController");

        
        Vector3 currentPos = basePos;


        //Instantiate(headPrefab, currentPos, partRotation, dragonInstance.transform);
        Instantiate(headPrefab, currentPos, Quaternion.identity, dragonInstance.transform);

        currentPos += Vector3.up * spacing;

        
        foreach (var box in _listBoxes)
        {
            int count = GetScalesDragon(box.boxSizeEnum);
            for (int i = 0; i < count; i++)
            {
                GameObject body = Instantiate(scalesPrefab, currentPos, partRotation, bodyParent);
                SpriteRenderer sr = body.GetComponentInChildren<SpriteRenderer>();
                if (sr != null)
                    sr.color = GetColorFromEnum(box.boxColorEnum);

                currentPos += Vector3.up * spacing;
            }
        }

        // 👉 Spawn Tail
        
        Instantiate(tailPrefab, currentPos, partRotation, dragonInstance.transform);
        
    }

    int GetScalesDragon(BoxSizeEnum size)
    {
        switch (size) 
        { 
            case BoxSizeEnum.Small:
                return 4;
            case BoxSizeEnum.Medium:
                return 6;
            case BoxSizeEnum.Large:
                return 8;
            default:
                return 0;
        }
    }

    Color GetColorFromEnum(BoxColorEnum colorEnum)
    {
        switch (colorEnum)
        {
            case BoxColorEnum.Red: return Color.red;
            case BoxColorEnum.Blue: return Color.blue;
            case BoxColorEnum.Green: return Color.green;
            case BoxColorEnum.Yellow: return Color.yellow;
            case BoxColorEnum.Purple: return new Color(0.5f, 0f, 0.5f); 
            case BoxColorEnum.Pink: return new Color(1f, 0.4f, 0.7f);
            default: return Color.white;
        }
    }

    private void SpawnPointMove()
    {
        //Instantiate(pointHandle, transform);
        Instantiate(GameManager.Ins.DataManager.MapData.GetMapDataByLevel(GameManager.Ins.DataManager.CurrentLevel), transform);
    }

    [Button]
    private void Spawn()
    {
        if (_listUIBoxController.Count > 0)
        {
            foreach (var item in _listUIBoxController)
            {
                DestroyImmediate(item.gameObject);
            }
        }
        _listUIBoxController.Clear();
        foreach (var item in _listBoxes)
        {
            UIBoxController boxControllerClone = Instantiate(_UIBoxController);
            boxControllerClone.transform.SetParent(transform);
            boxControllerClone.InitBox(item.boxSizeEnum, item.boxDirEnum, item.boxColorEnum);
            _listUIBoxController.Add(boxControllerClone);
        }
    }
}

