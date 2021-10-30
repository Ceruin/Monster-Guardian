using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectCreator : MonoBehaviour
{
    public GameObject bread;
    public GameObject milk;
    public GameObject cow;

    public void SpawnBread() {
        Instantiate(bread, Camera.main.transform.position + Camera.main.transform.forward * 4, Quaternion.identity);
    }

    public void SpawnMilk() {
        Instantiate(milk, Camera.main.transform.position + Camera.main.transform.forward * 4, Quaternion.identity);
    }

    public void SpawnCow() {
        Instantiate(cow, Camera.main.transform.position + Camera.main.transform.forward * 4, Quaternion.identity);
    }
}
