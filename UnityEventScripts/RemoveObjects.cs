using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class RemoveObjects : MonoBehaviour
{
    public bool isTriggered = false;
    private bool isInside = false;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("InBasket");
        isInside = true;
        var otherObj = other.gameObject;
        if (isInside == true && isTriggered == true)
        {
            Destroy(otherObj);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInside = false;
    }
    
    public void setTriggerTrue()
    {
        isTriggered = true;
        Debug.Log("trigger basket");
    }
    
    public void setTriggerFalse()
    {
        isTriggered = false;
        Debug.Log("untrggr basket");
    }
}
