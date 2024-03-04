using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManipulation : MonoBehaviour
{

    [SerializeField] private float MaxInensity;

    [SerializeField] public float CurrentIntensity;

    [SerializeField] private float ReduceIntensity;

    [SerializeField] private float CurrentFalloff;
    [SerializeField] private float ReduceFalloff;

    [SerializeField] private float AddLightIntensity;
    [SerializeField] private float AddLightFalloff;

    
    
    public Light2D playerLight;

    private void Awake()
    {
        //Get 'LightRing' component from the player
        playerLight = GetComponentInChildren<Light2D>();


        if (playerLight == null)
        {
            //Debug.Log("No Light");
        }
        else
        {
            //Debug.Log("Yes Light");
        }


    }

    private void Update()
    {

        ReduceInensity();

        ///////////////////////////////////////////////////////////////////////////


        ReduceFallOff();

        //Stop the Light from reaching 0
        if (playerLight.intensity <= 1.0f)
        {
            playerLight.intensity = 1.0f;
        }

        //Stop the light from going above a certain level when absorbing other light sources
        if (playerLight.intensity >= MaxInensity)
        {
            playerLight.intensity = MaxInensity;
        }
    }


    public void ReduceInensity()
    {
        //Set current intensity from 'lightRing' itself
        CurrentIntensity = playerLight.intensity;



        //Debug.Log("intensity" + CurrentIntensity);

        //Reduce intensity over time
        CurrentIntensity -= ReduceIntensity;

        //Set the actual light intensity from current intensity
        playerLight.intensity = CurrentIntensity;
    }

    public void ReduceFallOff()
    {
        //Light Falloff
        CurrentFalloff = playerLight.falloffIntensity;

        //Debug.Log("falloff" + CurrentFalloff);

        //To reduce falloff you add it 
        CurrentFalloff += ReduceFalloff;

        playerLight.falloffIntensity = CurrentFalloff;
    }

}
