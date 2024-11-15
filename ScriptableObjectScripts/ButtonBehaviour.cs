using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonBehaviour : MonoBehaviour
{
    public UnityEvent buttonPressed;
    public bool pressed = false;
    private void OnTriggerEnter()
    {
        pressed = true;
        buttonPressed. Invoke();
    }
}
