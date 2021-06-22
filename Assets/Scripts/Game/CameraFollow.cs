using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    void Start()
    {
        GameController.camShake = GameObject.FindGameObjectWithTag("CameraShake").
            GetComponent<CameraShake>();
    }

    void LateUpdate()
    {
        if(target != null)
        {
            if(transform.position != target.position)
            {
                Vector3 targetPos = target.position;

                //given value between the given minimum float and maximum float values
                targetPos.x = Mathf.Clamp(targetPos.x, minPosition.x, maxPosition.x);
                targetPos.y = Mathf.Clamp(targetPos.y, minPosition.y, maxPosition.y);

                //在 a 与 b 之间按 t 进行线性插值。
                //参数 t 限制在范围[0, 1] 内。
                //当 t = 0 时，返回 a 。当 t = 1 时，返回 b 。当 t = 0.5 时，返回 a 和 b 的中点。
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }

    public void SetCamPosLimit(Vector2 minPos, Vector2 maxPos)
    {
        minPosition = minPos;
        maxPosition = maxPos;
    }
}
