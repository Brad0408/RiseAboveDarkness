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
