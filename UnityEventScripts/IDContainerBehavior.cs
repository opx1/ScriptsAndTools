using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IDContainerBehavior : MonoBehaviour
{
    public ID idObj;
    public UnityEvent startEvent;

    public void Start()
    {
        startEvent.Invoke();
    }
    
    public void ChangeIDObj(ID newID)
    {
        idObj = newID;
    }
    
    public void ClearIDObj()
    {
        idObj = null;
    }
}