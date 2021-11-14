using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject customObject;

    public void Spawn() {
        Instantiate(customObject, Camera.main.transform.position + Camera.main.transform.forward * 4, Quaternion.identity);
    }
}
