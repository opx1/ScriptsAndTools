using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDataList : ScriptableObject
{
    public int water;
    public int light;
    public List<int> dirtList;
    public MaterialID plantMaterial;
}
