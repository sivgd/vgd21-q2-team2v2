using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanAI : MonoBehaviour
{

    public GameObject snowball;
    public float cd = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(3);
        cd = 0f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            attack();
            cd++;
        }
    }

    private void attack()
    {
        if (cd == 0)
        {
            Debug.Log("attacking");
            GameObject ball = Instantiate(snowball, this.transform.position, this.transform.rotation);
            ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100f, 0f));
        }
        else
        {
            StartCoroutine(cooldown());
        }
    }
}
