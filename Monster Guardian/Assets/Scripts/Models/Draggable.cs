using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a component that allows the game object to be dragged across the screen
    /// </summary>
    public class Draggable : MonoBehaviour
    {
        private Vector3 _offset;
        private float _zcord;

        /// <summary>
        /// Get the the mouse world position
        /// </summary>
        /// <returns></returns>
        private Vector3 GetMouseWorldPos()
        {
            Vector3 mousePoint = Input.mousePosition; // x, y
            mousePoint.z = _zcord; // z
            return Camera.main.ScreenToWorldPoint(mousePoint);
        }

        private void OnMouseDown()
        {
            _zcord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            _offset = gameObject.transform.position - GetMouseWorldPos(); // store offset = gameobj world pos - mouse world pos
        }

        private void OnMouseDrag()
        {
            transform.position = GetMouseWorldPos() + _offset;
        }
    }
}