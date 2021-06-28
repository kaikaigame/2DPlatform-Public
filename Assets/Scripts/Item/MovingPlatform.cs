using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;

    private int i;
    private Transform playerDefTransform;

    void Start()
    {
        i = 1;
        //记录初始位置的父级
        playerDefTransform = GameObject.
            FindGameObjectWithTag("Player").transform.parent;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
            movePos[i].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
        {
            if (waitTime < 0.0f)
            {
                //if (i == 0)
                //{
                //    i = 1;//下一个位置
                //}
                //else
                //{
                //    i = 0;
                //}

                i = i == 0 ? 1 : 0;

                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().
            ToString() == "UnityEngine.BoxCollider2D")
        {
            //player作为当前平台的子对象 transform的父级是当前平台transform
            other.gameObject.transform.parent = gameObject.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetType().
            ToString() == "UnityEngine.BoxCollider2D")
        {   
            //回到原来的父级
            other.gameObject.transform.parent = playerDefTransform;
        }
    }
}
