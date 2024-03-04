using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    //Slider effects all instances volume
    void Start()
    {
        SoundManager.Instance.AdjustMasterVolume(slider.value);
        slider.onValueChanged.AddListener(val => SoundManager.Instance.AdjustMasterVolume(val));     
    }


}
