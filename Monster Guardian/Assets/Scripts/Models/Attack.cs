using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class Attack
    {
        public float SearchRadius = 10.0f;
        public GameObject Target;
        public Vector3 WorldPos;
        private int Damage = 5; // damage
        private HungerStatus Hunger = HungerStatus.Full; // food
    }
