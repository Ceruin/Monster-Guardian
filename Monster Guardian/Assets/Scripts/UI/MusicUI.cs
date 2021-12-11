using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    /// <summary>
    /// This is a music UI class to determine the music being played to the player.
    /// </summary>
    public class MusicUI : MonoBehaviour
    {
        [SerializeField] private AudioSource audios;
        [SerializeField] private Slider slider;

        /// <summary>
        /// Change the audio value based on ui
        /// </summary>
        public void ChangeAudio()
        {
            audios.volume = slider.value;
        }
    }
}