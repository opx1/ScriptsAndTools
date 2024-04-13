using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class InstancingBehaviour : MonoBehaviour
{
    [FormerlySerializedAs("Indexer")] public IntData indexer;
    [FormerlySerializedAs("StartEvent")] public UnityEvent startEvent;
    [FormerlySerializedAs("SpawnPoint")] public Transform spawnPoint;
    [FormerlySerializedAs("PrefabObj")] public Transform prefabObj;

    private void Start()
    {
        startEvent.Invoke();
    }

    public void InstantiateGameObject(GameObject prefab, Transform parent)
    {
        Instantiate(prefab, parent);
    }

    public void InstantiateAtPosition(GameObject prefab)
    {
        var newInstance = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }

    public void InstantiateUsingPrefab()
    {
        if (prefabObj == null) return;
        var newInstance = Instantiate(prefabObj, spawnPoint.position, Quaternion.identity);
    }

    public void InstantiateMultiple(GameObject prefab)
    {
        for (var i = 0; i < indexer.value; i++)
        {
            var newInstance = Instantiate(prefab, spawnPoint);
            newInstance.name = i.ToString();
        }
    }
}