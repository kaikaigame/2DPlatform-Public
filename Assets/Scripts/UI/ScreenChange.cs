using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenChange : MonoBehaviour
{
    public GameObject img1;
    public GameObject img2;

    //public List<GameObject> imgs = new List<GameObject>();
    public GameObject[] imgs;

    public float time;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetBool("ChangeToWhite", true);
            Invoke("ChangeImage", time);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            //foreach (var img in imgs)
            //{
            //    img.SetActive(true);
            //}

            for (int i = 0; i < imgs.Length; i++)
            {
                imgs[i].SetActive(true);
            }
        }
    }

    void ChangeImage()
    {
        img1.SetActive(false);
        //img2.SetActive(true);
    }
}
