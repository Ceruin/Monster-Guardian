using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwapper : MonoBehaviour
{
    public GameObject bread;
    public GameObject milk;
    public GameObject gold;

    public void SetRed() {
        Debug.Log(":");
        GameObject test = GameObject.Find("Pet");
        Instantiate(bread, Camera.main.transform.position + Camera.main.transform.forward * 4, Quaternion.identity);
        //test.transform.localScale = new Vector3(2,1,1);
    }

    public void SetBlu() {
        Debug.Log(":");
        GameObject test = GameObject.Find("Pet");
        Instantiate(bread, Camera.main.transform.position + Camera.main.transform.forward * 4, Quaternion.identity);
        //test.transform.localScale = new Vector3(1,2,1);
    }

    public void SetGrn() {
        Debug.Log(":");
        GameObject test = GameObject.Find("Pet");
        Instantiate(bread, Camera.main.transform.position + Camera.main.transform.forward * 4, Quaternion.identity);
        //test.transform.localScale = new Vector3(1,1,2);
    }
}
