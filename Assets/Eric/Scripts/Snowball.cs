using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    private float diePoint;
    public float lifespan;
    public bool canDMG = true;

    // Start is called before the first frame update
    void Start()
    {
        diePoint = Time.time + lifespan;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > diePoint)
        {
            Destroy(gameObject);
        }
    }

    private void dmg(Collider2D target)
    {
        target.GetComponent<PlayerController>().Hit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(canDMG)
            {
                dmg(collision);
                Destroy(gameObject);
                canDMG = false;
            }
        }
    }
}
