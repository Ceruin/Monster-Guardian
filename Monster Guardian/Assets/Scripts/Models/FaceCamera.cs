using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a component that will force the game object to look at the main.Camera
    /// </summary>
    public class FaceCamera : MonoBehaviour
    {
        // Update is called once per frame
        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
        }
    }
}