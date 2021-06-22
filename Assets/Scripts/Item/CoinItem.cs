﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        if(other.gameObject.CompareTag("Player") && 
            other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            SoundManager.PlayPickCoinClip();
            CoinUI.CurrentCoinQuantity += 1;
            Destroy(gameObject);
        }
    }
}
