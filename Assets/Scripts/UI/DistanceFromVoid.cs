using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceFromVoid : MonoBehaviour
{
    [SerializeField] private Transform darkvoid;
    [SerializeField] private TextMeshProUGUI TextDistance;

    [SerializeField] private float distance;

    
    
    private void Update()
    {
        //Finds distance between player and the the rising darkness
        distance = (darkvoid.transform.position - transform.position).magnitude;

        //When less than 25 render text on screen
        if (distance <= 25.0f)
        {
            TextDistance.text = "Void Distance: " + distance.ToString("F1") + "m";
        }
        else
        {
            //dont render is greater
            TextDistance.text = null;
        }

        //If its at 10 make the text red
        if (distance <= 10.0f)
        {
            TextDistance.color = Color.red;
        }
        else
        {    
            //Keep text white
            TextDistance.color = Color.white;
        }
    }


}
