using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpheres : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.SetParent(this.transform);
        sphere.transform.position = new Vector3();

        // from the center go the radius out
        // then using a flat grid as a base spawn the circles
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
