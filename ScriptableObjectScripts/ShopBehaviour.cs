using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopBehaviour : MonoBehaviour
{
    public IntData coins;
    public UnityEvent purchase, purchaseFail, sell;

    public void Purchase(IntData price)
    {
        if(price.value > coins.value)
        {
            coins.value -= price.value;
            Debug.Log(coins.value);
            purchase.Invoke();
        }
        else
        {
            Debug.Log("Not enough coins");
            purchaseFail.Invoke();
        }
    }

    public void Sell(IntData price)
    {
        coins.value += price.value;
        sell.Invoke();
    }
}
