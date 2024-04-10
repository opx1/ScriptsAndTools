using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MatchBehavior : MonoBehaviour
{
    public ID idObj;
    public IntData intObj;
    public IntData intObj2;
    public UnityEvent matchEvent, noMatchEvent, noMatchDelayedEvent, updateEvent, updateEventOne, updateEventTwo, updateEventThree;
    private bool isInside = false;
    private bool hasHandledTrigger = false;
    public IntData update;

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

        while (intObj2.value != intObj.value && intObj2.value < intObj.value && isInside == true)
        {
            if (update.value == 0 && isInside)
            {
                updateEvent.Invoke();
            }
            
            else if (update.value == 1 && isInside)
            {
                updateEventOne.Invoke();
            }

            else if (update.value == 2 && isInside)
            {
                updateEventTwo.Invoke();
            }

            else if (update.value == 3 && isInside)
            {
                updateEventThree.Invoke();
            }
            yield return new WaitForSeconds(3.0f);
            Debug.Log("Delay");
            update.value++;
            noMatchDelayedEvent.Invoke();
            Debug.Log("No Match");
           
        }
    }


    private void OnTriggerExit(Collider other)
    {
        isInside = false;
        hasHandledTrigger = false; // Reset trigger handling when exiting trigger
    }
}