using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlantDataListBehaviour : MonoBehaviour
{
    public PlantDataList thisPlant;
    public UnityEvent seedSelect;
    public void UpdateSeedChoice(PlantDataList mainList)
    {
        mainList.water = thisPlant.water;
        mainList.light = thisPlant.light;
        mainList.dirtList = new List<int> {thisPlant.dirtList[0], thisPlant.dirtList[1], thisPlant.dirtList[2]};
    }

    public void OnTriggerEnter (Collider Other)
    {
        Debug.Log("Collision Detected");
        seedSelect. Invoke();
    }
}
