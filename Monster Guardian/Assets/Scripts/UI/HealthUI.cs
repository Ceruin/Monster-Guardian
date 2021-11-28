using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] TMP_Text Text;
        Life life;

        public void Awake()
        {
            life = GetComponentInParent<Life>();
        }

        public void Update()
        {
            Text.text = $@"HP: { life.HealthPoints }";
        }

        public void Print<T>(T anything)
        {
            Text.text = anything.ToString();
        }
    }
}
