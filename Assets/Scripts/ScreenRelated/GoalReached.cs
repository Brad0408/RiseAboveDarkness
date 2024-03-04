using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalReached : MonoBehaviour
{


    private AudioSource audioSource;
    private AudioClip winningMusicClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If player hits the goal the game is won
        
        if (collision.gameObject.CompareTag("Player"))
        {
            //If true load winning screen
            SceneManager.LoadScene("WinningScreen");
            //Debug.Log("Win");


            audioSource = SoundManager.Instance.returnaudiosource();
            audioSource.Pause();

            winningMusicClip = SoundManager.Instance.returnwinningMusicClip();
            audioSource.clip = winningMusicClip;
            audioSource.Play();

        }
    }
}
