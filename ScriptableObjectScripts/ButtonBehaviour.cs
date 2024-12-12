using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonBehaviour : MonoBehaviour
{
    public UnityEvent buttonPressed;
    public bool pressed = false;
    public void PressButton()
    {
        pressed = true;
        buttonPressed. Invoke();
    }
}
