using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MaterialIDDataList : ScriptableObject
{
    public List<MaterialID> MaterialIDList;

    public MaterialID currentMaterial;
    private int num;
    public IntData element;

    public void FillList (MaterialIDDataList dataList)
    {
        int selected = 0;
        int cycle = 0;
        foreach(MaterialID id in dataList.MaterialIDList)
        {
            dataList.MaterialIDList[cycle].inUse = false;
            cycle++;
        }
        MaterialIDList.Clear();

        while (selected < 3)
        {
            num = Random.Range(0, dataList.MaterialIDList.Count);
            if(!dataList.MaterialIDList[num].inUse)
            {
                MaterialIDList.Add(dataList.MaterialIDList[num]);
                dataList.MaterialIDList[num].inUse = true;
                selected ++;
            }
        }
        currentMaterial = MaterialIDList[0];
        element.value = 0;
    }

    public void SetCurrentMaterial()
    {
        if(element.value > MaterialIDList.Count - 1)
        {
            element.value= MaterialIDList.Count -1;
            Debug.Log("No material to set to. Corrected to element " + element.value);
        }
        else if(element.value < 0)
        {
            element.value = 0;
            Debug.Log("No material to set to. Corrected to element " + element.value);
        }
        else
        {
            currentMaterial = MaterialIDList[element.value];
        }
    }

    public void SetCurrentMaterialManually(MaterialID id)
    {
        currentMaterial = id;
    }

    public void SetCurrentMaterialFirstAvailabel()
    {
        foreach(MaterialID id in MaterialIDList)
        {
            if(!id.inUse)
            {
                currentMaterial = id;
                break;
            }
        }
    }

    public void SetCurrentMaterialFirstAvailableRandom()
    {
        bool selected = false;
        while(selected == false)
        {
            num = Random.Range(0,MaterialIDList.Count);
            if(!MaterialIDList[num].inUse)
            {
                currentMaterial = MaterialIDList[num];
                selected = true;
            }
        }
    }

    public void RemoveMaterialID()
    {
        currentMaterial.inUse = false;
        MaterialIDList.Remove(currentMaterial);
    }

    public void AddMaterialID(MaterialID newID)
    {
        MaterialIDList.Add(newID);
        newID.inUse = true;
    }
}