using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    public GameObject ArrowPrefab;

    //private PlayerInputActions controls;
    private PlayerControls controls;

    void Awake()
    {
        //controls = new PlayerInputActions();
        controls = new PlayerControls();

        controls.GamePlay.ArrowHit.started += ctx => Shoot();
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
        
    }

    void Shoot()
    {
        //transform.localRotation = Quaternion.Euler(0, 0, 0);

        if (Time.timeScale != 0)
            Instantiate(ArrowPrefab, transform.position, transform.rotation);
    }
}
