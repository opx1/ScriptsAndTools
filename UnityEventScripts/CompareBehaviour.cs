using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CompareBehaviour : MonoBehaviour
{
   public ID idObj;
   public IntData intObj;
   public IntData intObj2;
   public IntData update;
   public UnityEvent matchEvent, noMatchEvent, noMatchDelayedEvent, updateEvent, updateEventOne, updateEventTwo, updateEventThree, exitTriggerEvent;
   private bool hasHandledTrigger = false;
   
   private IEnumerator OnTriggerEnter(Collider other)
   {
      var transformValueData = other.GetComponent<TransformValueData>();
      if (hasHandledTrigger) yield break; // Check if trigger has been handled already
      hasHandledTrigger = true; // Set trigger handling to true
      Debug.Log("Trigger");
      
      var tempObj = other.GetComponent<IDContainerBehavior>();
      if (tempObj == null)
         yield break;

      var idOther = tempObj.idObj;
      if (idOther != idObj) yield break;
      while (intObj2.value <= intObj.value && transformValueData.isWatering == true)
      {
         if (update.value == 0 && transformValueData.isWatering)
         {
            updateEvent.Invoke();
         }

         if (update.value == 1 && transformValueData.isWatering)
         {
            updateEventOne.Invoke();
         }

         if (update.value == 2 && transformValueData.isWatering)
         {
            updateEventTwo.Invoke();
         }

         if (update.value == 3 && transformValueData.isWatering)
         {
            updateEventThree.Invoke();
         }

         yield return new WaitForSeconds(2.0f);
         Debug.Log("Delay");
         update.value++;
         noMatchDelayedEvent.Invoke();
         Debug.Log("No Match");
      }

      hasHandledTrigger = false; // Reset trigger handling when exiting trigger
      exitTriggerEvent.Invoke();
   }
   /*private void OnTriggerExit(Collider other)
   {
      isInside = false;
      hasHandledTrigger = false; // Reset trigger handling when exiting trigger
      exitTriggerEvent.Invoke();
   }*/
}
