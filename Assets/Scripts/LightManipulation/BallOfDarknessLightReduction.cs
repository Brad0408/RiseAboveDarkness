using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BallOfDarknessLightReduction : LightManipulation
{
    public ScreenShake hitCameraShake;

    private AudioSource effectSource;
    private AudioClip hitSound;

    private void Awake()
    { 
        //Important check, or refernece will changes itself when the game is running for some reason, this stops it.

        if (playerLight == null)
        {
            //Debug.Log("No Light");
        }
        else
        {
            //Debug.Log("Yes Light");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Darkenss Hit");
            BallReduceInensity(); 
            BallReduceFalloff();


            effectSource = SoundManager.Instance.returnEffectSource();
            effectSource.Pause();

            hitSound = SoundManager.Instance.returnPlayerHitSound();
            effectSource.clip = hitSound;
            effectSource.Play();




            StartCoroutine(hitCameraShake.Shake(0.1f, 0.4f));
        }
    }

    void BallReduceInensity()
    {
        //Debug.Log("-2 Intensity");
        playerLight.intensity -= 2.5f;
    }

    void BallReduceFalloff()
    {
        //Debug.Log("+0.25 Falloff");
        playerLight.falloffIntensity += 0.10f;
    }
}
