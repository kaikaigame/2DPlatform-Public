using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public GameObject coin;
    public float delayTime;

    private bool canOpen;
    private bool isOpened;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        isOpened = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(canOpen && !isOpened)
            {
                anim.SetTrigger("Opening");
                isOpened = true;
                Invoke("GenCoin", delayTime);
            }
        }
    }

    void GenCoin()
    {
        Instantiate(coin, transform.position,
            Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && 
            other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && 
            other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = false;
        }
    }
}
