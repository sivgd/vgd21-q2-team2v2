using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanAI : MonoBehaviour
{

    public GameObject snowball;
    public Animator ani;
    public float cooldownTime = 3;
    public float right = -1;
    private float nextFireTime;

    private void Start()
    {
        if (this.GetComponent<SpriteRenderer>().flipX == true)
        {
            right = 1;
        }
        else
        {
            right = -1;
        }
        ani = this.GetComponent<Animator>();
    }
    private void Update()
    {
        if (nextFireTime - 2.5 < Time.time)
        {
            ani.SetBool("Attacking", false);
        }    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (nextFireTime < Time.time)
            {
                Debug.Log("attacking, setting cooldown");
                attack();
                nextFireTime = Time.time + cooldownTime;
            }
        }
    }

    private void attack()
    {
        ani.SetBool("Attacking", true);
        GameObject ball = Instantiate(snowball, this.transform.position, this.transform.rotation);
        ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(right * 700f, 200f));
    }
}
