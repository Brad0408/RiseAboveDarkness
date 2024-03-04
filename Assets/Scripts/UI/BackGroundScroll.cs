using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundScroll : MonoBehaviour
{
    [SerializeField] private RawImage BG;
    [SerializeField] private float xSpeed, ySpeed;


    // Makes BG of main menu scroll
    void Update()
    {
        BG.uvRect = new Rect(BG.uvRect.position + new Vector2(xSpeed, ySpeed) * Time.deltaTime, BG.uvRect.size);
    }
}
