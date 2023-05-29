using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private Slider _slider;
    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(ChangeVolume);

        float savedValue = PlayerPrefs.GetFloat("volume");
        _slider.value = savedValue;
        AudioListener.volume = savedValue;
    }

    private void ChangeVolume(float newVolume)
    {
        PlayerPrefs.SetFloat("volume", newVolume);
        AudioListener.volume = newVolume;
    }

    
}
