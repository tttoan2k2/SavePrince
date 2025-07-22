using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{
    public List<Transform> followers = new List<Transform>(); // Các vảy
    public float distanceBetween = 0f; // Khoảng cách giữa các vảy
    public float followSpeed = 0f;
    public float recordInterval = 0f; // Thời gian lưu lại vị trí
    public bool stopFollow = false;

    private List<Vector3> positionHistory = new List<Vector3>();
    private float recordTimer = 0f;

    void Start()
    {
        // Lấy path di chuyển
        PointHandle pointHandle = FindObjectOfType<PointHandle>();
        if (pointHandle == null || pointHandle.PointDragonMove.Count == 0)
        {
            Debug.LogError("Không tìm thấy điểm di chuyển!");
            return;
        }

        Vector3[] path = new Vector3[pointHandle.PointDragonMove.Count];
        for (int i = 0; i < path.Length; i++)
        {
            path[i] = pointHandle.PointDragonMove[i].position;
        }

        // Di chuyển đầu
        transform.DOPath(path, 12f, PathType.CatmullRom, PathMode.Full3D)
            .SetLookAt(0.01f, Vector3.right)
            .OnComplete(() => stopFollow = true);
    }

    void Update()
    {
        if (stopFollow) return;

        // Ghi lại vị trí đầu rồng theo thời gian đều đặn
        recordTimer += Time.deltaTime;
        if (recordTimer >= recordInterval)
        {
            recordTimer = 0f;
            positionHistory.Insert(0, transform.position);

            // Giới hạn lịch sử để tránh quá dài
            int maxHistory = Mathf.CeilToInt((followers.Count + 1) * distanceBetween / recordInterval) + 10;
            if (positionHistory.Count > maxHistory)
            {
                positionHistory.RemoveRange(maxHistory, positionHistory.Count - maxHistory);
            }
        }

        // Di chuyển và xoay từng vảy
        for (int i = 0; i < followers.Count; i++)
        {
            int index = Mathf.FloorToInt((i + 1) * distanceBetween / recordInterval);
            if (index >= positionHistory.Count) continue;

            Vector3 targetPos = positionHistory[index];

            // Di chuyển mượt tới vị trí cần đến
            followers[i].position = Vector3.Lerp(followers[i].position, targetPos, Time.deltaTime * followSpeed);

            // Tính hướng di chuyển và xoay vảy
            Vector3 direction = targetPos - followers[i].position;
            if (direction != Vector3.zero)
            {
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                followers[i].rotation = Quaternion.Euler(0, 0, angle -= 180f);
            }
        }
    }
}




