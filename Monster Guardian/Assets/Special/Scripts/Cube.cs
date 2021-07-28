using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Console console;
    [SerializeField] private MoveDir moveDirection = MoveDir.Forward;
    [SerializeField] private float power = 6;
    // https://chao-island.com/wiki/Actions

    private Rigidbody rb;

    private GameObject target;

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
            agent.destination = Vector3.zero;
            Destroy(target);
        }
    }

    private IEnumerator PathToPoint()
    {
        while (true)
        {
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

            yield return new WaitForSeconds(5);
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
        //target = FindObjectOfType<Voreable>() // .gameObject;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        console = FindObjectOfType<Console>();

        StartCoroutine(PathToPoint());
    }

    // Update is called once per frame
    private void Update()
    {
    }
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