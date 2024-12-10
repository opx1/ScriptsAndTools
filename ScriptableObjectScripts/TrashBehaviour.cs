using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TrashBehaviour : MonoBehaviour
{
    public ID ticket;
    public IDDataList seeds;
    public IntDataList packetAmts;
    private int count = 0;
    public UnityEvent resetSeeds;
    public void OnTriggerEnter(Collider other)
    {
        var tempObj = other.GetComponent<IDContainerBehavior>();
        if(seeds.IDList.Contains(tempObj.idObj) ||tempObj.idObj == ticket)
        {
            Destroy(other.gameObject);
            foreach(ID seed in seeds.IDList)
            {
                if(tempObj.idObj == seeds.IDList[count])
                {
                    if(packetAmts.IntdataList[count].value == 5)
                    {
                        resetSeeds.Invoke();
                    }
                    packetAmts.IntdataList[count].value --;
                    count = 0;
                    break;
                }
                count ++;
            }
        }
        else
        {
            Debug.Log("You can't throw that away");
        }
    }
}
