using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    public Image img;
    public float time;
    public Color flashColor;

    private Color defaultColor;

    void Start()
    {
        //保存默认颜色
        defaultColor = img.color;
    }

    void Update()
    {
        
    }

    public void FlashScreen()
    {
        StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        img.color = flashColor;
        yield return new WaitForSeconds(time);
        img.color = defaultColor;
    }
}
