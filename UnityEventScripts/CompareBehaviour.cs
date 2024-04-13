using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CompareBehaviour : MonoBehaviour
{
   public IntData intObj;
   public IntData intObj2;
   public IntData update;
   public UnityEvent matchEvent, noMatchEvent, noMatchDelayedEvent, updateEvent, updateEventOne, updateEventTwo, updateEventThree, exitTriggerEvent;
   private bool isInside = false;
   private bool hasHandledTrigger = false;
   private IEnumerator OnTriggerEnter(Collider other)
   {
      if (hasHandledTrigger) yield break; // Check if trigger has been handled already
      hasHandledTrigger = true; // Set trigger handling to true
      Debug.Log("Trigger");

      isInside = true;
      
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
      exitTriggerEvent.Invoke();
   }
}
