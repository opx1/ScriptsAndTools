using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObjects : MonoBehaviour
{
    public bool isTriggered = false;
    private bool isInside = false;

    private void OnTriggerEnter(Collider other)
    {
        isInside = true;
        if (isInside == true && isTriggered)
        {
            Destroy(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInside = false;
    }
    
    public void setTriggerTrue()
    {
        isTriggered = true;
    }
    
    public void setTriggerFalse()
    {
        isTriggered = false;
    }
}
