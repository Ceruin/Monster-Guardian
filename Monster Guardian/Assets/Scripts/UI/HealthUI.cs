using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a health class to display the creature's health to the UI.
    /// </summary>
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text Text;
        private Life life;

        public void Awake()
        {
            life = GetComponentInParent<Life>();
        }

        public void Update()
        {
            Text.text = $@"HP: { life.HealthPoints }";
        }

        /// <summary>
        /// Print the health to a text
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="anything"></param>
        public void Print<T>(T anything)
        {
            Text.text = anything.ToString();
        }
    }
}