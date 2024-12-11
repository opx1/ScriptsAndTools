using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedRespawnBehaviour : MonoBehaviour
{
    public GameObject seed;
    public ID seedID;
    public IntData packetCount;
    public void OnTriggerExit(Collider other)
    {
        var tempObj = other.GetComponent<IDContainerBehavior>();
        if (tempObj.idObj == seedID && packetCount.value < 5)
        {
            GameObject newObject = Instantiate(seed);
            packetCount.value ++;
        }
    }
}
