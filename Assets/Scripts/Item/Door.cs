﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {        
            if (other.gameObject.CompareTag("Player") && 
            other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
            {
                SceneManager.LoadScene(SceneManager.
                    GetActiveScene().buildIndex + 1);
            }
    }
}
