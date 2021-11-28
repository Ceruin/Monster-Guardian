using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class MusicUI : MonoBehaviour
    {
        [SerializeField] AudioSource audios;
        [SerializeField] Slider slider;

        public void ChangeAudio()
        {
            audios.volume = slider.value;
        }
    }
}