using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    UIBoxController boxController;
    [SerializeField] UIBoxElement boxElement;
    public float speed = 2f;
    public bool isCanMove;
    public bool IsDetectObstacle;
    public LayerMask targetLayer;
    Transform obstacle;
    private Vector3 posStart;
    PosHandle posHandle;

    private void Start()
    {
        boxController = boxElement.BoxController;
        posStart = transform.localPosition;
        posHandle = GameplayController.Ins.PosHandle;
    }
    private void OnMouseDown()
    {
        isCanMove = true;
        obstacle = IsObjectInDirection(boxController.boxDirEnum);
        Debug.Log("Obstacle: " + obstacle);

    }
    void Update()
    {
        if (!isCanMove) return;

        if (GetTarget())
        {
            isCanMove = false;
            if (obstacle)
            {
                Vector3 startPos = transform.position;
                Vector3 direction = GetDirectionVector(boxController.boxDirEnum);

                Vector3 targetPos = startPos;

                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    targetPos.x = obstacle.transform.position.x - Mathf.Sign(direction.x) * 0.6f;
                }
                else
                {
                    targetPos.y = obstacle.transform.position.y - Mathf.Sign(direction.y) * 0.6f;
                }
                
                Debug.Log("dir: " + direction);
                Debug.Log("startPos: " + startPos);
                Debug.Log("tar: " + targetPos);

                transform.DOMove(targetPos, 0.5f).OnComplete(() =>
                {
                    if (obstacle.GetComponent<BoxMovement>().boxElement.BoxController)
                        obstacle.GetComponent<BoxMovement>().boxElement.BoxController.Shake();
                    transform.DOMove(startPos, 0.5f);
                });


            } else
            {
                MoveToTarget();
            }
            
        }
        else
        {
            isCanMove = false;
            GetComponent<BoxMovement>().boxElement.BoxController.Shake();
        }
    }

    Vector3 GetDirectionVector(BoxDirEnum dir)
    {
        switch (dir)
        {
            case BoxDirEnum.Top: 
                return Vector3.up;
            case BoxDirEnum.Bottom: 
                return Vector3.down;
            case BoxDirEnum.Right: 
                return Vector3.right;
            case BoxDirEnum.Left: 
                return Vector3.left;
            default: 
                return Vector3.zero;
        }
    }

    public Transform IsObjectInDirection(BoxDirEnum direction)
    {
        Vector2 dirVector = GetDirectionVector(direction);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dirVector, Mathf.Infinity, targetLayer);
        
        Debug.Log("Hit: " + hit.collider);

        if (hit.collider != null)
        {
            IsDetectObstacle = true;
            return hit.collider.transform;
        }
        return null;
    }
    private Transform GetTarget()
    {
        return GameplayController.Ins.PosHandle.GetSlotEmpty();
    }
    public void MoveToTarget()
    {
        Vector3[] arr = new Vector3[6];
        if (GetTarget())
        {
            switch (boxElement.BoxController.boxDirEnum)
            {
                case BoxDirEnum.Top:
                    arr = new Vector3[4];
                    arr = GetArrTop();
                    break;
                case BoxDirEnum.Bottom:
                    arr = GetArrBottom();
                    break;
                case BoxDirEnum.Right:
                    arr = new Vector3[5];
                    arr = GetArrRight();
                    break;
                case BoxDirEnum.Left:
                    arr = new Vector3[5];
                    arr = GetArrLeft();
                    break;
                default:
                    break;
            }
            transform.DOPath(arr, 2, PathType.Linear, PathMode.TopDown2D);

            //transform.DOPath(arr, 1f, PathType.Linear, PathMode.Sidescroller2D);

            GetTarget().GetComponent<PosBoxController>().BoxController = boxElement.BoxController;
        }
    }

    private Vector3[] GetArrLeft()
    {
        Vector3[] arr = new Vector3[5];
        arr[0] = transform.position;
    
        arr[1] = new Vector2(posHandle.PosLeftTop.position.x, transform.position.y);
        arr[2] = posHandle.PosLeftTop.position;
        arr[3] = new Vector2(GetTarget().position.x, posHandle.PosLeftTop.position.y);
        arr[4] = GetTarget().position;
        
        return arr;
    }
    private Vector3[] GetArrRight()
    {
        Vector3[] arr = new Vector3[5];

        arr[0] = transform.position;
        
        arr[1] = new Vector2(posHandle.PosRightTop.position.x, transform.position.y);
        arr[2] = posHandle.PosRightTop.position;
        arr[3] = new Vector2(GetTarget().position.x, posHandle.PosRightTop.position.y);
        arr[4] = GetTarget().position;
        
        return arr;
    }


    private Vector3[] GetArrBottom()
    {
        Vector3[] arr = new Vector3[6];
        arr[0] = transform.position;
        Debug.Log(transform.position);
        if (transform.position.x < 0)
        {
            arr[1] = new Vector2(transform.position.x, posHandle.PosLeftBottom.position.y);
            arr[2] = posHandle.PosLeftBottom.position;
            arr[3] = posHandle.PosLeftTop.position;
            arr[4] = new Vector2(GetTarget().position.x, posHandle.PosLeftTop.position.y);
            arr[5] = GetTarget().position;
            Debug.Log(GetTarget().position);

        } else
        {
            arr[1] = new Vector2(transform.position.x, posHandle.PosRightBottom.position.y);
            arr[2] = posHandle.PosRightBottom.position;
            arr[3] = posHandle.PosRightTop.position;
            arr[4] = new Vector2(GetTarget().position.x, posHandle.PosRightTop.position.y);
            arr[5] = GetTarget().position;
   
        }
        return arr;
    }

    private Vector3[] GetArrTop()
    {
        Vector3[] arr = new Vector3[4];
        arr[0] = transform.position;
        arr[1] = new Vector2(transform.position.x, posHandle.PosLeftTop.position.y);
        arr[2] = new Vector2(GetTarget().position.x, posHandle.PosLeftTop.position.y);
        arr[3] = GetTarget().position;

        return arr;
    }
}
