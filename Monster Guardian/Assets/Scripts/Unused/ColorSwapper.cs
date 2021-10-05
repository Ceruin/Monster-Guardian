using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwapper : MonoBehaviour
{
    public GameObject bread;
    public GameObject milk;
    public GameObject cow;

    public void SpawnBread() {
        Debug.Log(":");
        //GameObject test = GameObject.Find("Pet");
        Instantiate(bread, Camera.main.transform.position + Camera.main.transform.forward * 4, Quaternion.identity);
        //test.transform.localScale = new Vector3(2,1,1);
    }

    public void SpawnMilk() {
        Debug.Log(":");
        //GameObject test = GameObject.Find("Pet");
        Instantiate(milk, Camera.main.transform.position + Camera.main.transform.forward * 4, Quaternion.identity);
        //test.transform.localScale = new Vector3(1,2,1);
    }

    public void SpawnCow() {
        Debug.Log(":");
        //GameObject test = GameObject.Find("Pet");
        Instantiate(cow, Camera.main.transform.position + Camera.main.transform.forward * 4, Quaternion.identity);
        //test.transform.localScale = new Vector3(1,1,2);
    }
}
