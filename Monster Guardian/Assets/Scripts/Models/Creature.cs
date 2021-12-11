using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    /*
     * todo:
     * left click to attack
     * incubator
     * random ore
     * health bars
     * allies/enemies radius
     * main char movement
     * class objexts know what happen to them and return the values
     * components return values that the main class inteprets
    */

    /// <summary>
    /// This is the base class for most of the game objects to define what a creature is and what components it will use at a base level that can then be inherited and interfaced.
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

        /// <summary>
        /// Assign a target for the AI to attack
        /// </summary>
        /// <param name="enemy"></param>
        public void AttackTarget(Creature enemy)
        {
            // choose target
            AssignTarget(enemy);
        }

        /// <summary>
        /// Breed with an ally creature
        /// </summary>
        /// <param name="ally"></param>
        public void Breed(Creature ally)
        {
            // choose target
            // move towards target
            // attempt to breed
        }

        /// <summary>
        /// Eat the enemy type
        /// </summary>
        /// <param name="enemy"></param>
        public void Eat(Creature enemy)
        {
            // choose target
            // move to target
            // attempt to eat
        }

        /// <summary>
        /// Evolve the creature and upgrade its stats
        /// </summary>
        public void Evolve()
        {
            // if level reaches amount
            // attempt an evolution
        }

        /// <summary>
        /// Load the JSON state of the creature
        /// </summary>
        /// <param name="hobbit"></param>
        public void LoadState(BlueprintCreature hobbit)
        {
            transform.position = new Vector3(hobbit.xpos, hobbit.ypos, hobbit.zpos);
            tag = hobbit.tag;
            Team.SetTeam();
            SetColor();
        }

        /// <summary>
        /// Play with toys and reduce stress of creature
        /// </summary>
        public void Play()
        {
            // play animation
        }

        /// <summary>
        /// Save the current state of the creature to a JSON blueprint
        /// </summary>
        /// <returns></returns>
        public BlueprintCreature SaveState()
        {
            return new BlueprintCreature(
                transform.position.x,
                transform.position.y,
                transform.position.z,
                tag
                );
        }

        /// <summary>
        /// Make the creature sleep and rest
        /// </summary>
        public void Sleep()
        {
            // play sleep animation
        }

        /// <summary>
        /// Try to get creatures in range along with their distance values
        /// </summary>
        /// <param name="creature"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Set the creatures internal color
        /// </summary>
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

        /// <summary>
        /// Handle the attack actions for the creature
        /// </summary>
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

        /// <summary>
        /// Handle the movement actions
        /// </summary>
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