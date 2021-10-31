using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] AudioSource audios;
    [SerializeField] Slider slider;

    public void ChangeAudio()
    {
        audios.volume = slider.value;
    }
}
