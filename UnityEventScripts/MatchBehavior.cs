using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MatchBehavior : MonoBehaviour
{
    public ID idObj;
    public IntData intObj;
    public IntData intObj2;
    public UnityEvent matchEvent, noMatchEvent, noMatchDelayedEvent;
    private bool isInside = false;

    private IEnumerator OnTriggerEnter(Collider other)
    {
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
            yield return new WaitForSeconds(5.0f);
            Debug.Log("Delay");
            noMatchDelayedEvent.Invoke();
            Debug.Log("No Match");
        }

        matchEvent.Invoke();
        Debug.Log("Match");
    }


    private void OnTriggerExit(Collider other)
    {
        isInside = false;
    }
}