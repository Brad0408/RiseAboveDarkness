using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeSprite : MonoBehaviour
{
    [SerializeField] private Sprite soundOnImage, muteButtonImage;
    [SerializeField] private Button button;
    private bool Clicked = true;

    private void Start()
    {
        soundOnImage = button.image.sprite;
    }
    public void ChangeImage()
    {    
        //Changes the sprite of the toggle audio button if they are clicked to a red version for mute or a green sprite if toggled back on
        if (Clicked)
        {
            button.image.sprite = muteButtonImage;
            Clicked = false;
        }
        else
        { 
            button.image.sprite = soundOnImage;
            Clicked = true;
        }

    }

}
