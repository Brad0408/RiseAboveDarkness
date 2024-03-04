using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    //Really flawed sound sound system making use of singleton instances... yeah. If two sounds happen at once the latter one overides the first sound. Works just enough for this project size

    //Can be called to play sound effect
    public void PlaySoundEffect()
    {
        SoundManager.Instance.PlaySound(clip);
    }
}
