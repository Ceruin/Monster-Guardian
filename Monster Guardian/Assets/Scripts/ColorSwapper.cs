using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwapper : MonoBehaviour
{
    public void SetRed() {
        Debug.Log(":");
        GameObject test = GameObject.Find("Pet");
        test.transform.localScale = new Vector3(2,1,1);
    }

    public void SetBlu() {
        Debug.Log(":");
        GameObject test = GameObject.Find("Pet");
        test.transform.localScale = new Vector3(1,2,1);
    }

    public void SetGrn() {
        Debug.Log(":");
        GameObject test = GameObject.Find("Pet");
        test.transform.localScale = new Vector3(1,1,2);
    }
}
