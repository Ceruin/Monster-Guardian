using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private Stopwatch lifeSpan = new Stopwatch();
    public float test = 0;

    // Start is called before the first frame update
    void Start()
    {
        lifeSpan.Start();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lifeSpan.Elapsed > new TimeSpan(0, 0, 10))
        {
            lifeSpan.Reset();

            GameObject noob = Instantiate(gameObject, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + test, gameObject.transform.position.z), Quaternion.identity);
            noob.GetComponent<Creature>().test = (test + 1);

            Destroy(gameObject);
        }
    }
}
