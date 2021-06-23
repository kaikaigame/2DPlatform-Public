using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinItem : MonoBehaviour
{
    private bool isPlayerInTrashBin;

    //private PlayerInputActions controls;
    private PlayerControls controls;

    void Awake()
    {
        //controls = new PlayerInputActions();
        controls = new PlayerControls();

        controls.GamePlay.Coin.started += ctx => ThrowCoin();
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
        //if(Input.GetKeyDown(KeyCode.Y))
        //{
        //    if(isPlayerInTrashBin)
        //    {
        //        //持有金币大于0才能投币
        //        if(CoinUI.CurrentCoinQuantity > 0)
        //        {
        //            SoundManager.PlayThrowCoinClip();
        //            TrashBinCoin.coinCurrent++;
        //            CoinUI.CurrentCoinQuantity--;
        //        }
        //    }
        //}
    }

    //Input System
    void ThrowCoin()
    {
        if (isPlayerInTrashBin)
        {
            //持有金币大于0才能投币
            if (CoinUI.CurrentCoinQuantity > 0)
            {
                SoundManager.PlayThrowCoinClip();
                TrashBinCoin.coinCurrent++;
                CoinUI.CurrentCoinQuantity--;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && 
            other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInTrashBin = true;
            //Debug.Log("Player is In TrashBin");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && 
           other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInTrashBin = false;
            //Debug.Log("Player is not In TrashBin");
        }
    }
}
