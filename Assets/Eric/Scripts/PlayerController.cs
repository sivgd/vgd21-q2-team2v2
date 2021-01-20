using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float accel = 8f;
    public float health = 6;
    public float speedCap = 5f;
    public float jumpForce = 400f;
    public bool grounded;
    public GameObject healthDisplay;
    public GameObject respawnPoint;
    public Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() 
    {
        //Movement:
        if (Input.GetAxis("Horizontal") != 0) 
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, 0);
                rb.AddForce(new Vector2(accel, 0));
            }
            else 
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * 1, transform.localScale.y, 0);
                rb.AddForce(new Vector2(-accel, 0));
            }
        }
        //Speed Cap:
        if (rb.velocity.x > speedCap) 
        {
            rb.velocity = new Vector2(speedCap, rb.velocity.y);
        }
        if (rb.velocity.x < -speedCap)
        {
            rb.velocity = new Vector2(-speedCap, rb.velocity.y);
        }
        //Debug.Log(rb.velocity);
    }

    void Update() 
    {
        animator.SetFloat("Speed", Math.Abs(rb.velocity.x));

        //Jumping----------------------------------------------------------------

        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            animator.SetBool("Jumping", true);
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    public void Hit() 
    {
        Debug.Log("hit called");
        healthDisplay.GetComponent<UI_HealthHandler>().Health -= 1;
    }

    public void die()
    {
        //Debug.Log("Die called");
        healthDisplay.GetComponent<UI_HealthHandler>().Health -= 2;
        transform.position = respawnPoint.transform.position;
        sr.flipX = false;
    }
    
    //Collisions-----------------------------------------------------------------

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.tag == "Ground")
        {
            grounded = true;
            animator.SetBool("Jumping", false);
        }
        //animator.SetBool("IsJumping", false);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == "Spikes")
        {
            Debug.Log("Respawn");
            die();
        }
    } 

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }
}
