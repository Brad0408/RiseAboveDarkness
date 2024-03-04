using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource musicSource, effectSource;

    //Sound manager has access to all these variables. 
    //Player can set sounds in editor
    [SerializeField] private AudioClip mainLevelmusic, titleMusic, gameOverMusic, winningMusic, fastMusic, jumpSoundEffect, shootSoundEffect, darknessDestroySound, playerHit, absorbSound;



    void Awake()
    {
        //Create Instance If There Isn't One
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { 
            Destroy(gameObject);
        }
    }

    //SoundEffect Once
    public void PlaySound(AudioClip clip)
    { 
        effectSource.PlayOneShot(clip);
    }

    //Slider
    public void AdjustMasterVolume(float value)
    {
        AudioListener.volume = value;
    
    }

    //Effect Button
    public void ToggleEffects()
    { 
        effectSource.mute= !effectSource.mute;
    }

    //Music Button
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public AudioSource returnaudiosource()
    {
        return musicSource;
    }

    public AudioClip returnaudioclipmainLevelMusic()
    {
        return mainLevelmusic;
    }

    public AudioClip returnaudioCliptitlemusic()
    {
        return titleMusic;
    }

    public AudioClip returngameOverMusicClip()
    {
        return gameOverMusic;
    }

    public AudioClip returnwinningMusicClip()
    {
        return winningMusic;
    }

    public AudioClip returnFastMusic()
    { 
        return fastMusic;
    }

    public AudioSource returnEffectSource() 
    {
        return effectSource;
    }

    public AudioClip returnJumpSound()
    {
        return jumpSoundEffect;
    }

    public AudioClip returnShootSound()
    {
        return shootSoundEffect;
    }

    public AudioClip returnDarknessDestroySound() 
    {
        return darknessDestroySound;
    }

    public AudioClip returnPlayerHitSound()
    {
        return playerHit;
    }

    public AudioClip returnLightAbsorbSound() 
    {
        return absorbSound;
    }


}
