using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //Make accessible to editor
    [SerializeField] private Transform Loc1, Loc2;
    [SerializeField] private float speed;
    [SerializeField] private Transform startPos;

    Vector3 nextPos;


    private void Start()
    {
        nextPos = startPos.position;
    }

    //Make the platform move
    private void Update()
    {
        //Aleternaet destination positions
        if (transform.position == Loc1.position)
        {
            nextPos = Loc2.position;
        }
        if (transform.position == Loc2.position)
        {
            nextPos = Loc1.position;
        }

        //When it reaches a postion set new next position and travel towards it
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

    }

}
