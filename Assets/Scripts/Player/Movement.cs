using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public bool InputEnabled = true;



    [SerializeField] private float speed;
    [SerializeField] private float jumpspeed;

    protected bool facingRight = true;
    protected bool jumped;

    public int jumpCount = 2;

    private bool DoubleJumpDone;
    private bool canDoubleJump;

    private float horizontal;

    public LayerMask groundLayer;

    Rigidbody2D rb;

    public SpriteRenderer PlayerSprite;

    public Light2D playerLight;

    Animator animator;


    private AudioSource audioSource, effectSource;
    private AudioClip titleMusic, jumpSound;
/*
    public Sprite musicRef, effectsRef;
    public Button musicButton, effectButton;*/

    public GameObject wholeMainmenu;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerSprite = GetComponentInChildren<SpriteRenderer>();
        playerLight = GetComponentInChildren<Light2D>();
        animator = GetComponentInChildren<Animator>();

        if (playerLight == null)
        {
            //Debug.Log("No Light");
        }
        else
        {
            //Debug.Log("Yes Light");
        }

    }

    void FixedUpdate()
    {
        //Move Character
        rb.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime, rb.velocity.y);

        //Jumping
        if (IsGrounded() == true)
        {
            jumpCount = 2;
            PlayerSprite.color = new Color(1f, 1f, 1f, 1f);
            animator.SetBool("Jump", false);

            //old
            //sprite.color = new Color(255, 0, 0, 255);
            //sprite.color = new Color(1f, 0.47f, 0.25f, 1f);
        }

        //Allow Jumping
        if (jumpCount > 0)
        {
            Jump();
        }

        //Disable Double Jump when light is too low
        if (playerLight.intensity <= 1f)
        {
            canDoubleJump = false;
        }
        else
        {
            canDoubleJump = true;
        }

        //Disable Double Jump when light is too low
        if (!canDoubleJump)
        {
            jumpCount = 0;
        }

        //Double Jump Burnout Colour
        if (jumpCount == 0)
        {
            //Debug.Log("Player Sprite Change Colour");
            DoubleJumpDone = true;
            PlayerSprite.color = new Color(0.71f, 0.12f, 0f, 1f);
        }


        // Sprite Flip
        if (horizontal > 0 && !facingRight)
        {
            FlipSprite();
        }
        else if (horizontal < 0 && facingRight)
        {
            FlipSprite();
        }
    }
    
    void Update()
    {
        //Input for jumping
        if (Input.GetButtonDown("Jump") && InputEnabled == true)
        {
            jumped = true;
            InputEnabled = true;
            animator.SetBool("Jump", true);
        }

        horizontal = Input.GetAxis("Horizontal");

        if (DoubleJumpDone == true)
        {
            DoubleJumpTakeAway();
            DoubleJumpDone = false;
        }

        //Logic check to prevent the player from bouncing if the played pressed space in the air
        if (IsGrounded() == false && jumpCount == 0)
        {
            InputEnabled = false;
        }
        else
        {
            InputEnabled = true;
        }


        if (Input.GetKeyDown(KeyCode.M))
        {

            SceneManager.LoadScene("MainMenu");

            wholeMainmenu = DontDestory.Instance.menu();
            wholeMainmenu.SetActive(true);



            audioSource = SoundManager.Instance.returnaudiosource();
            audioSource.Pause();

            titleMusic = SoundManager.Instance.returnaudioCliptitlemusic();
            audioSource.clip = titleMusic;
            audioSource.Play();


            //Old Way - Trying to store the image of the sprite between scenes.
            ///////////////////////////////////////////////////////////////////////////////

            /*
                        musicRef = MainMenu.Instance.returnLastmusicImage();
                        effectsRef = MainMenu.Instance.returnLasteffectImage();*/

            //musicButton = MainMenu.Instance.returnMusicButton();
            //effectButton = MainMenu.Instance.returnMusicButton();

            /*            musicButton.image.sprite = musicRef;
                        effectButton.image.sprite = effectsRef;

                        MainMenu.Instance.SetLastMusicImage(musicRef);
                        MainMenu.Instance.SetLastEffectsImage(effectsRef);*/

            ///////////////////////////////////////////////////////////////////////////////

        }
    }


    // Flip Character Sprite
    void FlipSprite()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    //Jump
    void Jump()
    {
        //Jump
        if (jumped == true)
        {

            //rb.AddForce(new Vector2(0f, jumpspeed));

            rb.velocity = new Vector2(0, jumpspeed);

            jumpCount--;
            jumped = false;

            effectSource = SoundManager.Instance.returnEffectSource();
            effectSource.Pause();

            jumpSound = SoundManager.Instance.returnJumpSound();
            effectSource.clip = jumpSound;
            effectSource.Play();


        }
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.55f;

        //0.55f

        Debug.DrawRay(position, direction * 1f, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            //Debug.Log(hit.transform.name);
            return true;
        }

        return false;
    }

    //Last Duration Of Time In Air. Ends When Landed
    void DoubleJumpTakeAway()
    {
        playerLight.intensity -= 0.018f;
        playerLight.falloffIntensity += 0.0005f;
    }
}


