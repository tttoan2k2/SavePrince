

using UnityEngine;
using System.Collections.Generic;

public class DragonController : MonoBehaviour
{
    public Transform headTransform;
    private DragonMovement movement;

    void Start()
    {
        
        if (headTransform == null)
        {
            headTransform = FindHead();
        }

        if (headTransform == null)
        {
            Debug.LogError("Không tìm thấy Head trong DragonController!");
            return;
        }

        movement = headTransform.GetComponent<DragonMovement>();
        if (movement == null)
        {
            Debug.LogError("Không tìm thấy DragonMovement trên Head!");
            return;
        }

        List<Transform> scales = new List<Transform>();
        foreach (Transform t in transform) 
        {
            scales.Add(t);
        }

        movement.followers = scales;
        
    }

    
    Transform FindHead()
    {
        Transform dragon = transform.parent;
        if (dragon == null)
        {
            Debug.LogError("ScalesController không có cha!");
            return null;
        }

        Transform head = dragon.Find("Head(Clone)");
        if (head != null)
        {
            Debug.Log("✅ Tìm thấy Head(Clone) từ Dragon");
            return head;
        }

        return null;
    }
}