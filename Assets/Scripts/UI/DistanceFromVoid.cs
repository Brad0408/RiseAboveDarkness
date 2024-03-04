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
        distance = (darkvoid.transform.position - transform.position).magnitude;

        //SO DUMB THIS SHOWS WHEN LOWER THAN 25, NOT BUGGED (-25 MINS OF MY LIFE) THIS IS WHY U ADD COMMENTS WHEN YOU MAKE SOMETHING
        if (distance <= 25.0f)
        {
            TextDistance.text = "Void Distance: " + distance.ToString("F1") + "m";
        }
        else
        {
            TextDistance.text = null;
        }

        if (distance <= 10.0f)
        {
            TextDistance.color = Color.red;
        }
        else
        {
            TextDistance.color = Color.white;
        }
    }


}
