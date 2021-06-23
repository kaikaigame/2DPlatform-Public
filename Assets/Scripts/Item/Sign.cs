using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogBoxText;
    public string signText;
    private bool isPlayerInSign;    
    
    //private PlayerInputActions controls;
    private PlayerControls controls;

    void Awake()
    {
        //controls = new PlayerInputActions();
        controls = new PlayerControls();

        controls.GamePlay.Dialogue.started += ctx => Dialogue();
    }

    void OnEnable()
    {
        controls.GamePlay.Enable();
    }

    void OnDisable()
    {
        controls.GamePlay.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Input Manager
        //if (Input.GetKeyDown(KeyCode.E) && isPlayerInSign)
        //{
        //    if (dialogBox.activeInHierarchy)
        //    {
        //        dialogBox.SetActive(false);
        //    }
        //    else
        //    {
        //        dialogBoxText.text = signText;
        //        dialogBox.SetActive(true);
        //    }
        //}
    }

    //Input System
    void Dialogue()
    {
        if (isPlayerInSign)
        {
            dialogBoxText.text = signText;
            dialogBox.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInSign = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")
            && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInSign = false;
            dialogBox.SetActive(false);
        }       
    }
}
