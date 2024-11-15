using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MatchBehavior : MonoBehaviour
{
    public ID idObj;
    public UnityEvent matchEvent, noMatchEvent, noMatchDelayedEvent, matchTriggerEvent;
    private bool isInside = false;
    private bool hasHandledTrigger = false;
    public bool isTriggered = false;
    

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (hasHandledTrigger) yield break; // Check if trigger has been handled already
        hasHandledTrigger = true; // Set trigger handling to true

        isInside = true;
        
        Debug.Log("Trigger");
        var tempObj = other.GetComponent<IDContainerBehavior>();
        if (tempObj == null)
            yield break;

        var idOther = tempObj.idObj;
        if (idOther == idObj)
        {
            matchEvent.Invoke();
        }
        else
        {
            noMatchEvent.Invoke();
            yield return new WaitForSeconds(0.5f);
            noMatchDelayedEvent.Invoke();
        }
        if (idOther == idObj && isInside == true)
        {
            if (isTriggered == true)
            {
                matchTriggerEvent.Invoke();
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        isInside = false;
        hasHandledTrigger = false; // Reset trigger handling when exiting trigger
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