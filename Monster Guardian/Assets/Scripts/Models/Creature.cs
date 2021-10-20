using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Console console;
    [SerializeField] private MoveDir moveDirection = MoveDir.Forward;
    [SerializeField] private float power = 6;
    [SerializeField] public bool ISCUBE;
    public GameObject explodeEffect;
    // https://chao-island.com/wiki/Actions

    private Rigidbody rb;
    private GameObject target;
    private bool wellFed = false;

    private enum Action
    {
        Move,
        //Eat,
        //Play,
        //Breed,
        //Evolve,
        //Sleep,
    }

    private enum Characteristics
    {
        //Evolution,
        //Alignment,
        //Intelligence,
        //Health,
        //Happiness,
        //Hunger,
        //Loneliness,
        //Age,
        //Color,
        //Shiny,
        //Outfits
    }

    private enum MoveDir
    {
        Forward,
        Left,
        Right,
        Backwards
    }

    private enum MovementType
    {
        //Sit,
        //Idle,
        //Crawl,
        //Walk,
        //Run,
        //Swim,
        //Fly,
        //Follow
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == target)
        {
            Instantiate(explodeEffect, target.transform.position + (transform.up * 1.5f), Quaternion.identity);
            Destroy(target.transform.parent.gameObject);
            wellFed = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == target)
        {
            Instantiate(explodeEffect, target.transform.position + (transform.up * 1.5f), Quaternion.identity);
            Destroy(target.transform.parent.gameObject);
            wellFed = true;
        }
    }

    private IEnumerator PathToPoint()
    {
        while (true)
        {
            if (wellFed)
            {
                wellFed = false;
                yield return new WaitForSeconds(5);
            }

            CheckVore();

            Vector3 point;
            float range = 10.0f;
            RandomPointOnNavMesh randomPointOnNavMesh = new RandomPointOnNavMesh();
            randomPointOnNavMesh.RandomPoint(transform.position, range, out point);
            if (target == null) { agent.destination = point; }
            else
            {
                agent.destination = target.transform.position;
            }
            PrintToConsoleAndGUI(point);

            if (target == null)
            {
                yield return new WaitForSeconds(5);
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    private void PrintToConsoleAndGUI<T>(T whatever)
    {
        print(whatever.ToString());
        if (console != null) console.UpdateGUI(whatever.ToString());
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        console = FindObjectOfType<Console>();

        CheckVore();

        StartCoroutine(PathToPoint());
    }

    private void CheckVore()
    {
        if (!ISCUBE) return;

        var cubePOS = this.transform.position;
        var colliders = Physics.OverlapSphere(cubePOS, 10);
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
        if (sObjects.Count > 0) { target = sObjects.Dequeue(); }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public Vector3 WorldPos { get; set; }
}

public class RandomPointOnNavMesh
{
    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range;
            UnityEngine.AI.NavMeshHit hit;
            if (UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}