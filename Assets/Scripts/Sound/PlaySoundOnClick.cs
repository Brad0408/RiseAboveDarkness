using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    [SerializeField] private AudioClip clip;

    public void PlaySoundEffect()
    {
        SoundManager.Instance.PlaySound(clip);
    }
}
