using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmartBat : Enemy
{
    public float speed;
    public float radius;

    private Transform playerTransform;

    public new void Start()
    {
        base.Start();
        playerTransform = GameObject.FindGameObjectWithTag("Player").
            GetComponent<Transform>();
    }

    public new void Update()
    {
        //调用父类的Update()方法
        base.Update();

        if (playerTransform != null)
        {
            //返回该向量的平方长度
            float distance = (transform.position - 
                playerTransform.position).sqrMagnitude;

            if(distance < radius)
            {
                //将点current移向target
                transform.position = Vector2.MoveTowards
                    (transform.position, playerTransform.position, 
                    speed * Time.deltaTime);
            }
        }
    }
}

