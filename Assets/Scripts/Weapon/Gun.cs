using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzleTransform;
    public Camera cam;

    private Vector3 mousePos;
    private Vector2 gunDirection;

    void Start()
    {
        
    }

    void Update()
    {
        //Input System
        mousePos = cam.ScreenToWorldPoint
            (Mouse.current.position.ReadValue());

        //枪方向的向量
        gunDirection = (mousePos - transform.position).normalized;

        //弧度转角度
        float angle = Mathf.Atan2(gunDirection.y, 
            gunDirection.x) * Mathf.Rad2Deg;

        //旋转角度
        transform.eulerAngles = new Vector3(0, 0, angle);

        //Input System
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Debug.Log("鼠标左键已经按下");
            //生成一颗子弹
            Instantiate(bullet, muzzleTransform.position,
                Quaternion.Euler(transform.eulerAngles));
        }
    }
}
