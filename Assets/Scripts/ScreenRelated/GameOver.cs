using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    private AudioSource audioSource;
    private AudioClip titleMusic;


    public GameObject wholeMainmenu;

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");


        wholeMainmenu = DontDestory.Instance.menu();
        wholeMainmenu.SetActive(true);


        audioSource = SoundManager.Instance.returnaudiosource();
        audioSource.Pause();

        titleMusic = SoundManager.Instance.returnaudioCliptitlemusic();
        audioSource.clip = titleMusic;
        audioSource.Play();
    }
}
