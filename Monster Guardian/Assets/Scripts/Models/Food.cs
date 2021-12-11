using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a component to mark a game object as food and supply some food based values
    /// Class representation of a pet item
    /// </summary>
    public class Food : MonoBehaviour
    {
        [SerializeField]
        public Life Life;

        private Consumable Consumable;
    }
}