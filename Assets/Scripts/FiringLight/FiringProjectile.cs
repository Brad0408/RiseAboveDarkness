using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;   //Needed to access Unity's 2D light features

public class FiringProjectile : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;

    public GameObject projectile;
    public Transform FirePoint;

    [SerializeField] private bool canFire;
    [SerializeField] private float timeBetweenFiring;
    private float timer;

    private Light2D playerLight;

    private AudioSource effectSource;
    private AudioClip shootingSound;



    private void Start()
    {
        playerLight = GameObject.FindGameObjectWithTag("LightRing").GetComponent<Light2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {    
        //Logic to shoot where the mouse is at
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        //Debug.Log("intensity" + playerLight.intensity);

        //Checking if player can fire logic
        if (canFire == false)
        {
            timer += Time.deltaTime;

            //Can fire check
            if (timer > timeBetweenFiring && playerLight.intensity > 1.0f)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;

            //Create projectile
            Instantiate(projectile, FirePoint.position, Quaternion.identity);

            //Take Away light values when the player has fired
            playerLight.intensity -= 1.5f;
            playerLight.falloffIntensity += 0.03f;


            //Get the source and pause it
            effectSource = SoundManager.Instance.returnEffectSource();
            effectSource.Pause();

            //In the source change the clip to main level music
            shootingSound = SoundManager.Instance.returnShootSound();
            effectSource.clip = shootingSound;
            effectSource.Play();




        }
    }

}
