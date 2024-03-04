using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    void Start()
    {
        SoundManager.Instance.AdjustMasterVolume(slider.value);
        slider.onValueChanged.AddListener(val => SoundManager.Instance.AdjustMasterVolume(val));     
    }


}
