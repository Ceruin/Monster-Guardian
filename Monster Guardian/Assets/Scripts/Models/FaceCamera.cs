using UnityEngine;

namespace Assets.Scripts
{

    /// <summary>
    /// Forces the object to always face the camera
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