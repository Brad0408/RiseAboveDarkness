using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


public class LightLevelBar : MonoBehaviour
{
    [SerializeField] private Image lightbar;
    [SerializeField] private Light2D playerLight;

    private float percentage;

    private void Update()
    {
        percentage = (playerLight.intensity/20.0f);
        lightbar.fillAmount = percentage;
        
    }

}
