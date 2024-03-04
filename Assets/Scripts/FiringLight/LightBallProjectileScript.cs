using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBallProjectileScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera cam;
    private Rigidbody2D rb;

    [SerializeField] private float speed;
    [SerializeField] private float lifespan;


    private AudioSource effectSource;
    private AudioClip darknessDestroySoundEffect;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();

        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        rb.velocity = new Vector2 (direction.x, direction.y).normalized * speed;



        float rot = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        transform.eulerAngles = new Vector3(0, 0, rot + 90);
    }

    private void Update()
    {
        Destroy(gameObject, lifespan);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BallOfDarkness"))
        {
            Debug.Log("Darkenss Hit With Projectile");
            Destroy(collision.gameObject);
            Destroy(gameObject);

            //Get the source and pause it
            effectSource = SoundManager.Instance.returnEffectSource();
            effectSource.Pause();

            //In the source change the clip to main level music
            darknessDestroySoundEffect = SoundManager.Instance.returnDarknessDestroySound();
            effectSource.clip = darknessDestroySoundEffect;
            effectSource.Play();


        }
        else
        { 
            Destroy(gameObject);
        }
    }
}
