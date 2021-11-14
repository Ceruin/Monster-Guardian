using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Hunger : MonoBehaviour
{
    public TimeSpan HungerLossInterval;
    public int Points = 100;

    private HungerStatus Status
    {
        get
        {
            return Get();
        }
    }
    /// <summary>
    /// Consume an object marked under the consumable tag
    /// </summary>
    public void Consume(Vector3 currentPos, float radius)
    {
        var colliders = Physics.OverlapSphere(currentPos, radius);
        Queue<GameObject> sObjects = new Queue<GameObject>(2);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.GetComponent<Consumable>() != null)
            {
                float dis1, dis2 = 99999;
                dis1 = Vector3.Distance(currentPos, collider.gameObject.transform.position);
                if (sObjects.Count > 0)
                {
                    var collider2 = sObjects.Dequeue();
                    dis2 = Vector3.Distance(currentPos, collider2.gameObject.transform.position);

                    if (dis1 < dis2)
                    {
                        sObjects.Enqueue(collider.gameObject);
                    }
                    else
                    {
                        sObjects.Enqueue(collider2.gameObject);
                    }
                }
                else
                {
                    sObjects.Enqueue(collider.gameObject);
                }
            }
        }
    }

    /// <summary>
    /// Using the enums as a percentage of the hunger status set out hunger status
    /// </summary>
    public HungerStatus Get()
    {
        return HungerStatus.Full;
    }
    /// <summary>
    /// Using the hunger loss interval check if we should deduct hunger
    /// </summary>
    public void HungerLoss()
    {
    }
}