using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleHit : MonoBehaviour
{
    public GameObject sickle;

    //private PlayerInputActions controls;
    private PlayerControls controls;

    void Awake()
    {
        //controls = new PlayerInputActions();
        controls = new PlayerControls();

        controls.GamePlay.Sickle.started += ctx => Sickle();
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
        //if(Input.GetKeyDown(KeyCode.U))
        //{
        //    Instantiate(sickle, transform.position, 
        //        transform.rotation);
        //}
    }

    //Input System
    void Sickle()
    {
        if (Time.timeScale != 0)
            Instantiate(sickle, transform.position, transform.rotation);
    }


}
