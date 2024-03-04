using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TakeLight : LightManipulation //Inherit class
{
    private bool isPlayer;


    private AudioSource effectSource;
    private AudioClip absorbLight;

    private void Awake()
    {
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
        if (isPlayer)   //Set to true if player is overlapping with the light source
        {
            if (Input.GetKeyDown(KeyCode.E))  //Player presses E
            {    
                //Call add light functions
                //Debug.Log("E pressed");
                AddIntensity();
                AddFalloff();
                isPlayer = false;

                //Sounds
                effectSource = SoundManager.Instance.returnEffectSource();
                effectSource.Pause();

                absorbLight = SoundManager.Instance.returnLightAbsorbSound();
                effectSource.clip = absorbLight;
                effectSource.Play();




                Destroy(gameObject);
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {    
        //Set to true if player is overlapping with light source
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Light Hit");
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Set to false if player is not overlapping
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Light Left");
            isPlayer = false;
        }
    }

    //Add light values functions
    public void AddIntensity()
    {
        playerLight.intensity += 5.5f;
    }

    public void AddFalloff()
    {
        playerLight.falloffIntensity -= 0.7f;
    }

}
