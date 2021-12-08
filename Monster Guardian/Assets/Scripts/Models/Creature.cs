using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    // todo:
    // left click to attack
    // incubator
    // random ore
    // health bars
    // allies/enemies radius
    // main char movement

    // class objexts know what happen to them and return the values
    // components return values that the main class inteprets

    /// <summary>
    /// https://chao-island.com/wiki/Actions
    /// </summary>
    public class Creature : MonoBehaviour, IEnemy
    {
        public Material[] materials;
        public AI AI { get; set; }
        public Attack Attack { get; set; }
        public Consumable Consumable { get; set; }
        public Feeling Feeling { get; set; }
        public Hunger Hunger { get; set; }
        public Life Life { get; set; }
        public Selection Selection { get; set; }
        public Team Team { get; set; }
        public Traits Traits { get; set; }

        private Vector3? Location { get; set; } = null;
        private Creature Target { get; set; } = null;

        public void AssignLocation(Vector3 location)
        {
            Location = location;
        }

        /// <summary>
        /// Assign and cause an action to the AI for it's target
        /// </summary>
        public void AssignTarget(Creature target)
        {
            Target = target;
        }

        public void AttackTarget(Creature enemy)
        {
            // choose target
            AssignTarget(enemy);
        }

        public void Breed(Creature ally)
        {
            // choose target
            // move towards target
            // attempt to breed
        }

        public void Eat(Creature enemy)
        {
            // choose target
            // move to target
            // attempt to eat
        }

        public void Evolve()
        {
            // if level reaches amount
            // attempt an evolution
        }

        public void LoadState(BlueprintCreature hobbit)
        {
            transform.position = new Vector3(hobbit.xpos, hobbit.ypos, hobbit.zpos);
            tag = hobbit.tag;
            Team.SetTeam();
            SetColor();
        }

        public void Play()
        {
            // play animation
        }

        public BlueprintCreature SaveState()
        {
            return new BlueprintCreature(
                transform.position.x,
                transform.position.y,
                transform.position.z,
                tag
                );
        }

        public void Sleep()
        {
            // play sleep animation
        }

        public KeyValuePair<Creature, float>? TryGetInRangeCreature(Creature creature)
        {
            var distance = Vector3.Distance(creature.gameObject.transform.position, transform.position);
            if (distance < Attack.AttackRadius)
            {
                return new KeyValuePair<Creature, float>(creature, distance);
            }
            else
            {
                return null;
            }
        }

        // Start is called before the first frame update
        private void Awake()
        {
            AI = gameObject.AddComponent<AI>();
            Attack = gameObject.AddComponent<Attack>();
            Feeling = gameObject.AddComponent<Feeling>();
            Hunger = gameObject.AddComponent<Hunger>();
            Life = gameObject.AddComponent<Life>();
            Selection = gameObject.AddComponent<Selection>();
            Consumable = gameObject.AddComponent<Consumable>();
            Team = gameObject.AddComponent<Team>();
            Traits = gameObject.AddComponent<Traits>();
        }

        private void Start()
        {
            SetColor();
        }

        private void SetColor()
        {
            switch (Team.Status)
            {
                case TeamStatus.Friendly:
                    GetComponent<MeshRenderer>().material = materials[0];
                    break;

                case TeamStatus.Enemy:
                    GetComponent<MeshRenderer>().material = materials[1];
                    break;

                default:
                    break;
            }
        }

        private void HandleAttack()
        {
            if (Target != null) // if target move to target
            {
                if (AI.InsideSearchArea(Target.gameObject)) // if target is in search radius
                {
                    Target.GetComponent<Creature>().Life.TakeDamage(Attack.GetDamage()); // attempt to attack target
                }
            }
            else  // if none then
            {
                Dictionary<Creature, float> inrangecreatures = new Dictionary<Creature, float>();
                foreach (Creature creature in FindObjectsOfType(typeof(Creature)).Select(p => (p as Creature)).Where(p => p.Team.Status == TeamStatus.Enemy))
                {
                    var testcreature = TryGetInRangeCreature(creature);
                    if (testcreature.HasValue) { inrangecreatures.Add(testcreature.Value.Key, testcreature.Value.Value); }
                }
                if (inrangecreatures.Count > 0)
                {
                    inrangecreatures.OrderBy(p => p.Value); // get closest
                    Target = inrangecreatures.First().Key;
                }
            }
        }

        private void HandleMovement()
        {
            if (Location.HasValue) // if location move to location
            {
                AI.Move(Location);
                if (AI.GetStatus() == UnityEngine.AI.NavMeshPathStatus.PathComplete) // todo: figure out logic of how to handle when the action ended
                {
                    Location = null;
                }
            }
            else if (Target != null) // if target move to target
            {
                if (AI.InsideSearchArea(Target.gameObject)) // if target is in search radius
                {
                    AI.Move(Target.gameObject); // move to target
                }
            }
            else  // if none then idle
            {
                AI.Idle();
            }
        }

        // Update is called once per frame
        private void Update()
        {
            HandleMovement();
            HandleAttack();
        }
    }
}