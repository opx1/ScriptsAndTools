using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class MonoEventsBehavior : MonoBehaviour
{
    public UnityEvent startEvent, awakeEvent, disableEvent, onEnableEvent, onClickEvent, clickHoldEvent;
    public float holdTime;
    private void Awake()
    {
        awakeEvent.Invoke();
    }
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(holdTime);
        startEvent.Invoke();
    }

    private void OnEnable()
    {
        onEnableEvent.Invoke();
    }

    private void OnDisable()
    {
        disableEvent.Invoke();
    }
    
    private void OnMouseDown()
    {
        onClickEvent.Invoke();
    }

    private void OnMouseDrag()
    {
        clickHoldEvent.Invoke();
    }
}
