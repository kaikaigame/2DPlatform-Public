using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    public GameObject bomb;

    //private PlayerInputActions controls;
    private PlayerControls controls;

    void Awake()
    {
        //controls = new PlayerInputActions();
        controls = new PlayerControls();

        controls.GamePlay.Bomb.started += ctx => Bomb();
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
        //if(Input.GetKeyDown(KeyCode.O))
        //{
        //    Instantiate(bomb, transform.position, 
        //        transform.rotation);
        //}
    }

    //Input System
    void Bomb()
    {
        Instantiate(bomb, transform.position, transform.rotation);
    }
}
