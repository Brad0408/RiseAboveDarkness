using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoidMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private AudioSource audioSource;
    private AudioClip GameOverMusicClip;


    private void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Player")))
        {
            SceneManager.LoadScene("GameOver");

            audioSource = SoundManager.Instance.returnaudiosource();
            audioSource.Pause();

            GameOverMusicClip = SoundManager.Instance.returngameOverMusicClip();
            audioSource.clip = GameOverMusicClip;
            audioSource.Play();

        }
    }
}
