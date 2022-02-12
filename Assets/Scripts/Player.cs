using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip coinSfx;

    private bool isGrounded;

    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.instance.gameOver)
        {
            PlayerMove();
            PlayerJump();
        }
    }

    void PlayerMove()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if(horizontalInput > 0)
        {
            transform.position += new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime;
            sr.flipX = false;
            anim.SetBool("Walk", true);
        }
        else if(horizontalInput < 0)
        {
            transform.position -= new Vector3(moveSpeed, 0f, 0f) * Time.deltaTime;
            sr.flipX = true;
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("Jump", false);
            isGrounded = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Coin"))
        {
            Destroy(collider.gameObject);
            audioSource.PlayOneShot(coinSfx);
            GameManager.instance.UpdateScore();
        }

        if(collider.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.gameOver = true;
            GameManager.instance.EndGame();
            Destroy(gameObject);
        }
    }
}
