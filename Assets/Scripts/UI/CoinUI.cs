﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public int startCoinQuantity;
    public Text coinQuantity;

    public static int CurrentCoinQuantity;

    void Start()
    {
        CurrentCoinQuantity = startCoinQuantity;
    }

    void Update()
    {
        coinQuantity.text = CurrentCoinQuantity.ToString();
    }
}
