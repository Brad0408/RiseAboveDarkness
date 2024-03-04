using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TakeLight : LightManipulation
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
        if (isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E pressed");
                AddIntensity();
                AddFalloff();
                isPlayer = false;


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
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Light Hit");
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Light Left");
            isPlayer = false;
        }
    }


    public void AddIntensity()
    {
        playerLight.intensity += 5.5f;
    }

    public void AddFalloff()
    {
        playerLight.falloffIntensity -= 0.7f;
    }

}
