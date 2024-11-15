using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeBehaviour : MonoBehaviour
{
    public UnityEvent startGameEvent, nextDayEvent, endGameEvent;
    private WaitForSeconds wfsObj;
    public IntData days;
    private int seconds = 600;

    public void Start()
    {
        wfsObj = new WaitForSeconds(seconds);
    }

    public void StartCounting()
    {
        StartCoroutine(DayCount());
    }

    public IEnumerator DayCount()
    {
        startGameEvent.Invoke();

        while(days.value > 0)
        {
            nextDayEvent.Invoke();
            days. value--;
            yield return wfsObj;
        }
        endGameEvent.Invoke();
    }
}
