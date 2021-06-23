using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{
    public Transform backDoor;

    private bool isDoor;
    private Transform playerTransform;

    //private PlayerInputActions controls;
    private PlayerControls controls;

    void Awake()
    {
        //controls = new PlayerInputActions();
        controls = new PlayerControls();

        controls.GamePlay.EnterDoor.started += ctx => EnterDoor();
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
        playerTransform = GameObject.FindGameObjectWithTag("Player").
            GetComponent<Transform>();
    }

    void Update()
    {
        
    }

    void EnterDoor()
    {
        if (isDoor)
        {
            playerTransform.position = backDoor.position;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && 
            other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //Debug.Log("触碰到门了");
            isDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && 
            other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            //Debug.Log("离开门范围了");
            isDoor = false;
        }
    }
}
