using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlantBehaviour : MonoBehaviour
{
    public IDDataList seed;
    public ID dirt1;
    public ID HighDrain;
    public ID HighSoil;
    public ID LowDrain;
    public ID LowSoil;
    public ID MidDrain;
    public ID MidSoil;
    public ID light1;
    public ID light2;
    public ID light3;
    private WaitForSeconds wfsObj;
    public IntData level; 
    public IntData coins;
    public float seconds = 1.0f;
    public bool watering;
    public bool potFull = false;
    //low diff = 4 max points 20, mid diff = 6 max points 30, high diff = 8 max points 40
    public int points = 0;
    public int waterAdd = 0;
    public int present;
    public int waterPoints = 15;//make these variable by plant type
    public int lightPoints = 15;
    public int check = 20; //make this variable by plant type
    public int dirtAmt = 0;
    public int dirtType = 0;
    int missWater = 0;
    public bool watered = false;
    public int currentLight;

    public int water; 
    public int light;
    public List<int> prefDirtList; 
    public List<int> dirtList;
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
        dirtList = new List<int> {};
    }

    public void OnTriggerEnter(Collider other)
    {
        var tempObj = other.GetComponent<IDContainerBehavior>();
        var idOther = tempObj.idObj;
        if(seed.IDList.Contains(idOther) && potFull)
        {
            Debug.Log("Seed Planted");
            water = mainList.water;
            light = mainList.light;
            prefDirtList = new List<int> {mainList.dirtList[0], mainList.dirtList[1], mainList.dirtList[2]};
            for(int i = 0; i < dirtList.Count; i++)
            {
                check -= Mathf.Abs(dirtList[i] - prefDirtList[i]);
            }
        }
        if(idOther == dirt1)
        {
            Debug.Log("dirt1");
            dirtType = 4;
            CheckDirt();
            dirtAmt++;
        }
        if(idOther == HighDrain)
        {
            Debug.Log("HighDrain");
            dirtType = 3;
            CheckDirt();
            dirtAmt++;
        }
        if(idOther == HighSoil)
        {
            Debug.Log("HighSoil");
            dirtType = 7;
            CheckDirt();
            dirtAmt++;
        }
        if(idOther == LowDrain)
        {
            Debug.Log("LowDrain");
            dirtType = 1;
            CheckDirt();
            dirtAmt++;
        }
        if(idOther == LowSoil)
        {
            Debug.Log("LowSoil");
            dirtType = 5;
            CheckDirt();
            dirtAmt++;
        }
        if(idOther == MidDrain)
        {
            Debug.Log("MidDrain");
            dirtType = 2;
            CheckDirt();
            dirtAmt++;
        }
        if(idOther == MidSoil)
        {
            Debug.Log("MidSoil");
            dirtType = 6;
            CheckDirt();
            dirtAmt++;
        }
        if(idOther == light1)
        {
            Debug.Log("light1");
            currentLight = 1;
        }
        if(idOther == light2)
        {
            Debug.Log("light2");
            currentLight = 2;
        }
        if(idOther == light3)
        {
            Debug.Log("light3");
            currentLight = 3;
        }
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

    public void UpdateLight()
    {
        lightPoints -= Mathf.Abs(light - currentLight);
    }

    public void CheckDirt()
    {
        if (dirtAmt < 2)
        {
            dirtList.Add(dirtType);
            Debug.Log("Not full yet");
        }
        if (dirtAmt == 2)
        {
            dirtList.Add(dirtType);
            dirtList.Sort((x, y) => x.CompareTo(y));
            potFull = true;
        }
        else if (dirtAmt > 2)
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