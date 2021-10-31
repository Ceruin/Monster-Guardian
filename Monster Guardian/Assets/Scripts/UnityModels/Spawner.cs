using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);

    // Start is called before the first frame update
    void Start()
    {
        SetChildren();
    }

    private void SetChildren()
    {
        spawnObject.transform.SetParent(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
