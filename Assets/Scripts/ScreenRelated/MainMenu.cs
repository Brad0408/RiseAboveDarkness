using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip mainLevelMusicClip;


    [SerializeField] private Sprite lastButtonImageMusic, lastButtonImageEffects;
    [SerializeField] private Button MusicButton, EffectsButton;

    public static MainMenu Instance;

    void Awake()
    {
        //Create Instance If There Isn't One
        if (Instance == null)
        {
            Instance = this;
        }
    }

    //Check What Sprite Is In Use
    private void Update()
    {
        lastButtonImageMusic = MusicButton.image.sprite;
        lastButtonImageEffects = EffectsButton.image.sprite;

    }

    public void Play()
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

    public void Quit()
    {
        Application.Quit();
    }

    public void SetLastMusicImage(Sprite passedMusic)
    {
        MusicButton.image.sprite = passedMusic;
        //Debug.Log("called funcitoabsndjkasb diasdpoiashidsa");
    }

    public void SetLastEffectsImage(Sprite passedEffects)
    {
        EffectsButton.image.sprite = passedEffects;
    }

    public Sprite returnLastmusicImage()
    {
        return lastButtonImageMusic;
    }

    public Sprite returnLasteffectImage()
    {
        return lastButtonImageEffects;
    }

    public Button returnMusicButton()
    {
        return MusicButton;
    }

    public Button returnEffectsButton() 
    { 
        return EffectsButton;
    }

}
