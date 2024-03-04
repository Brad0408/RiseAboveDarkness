using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformCheck : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            Debug.Log("On Moving Platform");
            player.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            player.transform.parent = null;
        }
    }
}
