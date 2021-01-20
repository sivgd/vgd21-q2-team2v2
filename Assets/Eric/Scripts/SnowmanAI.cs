using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanAI : MonoBehaviour
{

    public GameObject snowball;
    public float cooldownTime = 3;
    private float nextFireTime; 

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(nextFireTime < Time.time)
            {
                Debug.Log("attacking, setting cooldown");
                attack();
                nextFireTime = Time.time + cooldownTime;
            }
        }
    }

    private void attack()
    {
        GameObject ball = Instantiate(snowball, this.transform.position, this.transform.rotation);
        ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-700f, 200f));
    }
}
