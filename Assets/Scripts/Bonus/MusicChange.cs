using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChange : MonoBehaviour
{

    private AudioSource audioSource;
    private AudioClip fastMusic;



    //when player overlaps with this box pause current music and play fast music
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource = SoundManager.Instance.returnaudiosource();
            audioSource.Pause();

            fastMusic = SoundManager.Instance.returnFastMusic();
            audioSource.clip = fastMusic;
            audioSource.Play();
        }
    }
    }


