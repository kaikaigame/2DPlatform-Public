using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowStar : MonoBehaviour
{
    public GameObject[] gos;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GenGift()
    {
        //Instantiate(gos[Random.Range(0, gos.Length)]);
        //1.获取随机游戏对象
        //2.生成这个游戏对象
        //3.删除当前的星星
        Vector3 pos = transform.position;
        Instantiate(gos[Random.Range(0, gos.Length)], pos, Quaternion.identity);
        Destroy(gameObject);
    }
}
