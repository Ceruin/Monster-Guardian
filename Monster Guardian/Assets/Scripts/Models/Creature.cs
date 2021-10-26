using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// https://chao-island.com/wiki/Actions
/// </summary>
public class Creature : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Console console;
    public GameObject ExplodeEffect { get; set; }
    public GameObject Target { get; private set; }
    public Vector3 WorldPos { get; set; }
    private int Damage { get; set; } = 5;
    private HungerStatus Hunger { get; set; } = HungerStatus.Full; // food
                                                                   // damage
    private int Life { get; set; } = 100; // life
    public float SearchRadius { get; set; } = 10.0f;

    private void CheckConsume()
    {
        var cubePOS = this.transform.position;
        var colliders = Physics.OverlapSphere(cubePOS, SearchRadius);
        Queue<GameObject> sObjects = new Queue<GameObject>(2);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.GetComponent<Consumable>() != null)
            {
                float dis1, dis2 = 99999;
                dis1 = Vector3.Distance(cubePOS, collider.gameObject.transform.position);
                if (sObjects.Count > 0)
                {
                    var collider2 = sObjects.Dequeue();
                    dis2 = Vector3.Distance(cubePOS, collider2.gameObject.transform.position);

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
        if (sObjects.Count > 0) { Target = sObjects.Dequeue(); }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == Target)
        {
            Instantiate(ExplodeEffect, Target.transform.position + (transform.up * 1.5f), Quaternion.identity);
            Destroy(Target.transform.parent.gameObject);
        }
    }

    private IEnumerator PathToPoint()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            CheckConsume();
            
            if (Target == null) { agent.Move(NavUtils.RandomPoint(transform.position, SearchRadius)); }
            else
            {
                agent.destination = Target.transform.position;
            }

            if (Target == null)
            {
                yield return new WaitForSeconds(5);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        console = FindObjectOfType<Console>();

        CheckConsume();
        StartCoroutine(PathToPoint());
    }

    // Update is called once per frame
    private void Update()
    {
    }
}