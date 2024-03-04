using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform Loc1, Loc2;
    [SerializeField] private float speed;
    [SerializeField] private Transform startPos;

    Vector3 nextPos;


    private void Start()
    {
        nextPos = startPos.position;
    }

    private void Update()
    {
        if (transform.position == Loc1.position)
        {
            nextPos = Loc2.position;
        }
        if (transform.position == Loc2.position)
        {
            nextPos = Loc1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

    }

}
