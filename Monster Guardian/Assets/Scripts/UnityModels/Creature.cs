using System.Collections;
using System.Collections.Generic;
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
        var cubePOS = this.transform.position;
        var colliders = Physics.OverlapSphere(cubePOS, Attack.SearchRadius);
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

    private IEnumerator PathToPoint()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            CheckConsume();

            if (Attack.Target == null) { AI.agent.PathRandom(transform.position, Attack.SearchRadius); }
            else
            {
                AI.agent.Path(Attack.Target.transform.position);
            }

            if (Attack.Target == null)
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
        AI.agent = GetComponent<NavMeshAgent>();

        CheckConsume();
        StartCoroutine(PathToPoint());
    }

    // Update is called once per frame
    private void Update()
    {
        AI.Location = this.transform.position;
    }
}