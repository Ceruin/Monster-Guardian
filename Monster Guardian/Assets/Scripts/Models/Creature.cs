using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

// left click to attack
// incubator
// random ore
// health bars
// allies/enemies radius
// main char movement

/// <summary>
/// https://chao-island.com/wiki/Actions
/// </summary>
public class Creature : MonoBehaviour
{
    [SerializeField]
    public Life Life;
    [SerializeField]
    public Attack Attack;
    [SerializeField]
    public Effects Effects;
    [SerializeField]
    public AI AI;

    private void CheckConsume()
    {
        var playerpos = this.transform.position;
        var colliders = Physics.OverlapSphere(playerpos, Attack.SearchRadius);
        Queue<GameObject> sObjects = new Queue<GameObject>(2);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.GetComponent<Consumable>() != null)
            {
                float dis1, dis2 = 99999;
                dis1 = Vector3.Distance(playerpos, collider.gameObject.transform.position);
                if (sObjects.Count > 0)
                {
                    var collider2 = sObjects.Dequeue();
                    dis2 = Vector3.Distance(playerpos, collider2.gameObject.transform.position);

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
        if (sObjects.Count > 0) { Attack.Target = sObjects.Dequeue(); }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == Attack.Target)
        {
            Instantiate(Effects.ExplodeEffect, Attack.Target.transform.position + (transform.up * 1.5f), Quaternion.identity);
            Destroy(Attack.Target.transform.parent.gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        AI.Agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckConsume();
    }

    private void Idle()
    {
        if (AI.Agent.pathStatus == NavMeshPathStatus.PathComplete) {
            AI.Agent.PathRandom(transform.position, Attack.SearchRadius);
        }
    }
}