using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAudio : MonoBehaviour
{
    //For toggle audio and sounds buttons
    
    [SerializeField] private bool toggleMusic, toggleEffects;
    [SerializeField] private Image image;



    //private int effectClickCount = 0;
    //private int musicClickCount = 0;

    public void Toggle()
    {
        //If button clicked -- bool changes, calling funciton
        if (toggleEffects)
        {
            SoundManager.Instance.ToggleEffects();
            //image.color = Color.red;
            //effectClickCount++;

        }

        if (toggleMusic)
        {
            SoundManager.Instance.ToggleMusic();
            //image.color = Color.red;
            //musicClickCount++;
        } 
    }

/*    private void Update()
    {
        if (effectClickCount ==2)
        {
            image.color = Color.green;
            effectClickCount = 0;
        }

        if (musicClickCount == 2)
        {
            image.color = Color.green;
            musicClickCount = 0;
        }

    }*/


}
