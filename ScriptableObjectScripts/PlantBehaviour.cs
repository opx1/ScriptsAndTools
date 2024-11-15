using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlantBehaviour : MonoBehaviour
{
    public UnityEvent waterLevelIncreaseEvent;
    private WaitForSeconds wfsObj;
    public IntData level; 
    public IntData coins;
    public float seconds = 1.0f;
    public bool watering;
    //low diff = 4 max points 20, mid diff = 6 max points 30, high diff = 8 max points 40
    public int points = 0;
    public int waterAdd = 0;
    public int present;
    public int waterPoints = 15;//make these variable by plant type
    public int lightPoints = 15;
    public int check = 20; //make this variable by plant type
    public int dirtAmt = 0;
    int missWater = 0;
    public bool watered = false;
    public int dirt1; public int dirt2; public int dirt3;

    public int water; public int light;
    public List<int> prefDirtList; public List<int> dirtList;
    public PlantDataList mainList;

    public bool Watering
    {
        get => watering;
        set => watering = value;
    }

    public void Awake()
    {
        present = level.value;
        wfsObj = new WaitForSeconds(seconds);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        water = mainList.water;
        light = mainList.light;
        prefDirtList = new List<int> {mainList.dirtList[0], mainList.dirtList[1], mainList.dirtList[2]};
    }

    public void StartWater()
    {
        watering = true;
        StartCoroutine(WaterCalc());
    }

    public IEnumerator WaterCalc()
    {
        while(watering)
        {
            yield return wfsObj;
            waterLevelIncreaseEvent.Invoke();
            waterAdd++;
        }
    }

    public void UpdateWater()
    {
        if(watered)
        {
            waterPoints -= Mathf.Abs(water - waterAdd);
            watered = false;
        }
        else
        {
            missWater += 1;
            waterPoints -= Mathf.Abs(water - waterAdd);
        }

        if(waterPoints <= 0)
        {
            waterPoints = 0;
        }
        waterAdd = 0;
    }

    public void UpdateLight(int newValue)
    {
        lightPoints -= Mathf.Abs(light - newValue);
    }

    public void UpdateDirt(IntData dirt)
    {
        if(dirtAmt == 0)
        {
            dirt1 = dirt.value;
            dirtAmt += 1;
        }
        else if (dirtAmt == 1)
        {
            dirt2 = dirt.value;
            dirtAmt += 1;
        }
        else if (dirtAmt == 2)
        {
            dirt3 = dirt.value;
            dirtAmt += 1;
            dirtList = new List<int> {dirt1, dirt2, dirt3};
            dirtList. Sort((x, y) => x.CompareTo(y));
            for(int i = 0; i < dirtList.Count; i++)
            {
                check -= Mathf.Abs(dirtList[dirt.value] - prefDirtList[dirt.value]);
            }
        }
        else
        {
            Debug.Log("The pot is already full");
        }
    }

    public void UpdatePresentation(int newValue)
    {
        present -= newValue;
    }

    public void FinalCalculations(PlantDataList info, IntData leaves)
    {
        present -= leaves.value;
        points += waterPoints + light + check + present;

        if(points <= 0)
        {
            points = 1;
        }
        coins.value += points;
        Debug.Log("You have sold a plant worth " + points + " coins");
    }
}
