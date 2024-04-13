using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventBehavior : MonoBehaviour
{
    public UnityEvent triggerEnterEvent, triggerExitEvent;
    private bool isInside = false;
    private bool hasHandledTrigger = false;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (hasHandledTrigger) yield break; // Check if trigger has been handled already
        hasHandledTrigger = true; // Set trigger handling to true
        
        isInside = true;
        triggerEnterEvent.Invoke();
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
        isInside = false;
        hasHandledTrigger = false; // Reset trigger handling when exiting trigger
        if (isInside == false)
        {
            triggerExitEvent.Invoke();
            yield break;
        }
        
    }
}
