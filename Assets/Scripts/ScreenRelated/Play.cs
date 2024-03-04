using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip mainLevelMusicClip;

    //Call when restart button is pressed if the player dies
    public void Restart()
    {
        //Get the source and pause it
        audioSource = SoundManager.Instance.returnaudiosource();
        audioSource.Pause();

        //In the source change the clip to main level music
        mainLevelMusicClip = SoundManager.Instance.returnaudioclipmainLevelMusic();
        audioSource.clip = mainLevelMusicClip;
        audioSource.Play();


        SceneManager.LoadScene("MainLevel");
    }
}
