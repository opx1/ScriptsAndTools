using UnityEngine;

[CreateAssetMenu]
public class Instancer : ScriptableObject
{
    public GameObject prefab;

    public void CreateInstance()
    {
        Instantiate(prefab);
    }
}
