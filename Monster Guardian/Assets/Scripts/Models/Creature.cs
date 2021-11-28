using System;
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
        public AI AI { get; set; }
        public Attack Attack { get; set; }
        public Feeling Feeling { get; set; }
        public Hunger Hunger { get; set; }
        public Life Life { get; set; }
        public Selection Selection { get; set; }
        public Consumable Consumable { get; set; } 
        public Team Team { get; set; }
        public Traits Traits { get; set; } 

        private Creature Target { get; set; } = null;
        private Vector3? Location { get; set; } = null;

        /// <summary>
        /// Assign and cause an action to the AI for it's target
        /// </summary>
        public void AssignTarget(Creature target)
        {
            Target = target;
        }

        public void AssignLocation(Vector3 location)
        {
            Location = location;
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

        public void Play()
        {
            // play animation
        }

        public void Sleep()
        {
            // play sleep animation
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

        // Update is called once per frame
        private void Update()
        {
            HandleMovement();
            HandleAttack();
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
               
            }
        }

        private void HandleMovement()
        {
            if (Location.HasValue) // if location move to location            
            {
                if (AI.GetStatus() == UnityEngine.AI.NavMeshPathStatus.PathComplete) // todo: figure out logic of how to handle when the action ended 
                {
                    Location = null;
                }
                AI.Move(Location);
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
    }
}