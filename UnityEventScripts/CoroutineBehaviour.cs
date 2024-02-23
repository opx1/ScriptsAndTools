using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoroutineBehaviour : MonoBehaviour
{
    public UnityEvent startEvent, startCountEvent, repeatCountEvent, endCountEvent, repeatUntilFalseEvent;

    public bool canRun;
    public IntData counterNum;
    public float seconds = 3.0f;
    public float cSeconds = 3.0f;
    private WaitForSeconds wfsObj;
    private WaitForSeconds wfscObj;
    private WaitForFixedUpdate wffuObj;

    public bool CanRun
    {
        get => canRun;
        set => canRun = value;
    }

    private void Start()
    {
        wfsObj = new WaitForSeconds(seconds);
        wfscObj = new WaitForSeconds(cSeconds);
        wffuObj = new WaitForFixedUpdate();
        startEvent.Invoke();
    }

    public void StartCounting()
    {
        StartCoroutine(Counting());
    }
    
    private IEnumerator Counting()
    {
        startCountEvent.Invoke();    
        yield return wfsObj;
        while (counterNum.value > 0)
        {
            repeatCountEvent.Invoke();
            counterNum.value--;
            yield return wfsObj;
        }
        endCountEvent.Invoke();
    }

    public void StartRepeatUntilFalse()
    {
        CanRun = true;
        StartCoroutine(RepeatUntilFalse());
    }
    
    private IEnumerator RepeatUntilFalse()
    {
        while (CanRun)
        {
            repeatUntilFalseEvent.Invoke();
            yield return wfscObj;
        }
    }
}