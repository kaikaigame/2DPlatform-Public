using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBat : Enemy
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform movePos;//下一次移动位置
    public Transform leftDownPos;
    public Transform rightUpPos;


    public new void Start()
    {
        base.Start();

        waitTime = startWaitTime;
        movePos.position = GetRandomPos();
    }

    public new void Update()
    {
        //调用父类的Update()方法
        base.Update();

        //将值current向target靠近,maxDelta对值应用的最大变化。
        transform.position = Vector2.MoveTowards(transform.position, 
            movePos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x),
            Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }
}
