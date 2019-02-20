using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    // Use this for initialization
    public float moveSpeed;
    public float jumpHeight;
    Animator animator;
    Rigidbody2D rb;

    public float jumpTime;
    private float jumpTimeCounter;
    public float newJump;

    public Collider2D coll;
    public LayerMask ground;
    public bool isGrounded;

    public static int score = 5;
    private int powerupScore = 15;
    private ScoreManager scoreManager;
    public Text scoreText;

    private AudioSource source;
    public AudioClip[] clip;

    public float fJumpPressedRemember = 0;
    public float fJumpPressedRememberTime = 0.2f;



    void Start()
    {

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();

        scoreManager = FindObjectOfType<ScoreManager>();

    }
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.IsTouchingLayers(coll, ground);

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        animator.SetTrigger("isWalking");

        fJumpPressedRemember -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            fJumpPressedRemember = fJumpPressedRememberTime;
        }
        if ((fJumpPressedRemember > 0) && isGrounded)
        {
            fJumpPressedRemember = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            animator.SetTrigger("isJumping");
            source.PlayOneShot(clip[2]);//call jump sound


        }
        if (Input.GetMouseButtonUp(0))
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * newJump);
            }
        }
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    void ChangeColor()
    {
        scoreManager.scoreText.color = Color.white;
        //gameObject.GetComponent<Renderer>().material.color = Color.red;


    }
    void SpeedUp()
    {
        moveSpeed = 7;


    }
    void SpeedDown()
    {
        moveSpeed = 3;


    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "coins")
        {
            source.PlayOneShot(clip[0]);
            Score.score += score;

            Destroy(other.gameObject);


        }
        if (other.tag == "Enemy1")
        {
            source.PlayOneShot(clip[3]);
            //animator.SetTrigger("isDead");

            SceneManager.LoadScene("Score");


        }

        if (other.tag == "mushroom")
        {
            CancelInvoke("ChangeColor");
            scoreManager.scoreText.color = Color.red;
     
            source.PlayOneShot(clip[3]);
            Score.score -= score;
            Invoke("ChangeColor", 0.2f);
            SpeedDown();
            other.gameObject.SetActive(false);


        }
        if (other.tag == "powerup")
        {
            CancelInvoke("ChangeColor");
            scoreManager.scoreText.color = Color.yellow;
            source.PlayOneShot(clip[1]);
            Score.score += powerupScore;
            Destroy(other.gameObject);
            Invoke("ChangeColor", 0.5f);
            SpeedUp();

        }


    }
}