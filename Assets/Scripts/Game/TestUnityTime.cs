using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnityTime : MonoBehaviour
{
    public GameObject[] objs;
    public float coldTime;

    private int j = 0;
    private float time;

    void Start()
    {
        //DeleteByCoroutine();

        //DeleteByInvoke();

        time = coldTime;
        
    }

    void Update()
    {
        DeleteByDeltaTime();
    }

    //1.协程 Coroutine
    void DeleteByCoroutine()
    {
        for(int i = 0; i < objs.Length; i++)
        {
            StartCoroutine(DeleteObj(i, i + 1));
        }
    }

    IEnumerator DeleteObj(int i, float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(objs[i]);
    }

    //2.Invoke 调用方法不能有参数
    void DeleteByInvoke()
    {
        for (int i = 0; i < objs.Length; i++)
        {
            Invoke("DeleteObj2", i + 1);
        }
    }

    void DeleteObj2()
    {
        Destroy(objs[j]);
        j++;
    }

    //3.Time.deltaTime
    void DeleteByDeltaTime()
    {
        //if(j < 10)
        if (j < objs.Length)
        {
            if (coldTime > 0)
            {
                coldTime -= Time.deltaTime;
            }
            else
            {
                Destroy(objs[j++]);
                coldTime = time;
            }
        }
    }
}
